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
        public FormHistory()
        {
            sgfContent = "";
            comment = "";
            InitializeComponent();
        }

        public FormHistory(string sgfContent,string comment):this()
        {
            this.comment = comment;
            this.sgfContent = sgfContent;
        }

        private void FormHistory_Load(object sender, EventArgs e)
        {
            UpdateWebView();
            this.Invalidate();
            this.Update();
            DrawPiecesFromSgf();
        }

        /// <summary>
        /// 根据sgfContent更新棋盘
        /// </summary>
        private void DrawPiecesFromSgf()
        {
            // 计算缩放程度，从而获取要绘制棋子的位置
            // 在设计器中，我尽量保证了pictureBoxPanel为正方形，因此可以较为简单地计算
            double scaleWidth = (double)pictureBoxPanel.Size.Width / GamePictures.Panel.Width;
            double scaleHeight =(double)pictureBoxPanel.Size.Height / GamePictures.Panel.Height;
            double scale=Math.Min(scaleWidth,scaleHeight);

            // 首先计算在图像中，棋子到图像左上方的距离（像素）
            // 棋盘四周的留白大小（像素）
            const int padding = 40;
            // 该函数用于计算以像素表示的坐标位置
            var PanelPointToPixel = (int x) => (int)((padding + x * Gomoku.Panel.BlockSize - Piece.PieceSize/2)*scale);

            using(MemoryStream stream=new MemoryStream(Encoding.UTF8.GetBytes(sgfContent)))
            {
                var tree=SgfReader.LoadFromStream(stream);
                // 将节点向前移动
                var moveForward = () => tree = tree.ChildNodes[0];
                // 第一个节点为空节点，跳过
                moveForward();
                // 首先移动到第一手棋的位置
                while (tree.Properties.Count>0 && tree.Properties[0].Name!="B")
                {
                    moveForward();
                }
                while(tree.Properties.Count>0)
                {
                    // 形如ab的坐标简略表示
                    string posAbbr = tree.Properties[0].Value;
                    // 转化成具体的坐标
                    var point = new Point
                        (
                        x:PanelPointToPixel(posAbbr[0] - 'a')
                         +(int)(pictureBoxPanel.Width-GamePictures.Panel.Width*scale)/2,
                        y:PanelPointToPixel(posAbbr[1] - 'a')
                         +(int)(pictureBoxPanel.Height-GamePictures.Panel.Height*scale)/2
                        );

                    // 计算出坐标后传递给负责绘图的函数
                    DrawPiecesFromPanelPoint(tree.Properties[0].Name switch
                    {
                        "B"=>PieceColor.BLACK,
                        "W"=>PieceColor.WHITE
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
        private void DrawPiecesFromPanelPoint(PieceColor color,Point point)
        {
            var piece = new Piece(color);
            piece.Location = point;
            pictureBoxPanel.Controls.Add(piece);
        }

        /// <summary>
        /// 给定comment（它通常是markdown格式的字符串），用来更新WebView控件
        /// </summary>
        public async void UpdateWebView()
        {
            var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
            // 将Markdown转化为HTML
            var document = Markdown.ToHtml(comment, pipeline);
            await webViewComment.EnsureCoreWebView2Async();
            webViewComment.CoreWebView2.NavigateToString(document);
        }
    }
}
