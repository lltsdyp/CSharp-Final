using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Final.Control
{
    public enum PieceColor
    {
        WHITE,
        BLACK
    }
    internal class Piece : PictureBox
    {
        private readonly PieceColor color;
        private static Image? black;
        private static Image? white;
        // 棋子图片的边长
        private static int pieceSize;
        public static int PieceSize
        {
            get
            {
                return pieceSize;
            }
        }
        public Piece(PieceColor color):base()
        {
            // 首次使用需初始化
            if (black == null || white == null)
            {
                black = GamePictures.BlackPiece;
                white = GamePictures.WhitePiece;
                pieceSize = black!.Size.Width;
            }
            this.Width= pieceSize;
            this.Height= pieceSize;
            this.DoubleBuffered = true;
            this.BackColor=Color.Transparent;
            this.ForeColor= Color.Transparent;
            this.Anchor = AnchorStyles.None;
            this.color = color;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            switch (this.color)
            {
                case PieceColor.BLACK:
                    pe.Graphics.DrawImage(black!, new Point(0, 0));
                    break;
                case PieceColor.WHITE:
                    pe.Graphics.DrawImage(white!, new Point(0, 0));
                    break;
            }
        }
    }
}
