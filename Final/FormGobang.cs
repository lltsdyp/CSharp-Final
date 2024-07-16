using Final.Control;

namespace Final
{
    public partial class FormGomoku : Form
    {
        private QwenClient qwen;
        private Gomoku.Match? match;

        // 格子的边长
        const int BlockSize = 50;
        // 判定区域的边长，判定区域的大小暂定为30x30
        const int ValidSize = 30;

        /// <summary>
        /// 获取棋盘的缩放尺度
        /// </summary>
        public double PanelScale
        {
            get
            {
                // 获取控件和图片的大小
                Size pictureBoxSize = pictureBoxGobangPanel.Size;
                Size imageSize = pictureBoxGobangPanel.Image.Size;

                // 计算缩放比例，以较小的为准
                double scaleWidth = (double)pictureBoxSize.Width / imageSize.Width;
                double scaleHeight = (double)pictureBoxSize.Height / imageSize.Height;
                return Math.Min(scaleWidth, scaleHeight);
            }
        }

        /// <summary>
        /// 棋盘上(0,0)点的坐标
        /// </summary>
        public Point PanelOrigin
        {
            get
            {
                // 获取控件和图片的大小
                Size pictureBoxSize = pictureBoxGobangPanel.Size;
                Size imageSize = pictureBoxGobangPanel.Image.Size;
                double scale = this.PanelScale;

                // 计算(0,0)点的位置:

                // 首先获取棋盘中点的位置，这与imageBox的中点位置重合
                (int middlex, int middley) = (pictureBoxSize.Width / 2, pictureBoxSize.Height / 2);

                // 减去七个格子缩放后的大小
                (double initialx, double initialy) = (middlex - 7 * scale * BlockSize, middley - 7 * scale * BlockSize);

                return new Point((int)initialx, (int)initialy);
            }
        }
        public FormGomoku()
        {
            // 连接到通义千问
            //string apikey = token.GetString("APIKey")!;
            //qwen = new QwenClient(apikey,token.GetString("SystemMessage")!);

            InitializeComponent();
        }

        private void FormGobang_Load(object sender, EventArgs e)
        {
            labelGuide.Text = GameText.Wait_for_start;
            comboBoxLevel.Items.AddRange(new string[]
            {
                "简单",
                "中等",
                "困难",
                "噩梦"
            });
            comboBoxLevel.SelectedIndex = 0;
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            // 创建对局
            string playername = textBoxPlayerName.Text;
            match = new Gomoku.Match(new Gomoku.Player(playername), AIPrograms.ResourceManager
                .GetString(comboBoxLevel.Text)+"main.exe");
            match.AIManager.GameStart();

            // 更新UI
            pictureBoxGobangPanel.Controls.Clear();
            labelPlayerName.Text = playername;
            buttonGiveup.Enabled = true;
            buttonConfirm.Enabled = false;
            labelGuide.Text = GameText.Wait_for_player;
        }

        /// <summary>
        /// 根据MouseEventArgs给的鼠标x,y坐标的数据，计算用户点击的是哪一个格点
        /// </summary>
        /// <param name="x">鼠标的x坐标</param>
        /// <param name="y">鼠标的y坐标</param>
        /// <returns></returns>
        private Gomoku.PanelPoint? GetSelectedPointFromRealPosition(int x, int y)
        {
            double scale = PanelScale;

            // 减去七个格子缩放后的大小
            (int initialx, int initialy) = (PanelOrigin.X, PanelOrigin.Y);

            // 计算diffx和diffy对格子大小取模，如果<=ValidSize/2（上一个格子） 或>=BlockSize-ValidSize/2（下一个格子）即可
            // 定义一个简单的转换函数
            var convertFunc = (int x) =>
                (int)(x / scale) switch
                {
                    int i when (i % BlockSize <= ValidSize / 2 && i >= 0) => i / BlockSize,
                    int i when i % BlockSize >= BlockSize - ValidSize / 2 => i / BlockSize + 1,
                    _ => -1//不在判定区域内
                };

            // 计算结果
            int Resultx = convertFunc(x - initialx);
            int Resulty = convertFunc(y - initialy);

            if (Resultx != -1 && Resulty != -1)
            {
                return new Gomoku.PanelPoint(Resultx, Resulty);
            }
            //不在判定区域内
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 给定棋盘上的坐标，给出绘图区域左上角在屏幕坐标系下的坐标
        /// 用于绘制棋子
        /// </summary>
        /// <param name="panelPoint">棋盘坐标</param>
        /// <returns></returns>
        private Point GetTopLeftPointFromPanelPoint(Gomoku.PanelPoint panelPoint)
        {
            double scale = PanelScale;
            var relativePoint = new Point(PanelOrigin.X - Piece.PieceSize / 2 + (int)(panelPoint.x * BlockSize * scale),
                PanelOrigin.Y - Piece.PieceSize / 2 + (int)(panelPoint.y * BlockSize * scale));
            return relativePoint;
        }

        /// <summary>
        /// 在指定的格点上绘制指定颜色的棋子
        /// </summary>
        /// <param name="panelPoint">指定的格点位置</param>
        /// <param name="color">指定的棋子颜色</param>
        private void DrawPieceOnPanel(Gomoku.PanelPoint panelPoint, PieceColor color)
        {
            var piece = new Piece(color);
            piece.Location = GetTopLeftPointFromPanelPoint(panelPoint);
            pictureBoxGobangPanel.Controls.Add(piece);
        }

        /// <summary>
        /// 强制重新绘制窗体，在回合转换时很有用
        /// </summary>
        private void FlushWindow()
        {
            this.Invalidate();
            this.Update();
        }
        private void pictureBoxGobangPanel_MouseDown(object sender, MouseEventArgs e)
        {
            // 不在对局中时，不响应对棋盘的点击
            if (match == null)
                return;
            var point = GetSelectedPointFromRealPosition(e.X, e.Y);
            if (point == null)
            {
                return;
            }
            // 尝试更新棋盘
            var result = match.UserPlace(point);
            // 如果成功，则更新UI
            if (result != Gomoku.Panel.PlaceStatus.FAIL)
            {
                DrawPieceOnPanel(point, match.PlayerColor);
                // 判断是否获胜
                if (result == Gomoku.Panel.PlaceStatus.WIN)
                {
                    UnloadMatch("You win");
                }
                //未获胜，让AI下棋
                else
                {
                    labelGuide.Text = GameText.Wait_for_AI;
                    FlushWindow();
                    // 获取AI的决策
                    (var status, var aiPoint) = match.AIPlace(point);
                    DrawPieceOnPanel(aiPoint, match.AIColor);
                    //根据是否胜利更新UI
                    if (status == Gomoku.Panel.PlaceStatus.WIN)
                    {
                        UnloadMatch("You lose");
                    }
                    else
                    {
                        labelGuide.Text = GameText.Wait_for_player;
                    }
                    FlushWindow();
                }
            }
        }

        private void buttonGiveup_Click(object sender, EventArgs e)
        {
            UnloadMatch("You lose");
        }

        /// <summary>
        /// 根据index决定胜负
        /// </summary>
        /// <param name="index"></param>
        private void UnloadMatch(string index)
        {
            //更新UI
            labelGuide.Text = GameText.ResourceManager.GetString(index);
            buttonGiveup.Enabled = false;
            buttonConfirm.Enabled = true;
            comboBoxLevel.Enabled = true;
            FlushWindow();
            // 比赛状态变为不可用

            match.Dispose();
            match = null;

        }

        private void comboBoxLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelAI.Text=comboBoxLevel.Text+"AI";
        }
    }
}
