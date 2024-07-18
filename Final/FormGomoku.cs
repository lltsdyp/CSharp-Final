using Final.Control;
using Final.Database;
using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Final
{
    public partial class FormGomoku : Form
    {
        private QwenClient qwen;
        private Gomoku.Match? match;
        private SgfStore database;
        private CancellationTokenSource tokenSource;
        private List<Task> AItasks;
        // 格子的边长
        private const int BlockSize = Gomoku.Panel.BlockSize;
        // 判定区域的边长，判定区域的大小暂定为30x30
        private static int ValidSize = GamePictures.BlackPiece.Width;

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
            qwen = new QwenClient(QwenToken.APIKey);
            database = new SgfStore();
            tokenSource = new CancellationTokenSource();
            AItasks = new List<Task>();
            InitializeComponent();
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
        /// 将对局结果交给AI分析
        /// </summary>
        /// <param name="sgf">对局结果的sgf字符串</param>
        /// <param name="winnerColor">胜方的棋子颜色</param>
        public async Task AIAnalysisAsync(string sgf, PieceColor winnerColor)
        {
            // 获取AI的评论
            string comment = await qwen.sendPrompt(string
                .Format(QwenToken.ContactAI, sgf,
                winnerColor switch
                {
                    PieceColor.BLACK => "黑",
                    PieceColor.WHITE => "白"
                }));
            // 存入数据库
            await database.StoreSgfAsync(sgf, comment);
        }

        /// <summary>
        /// 根据index决定胜负
        /// </summary>
        /// <param name="index"></param>
        private async void UnloadMatch(string index)
        {
            //更新UI
            labelGuide.Text = GameText.ResourceManager.GetString(index);
            buttonGiveup.Enabled = false;
            buttonConfirm.Enabled = true;
            comboBoxLevel.Enabled = true;
            textBoxPlayerName.Enabled = true;
            listBoxHistory.Enabled = true;
            buttonOpen.Enabled = true;
            buttonExport.Enabled = true;
            FlushWindow();

            // 比赛状态变为不可用
            string sgf = match.Panel.ExportToSgf();
            qwen.CleanMessage();
            match.Dispose();
            match = null;

            // AI操作所需时间较长，创建线程以避免阻塞当前应用
            await Task.Run(async () => 
            {
                Task task = AIAnalysisAsync(sgf, index switch
                {
                    "You win" => PieceColor.BLACK,
                    "You lose" => PieceColor.WHITE
                });
                AItasks.Add(task);
                await task;
            }, tokenSource.Token);

            await UpdateListBox();
        }

        /// <summary>
        /// 强制重新绘制窗体，在回合转换时很有用
        /// </summary>
        private void FlushWindow()
        {
            this.Invalidate();
            this.Update();
        }

        private async Task UpdateListBox()
        {
            comboBoxLevel.SelectedIndex = 0;
            listBoxHistory.DataSource = await database.GetNameListAsync();
            listBoxHistory.SelectionMode = SelectionMode.One;
            FlushWindow();
        }
        private async void FormGobang_Load(object sender, EventArgs e)
        {
            labelGuide.Text = GameText.Wait_for_start;
            comboBoxLevel.Items.AddRange(new string[]
            {
                "简单",
                "中等",
                "困难",
                "噩梦"
            });

            await UpdateListBox();
            //无记录则不可进行下列操作
            if (listBoxHistory.Items.Count == 0)
            {
                buttonExport.Enabled = false;
                buttonOpen.Enabled = false;
            }
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

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            // 创建对局
            string playername = textBoxPlayerName.Text;
            match = new Gomoku.Match(new Gomoku.Player(playername), AIPrograms.ResourceManager
                .GetString(comboBoxLevel.Text) + "main.exe");
            match.AIManager.GameStart();

            // 更新UI
            pictureBoxGobangPanel.Controls.Clear();
            labelPlayerName.Text = playername;
            buttonGiveup.Enabled = true;
            buttonConfirm.Enabled = false;
            comboBoxLevel.Enabled = false;
            textBoxPlayerName.Enabled = false;
            listBoxHistory.Enabled = false;
            buttonOpen.Enabled = false;
            buttonExport.Enabled = false;
            labelGuide.Text = GameText.Wait_for_player;
        }

        private void comboBoxLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelAI.Text = comboBoxLevel.Text + "AI";
        }

        private void listBoxHistory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // 双击listBox与单击“打开”按钮的响应是一样的
            buttonOpen_Click(sender, e);
        }

        private void FormGomoku_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (match != null)
            {
                match.AIManager.Dispose();
            }
            // 等待AI进程结束
            Task.Run(() =>
            {
                var dialog = new FormWaiting();
                dialog.ShowDialog();
            });
            Task.WaitAll(AItasks.ToArray());
        }

        private async void buttonExport_Click(object sender, EventArgs e)
        {
            string selectedGame = listBoxHistory.SelectedItem.ToString();
            // 选择保存路径
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.FileName = listBoxHistory.SelectedItem.ToString();
            saveFileDialog.Filter = "Smart Game Format files (*.sgf)|*.sgf|All files (*.*)|*.*";

            // 选定
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                FileStream output = new FileStream(filePath, FileMode.Create);
                (string sgfContent, string comment) = (await database.LoadGameHistoryAsync(selectedGame)).Value;

                using (var sw = new StreamWriter(output))
                {
                    //Length-3删掉'\r'，'\n'和')'
                    string rawString =
                        sgfContent[..(sgfContent.Length - 3)] + $"C[{comment}])";
                    //删除所有空格字符以保持紧凑
                    sw.Write(
                        Regex.Replace(rawString, @"\s+", ""));
                }
            }
        }

        private async void buttonOpen_Click(object sender, EventArgs e)
        {
            if (listBoxHistory.Items.Count == 0)
                return;
            // 从数据库中加载历史对局
            string selectedGame = listBoxHistory.Text;
            (string sgfContent, string comment) = (await database.LoadGameHistoryAsync(selectedGame)).Value;

            // 显示历史对局
            var historyAnalysis = new FormHistory(sgfContent, comment);
            historyAnalysis.ShowDialog();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonOpen_Click(sender, e);
        }

        private async void RenameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string oldName=listBoxHistory.Text;
            var renameDialog=new FormRename(oldName);
            var result=renameDialog.ShowDialog();
            if (result==DialogResult.OK)
            {
                string newName = renameDialog.NewName;
                await database.RenameRecordAsync(oldName, newName);
                await UpdateListBox();
            }
        }

        private async void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await database.RemoveGameHistory(listBoxHistory.Text);
            await UpdateListBox();
        }
    }
}
