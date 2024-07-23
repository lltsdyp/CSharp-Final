using Final.Control;
using Final.Gomoku;
using IGOEnchi.SmartGameLib;
using IGOEnchi.SmartGameLib.models;
using Markdig;
using System.Text;

namespace Final
{
    public partial class FormHistory : Form
    {
        private string sgfContent;
        private string comment;
        private double scale
        {
            get
            {
                // 计算缩放程度，从而获取要绘制棋子的位置
                double scaleWidth = (double)pictureBoxPanel.Size.Width / GamePictures.Panel.Width;
                double scaleHeight = (double)pictureBoxPanel.Size.Height / GamePictures.Panel.Height;
                return Math.Min(scaleWidth, scaleHeight);
            }
        }
        private const int padding = 40;
        public FormHistory()
        {
            sgfContent = "";
            comment = "";
            InitializeComponent();
        }

        public FormHistory(string name, string sgfContent, string comment) : this()
        {
            this.Text = "对弈记录 - " + name;
            this.comment = comment;
            this.sgfContent = sgfContent;
        }

        private void FormHistory_Load(object sender, EventArgs e)
        {
            Piece _ = new Piece(PieceColor.BLACK);
            UpdateWebView();
            this.Invalidate();
            this.Update();
            DrawPiecesFromSgf();
            AxesInit();
        }

        /// <summary>
        /// 根据sgfContent更新棋盘
        /// </summary>
        private void DrawPiecesFromSgf()
        {
            // 首先计算在图像中，棋子到图像左上方的距离（像素）
            // 棋盘四周的留白大小（像素）
            // 该函数用于计算以像素表示的坐标位置
            var PanelPointToPixel = (int x) => (int)((padding + x * Gomoku.Panel.BlockSize - Piece.PieceSize / 2) * scale);

            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(sgfContent)))
            {
                var tree = SgfReader.LoadFromStream(stream);
                // 将节点向前移动
                var moveForward = () => tree = tree.ChildNodes[0];
                // 第一个节点为空节点，跳过
                moveForward();
                // 首先移动到第一手棋的位置
                while (tree.Properties.Count > 0 && tree.Properties[0].Name != "B")
                {
                    moveForward();
                }
                while (tree.Properties.Count > 0)
                {
                    // 形如ab的坐标简略表示
                    string posAbbr = tree.Properties[0].Value;
                    // 转化成具体的坐标
                    var point = new Point
                        (
                        x: PanelPointToPixel(posAbbr[0] - 'a')
                         + (int)(pictureBoxPanel.Width - GamePictures.Panel.Width * scale) / 2,
                        y: PanelPointToPixel(posAbbr[1] - 'a')
                         + (int)(pictureBoxPanel.Height - GamePictures.Panel.Height * scale) / 2
                        );

                    // 计算出坐标后传递给负责绘图的函数
                    DrawPiecesFromPanelPoint(tree.Properties[0].Name switch
                    {
                        "B" => PieceColor.BLACK,
                        "W" => PieceColor.WHITE
                    },
                    point);

                    moveForward();
                }
            }
        }

        /// <summary>
        /// 在棋盘上的指定位置绘制一枚棋子
        /// </summary>
        /// <param name="color">棋子的颜色</param>
        /// <param name="point">棋子在棋盘上的坐标</param>
        private void DrawPiecesFromPanelPoint(PieceColor color, Point point)
        {
            var piece = new Piece(color);
            piece.Location = point;
            pictureBoxPanel.Controls.Add(piece);
        }

        /// <summary>
        /// 给定comment（它通常是markdown格式的字符串），用来更新WebView控件
        /// </summary>
        private async void UpdateWebView()
        {
            var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
            // 将Markdown转化为HTML
            var document = Markdown.ToHtml(comment, pipeline);
            await webViewComment.EnsureCoreWebView2Async();
            webViewComment.CoreWebView2.NavigateToString(document);
        }

        private void AxesInit()
        {
            tableLayoutPanelVertical.BackColor
                = tableLayoutPanelHorizonal.BackColor
                = ColorTranslator.FromHtml("#CCBD5A");
            // 将tableLayout移位
            int offset = (int)(scale * (padding - Gomoku.Panel.BlockSize / 2));
            var hLocation = tableLayoutPanelHorizonal.Location;
            tableLayoutPanelHorizonal.Location =
                new Point(
                    hLocation.X + offset,
                    hLocation.Y
                    );
            var vLocation = tableLayoutPanelVertical.Location;
            tableLayoutPanelVertical.Location =
                new Point(
                    vLocation.X,
                    vLocation.Y + offset
                    );

            // 添加label
            for (int i = 0; i < tableLayoutPanelHorizonal.ColumnCount; ++i)
            {
                tableLayoutPanelHorizonal.ColumnStyles[i] =
                    new ColumnStyle(SizeType.Absolute, 50.0f * (float)scale);
                tableLayoutPanelHorizonal.Controls
                    .Add(CreateLabel(i), i, 0);
            }
            for (int i = 0; i < tableLayoutPanelVertical.RowCount; ++i)
            {
                tableLayoutPanelVertical.RowStyles[i] =
                    new RowStyle(SizeType.Absolute, 50.0f * (float)scale);
                tableLayoutPanelVertical.Controls
                    .Add(CreateLabel(i), 0, i);
            }
            tableLayoutPanelHorizonal.Visible
                = tableLayoutPanelVertical.Visible
                = false;
        }

        private Label CreateLabel(int i)
        {
            Label label = new Label();
            label.Text = ((char)(i + 'a')).ToString();
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Font = new Font("Consolas", 10.0f, FontStyle.Bold);
            label.BackColor = ColorTranslator.FromHtml("#CCBD5A");
            label.ForeColor = Color.Black;
            label.Dock = DockStyle.Fill;
            label.AutoSize = true;

            return label;
        }

        private void pictureBoxPanel_MouseEnter(object sender, EventArgs e)
        {
            tableLayoutPanelHorizonal.Visible
                = tableLayoutPanelVertical.Visible
                = true;
        }

        private void pictureBoxPanel_MouseLeave(object sender, EventArgs e)
        {
            // 设置判定的ClientRectangle比pictureBoxPanel自身的ClientRectangle小一点，便于检测
            Rectangle checkRectangle = new Rectangle
            {
                X = this.pictureBoxPanel.ClientRectangle.X+ 40
                    + (this.pictureBoxPanel.Width - this.pictureBoxPanel.Height) / 2,
                Y = this.pictureBoxPanel.ClientRectangle.Y+40,
                Width = this.pictureBoxPanel.ClientRectangle.Height - 40,
                Height = this.pictureBoxPanel.ClientRectangle.Height - 40
            };
            var _location = pictureBoxPanel.PointToClient(Cursor.Position);
            // 仍在控件内，不触发事件处理
            if (_location != Point.Empty &&
                checkRectangle.Contains(_location))
            {
                return;
            }
            tableLayoutPanelHorizonal.Visible
                = tableLayoutPanelVertical.Visible
                = false;
        }
    }
}
