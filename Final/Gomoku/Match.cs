using Final.Control;

namespace Final.Gomoku
{
    /// <summary>
    /// 描述一场对局的玩家和棋盘
    /// </summary>
    public class Match:IDisposable
    {
        private PieceColor playerColor;

        public Player Player;
        public Panel Panel;
        public GomokuManager.GomokuManager AIManager;
        // 玩家执棋的颜色
        public PieceColor PlayerColor
        {
            get { return playerColor; }
        }
        // AI执旗的颜色
        public PieceColor AIColor
        {
            get
            {
                return playerColor switch {
                    PieceColor.WHITE => PieceColor.BLACK,
                    PieceColor.BLACK => PieceColor.WHITE,
                    _=> throw new ArgumentOutOfRangeException(nameof(playerColor)),
                };
            }
        }

        public Match(Player player,string progPath="./pbrain-pela.exe", PieceColor playerColor = PieceColor.BLACK)
        {
            this.Player = player;
            Panel = new Panel(player.Name,"AI");
            this.playerColor = playerColor;
            this.AIManager=new GomokuManager.GomokuManager(progPath);
        }

        /// <summary>
        /// 用户放置棋子
        /// </summary>
        /// <param name="point">位置</param>
        /// <param name="aiPoint">AI选择的位置</param>
        /// <returns></returns>
        public Panel.PlaceStatus UserPlace(PanelPoint point)
        {
            // 测试我们的选择
            return this.Panel.Place(point,this.PlayerColor);
        }

        /// <summary>
        /// AI SUGGEST的坐标不可用时，我们使用bfs简单地寻找最近的位置
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        private PanelPoint? FirstAvailable(PanelPoint point)
        {
            //去重
            HashSet<PanelPoint> set = new HashSet<PanelPoint>();
            Queue<PanelPoint> queue = new Queue<PanelPoint>();
            queue.Enqueue(point);
            while (queue.Count!=0)
            {
                var current = queue.Dequeue();
                if (set.Contains(current))
                    continue;
                set.Add(current);
                // 当前位置为空则返回
                if (this.Panel.Index(current) == PointStatus.NONE)
                {
                    AIManager.SendMessage($"PLAY {current.x},{current.y}");
                    return current;
                }
                for (int i = -1; i <= 1; ++i)
                {
                    for (int j = -1; j <= 1; ++j)
                    {
                        PanelPoint newPoint = current;
                        try
                        {
                            newPoint = new PanelPoint(current.x + i, current.y + j);
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            continue;
                        }
                        // 如果没有访问过，则入队
                        if (!set.Contains(newPoint))
                        {
                            queue.Enqueue(newPoint);
                        }
                    }
                }
            }
            // 这种情况一般不会发生，除非棋盘已满
            return null;
        }

        public (Panel.PlaceStatus,PanelPoint) AIPlace(PanelPoint point)
        {
            // 通知AI我们下在哪里，从而获取AI的回答，将AI的回答传到aiPoint中以更新UI
            var aiPoint = AIManager.PlacePiece(point);
            // 当前位置已有棋子
            var status = this.Panel.Place(aiPoint, this.AIColor);
            if(status==Panel.PlaceStatus.FAIL)
            {
                aiPoint = FirstAvailable(aiPoint);
                status = this.Panel.Place(aiPoint!, this.AIColor);
            }
            return (status, aiPoint!);
        }

        public void Dispose()
        {
            AIManager.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
