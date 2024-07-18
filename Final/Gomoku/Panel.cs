using Final.Control;
using IGOEnchi.SmartGameLib;
using IGOEnchi.SmartGameLib.io;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Final.Gomoku
{
    /// <summary>
    /// 定义了五子棋棋盘上的一个点
    /// 由于五子棋棋盘为15x15，故x,y的取值范围均为0~14
    /// </summary>
    public class PanelPoint
    {
        private int _x;
        private int _y;
        public int x
        {
            get => _x;
            set => _x = value switch
            {
                >= 0 and <= 14 => value,
                _ => throw new ArgumentOutOfRangeException("x坐标必须介于0~14之间")
            };
        }
        public int y
        {
            get => _y;
            set => _y = value switch
            {
                >= 0 and <= 14 => value,
                _ => throw new ArgumentOutOfRangeException("y坐标必须介于0~14之间")
            };
        }

        public PanelPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return ((char)(x + 'a')).ToString() + ((char)(y + 'a')).ToString();
        }
    }

    /// <summary>
    /// 定义棋盘上格点的状态
    /// NONE-未放置棋子
    /// BLACK-黑色棋子
    /// WHITE-白色棋子
    /// </summary>
    public enum PointStatus
    {
        NONE,
        BLACK,
        WHITE
    }

    /// <summary>
    /// 15x15的五子棋棋盘
    /// </summary>
    public class Panel
    {
        public PointStatus[][] matrix;
        // 使用sgf格式记录棋谱
        public SgfBuilder recorder;

        // 原图中Block的边长（像素）
        public const int BlockSize = 50;

        public Panel()
        {
            matrix = new PointStatus[15][];
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new PointStatus[15];
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = PointStatus.NONE;
                }
            }
            recorder=new SgfBuilder();
        }

        public Panel(string pb,string pw):this()
        {
            recorder
                .p("PB", pb)
                .Next()
                .p("PW", pw)
                .Next();
        }

        /// <summary>
        /// 试图往该处落子返回的结果
        /// </summary>
        public enum PlaceStatus
        {
            SUCC,
            FAIL,
            WIN//如果放下该棋子后胜利则返回
        }

        /// <summary>
        /// 向棋盘上放置棋子
        /// </summary>
        /// <param name="point">棋盘上格点的坐标表示</param>
        /// <param name="pointStatus">放置是否成功</param>
        /// <returns></returns>
        public PlaceStatus Place(PanelPoint point, PieceColor color)
        {
            // 指定的位置不能放置棋子
            if (Index(point) != PointStatus.NONE)
            {
                return PlaceStatus.FAIL;
            }
            else
            {
                Index(point) = color switch
                {
                    PieceColor.BLACK => PointStatus.BLACK,
                    PieceColor.WHITE => PointStatus.WHITE,
                };

                //在棋谱中记录
                recorder
                    .p(color switch
                    {
                        PieceColor.BLACK => "B",
                        PieceColor.WHITE => "W"
                    }, point.ToString())
                    .Next();
                //胜利则返回WIN
                return CheckWinFrom(point) switch
                {
                    true => PlaceStatus.WIN,
                    false => PlaceStatus.SUCC// 未胜利，但是可以放置在此处
                };
            }
        }

        public ref PointStatus Index(PanelPoint point) { 
            return ref matrix[point.x][point.y];
        }

        /// <summary>
        /// 检测胜利条件
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool CheckWinFrom(PanelPoint point)
        {
            PointStatus baseStatus = matrix[point.x][point.y];
            if (baseStatus == PointStatus.NONE)
                return false;
            // 会出现重复查找，但是开销不大
            for (int i = -1; i <= 1; ++i)
            {
                for (int j = -1; j <= 1; ++j)
                {
                    if (i == 0 && j == 0)
                    {
                        continue;
                    }
                    int count = 0;
                    int x = point.x;
                    int y = point.y;
                    // 从该位置开始寻找
                    while (count < 5 &&
                        x >= 0 && x <= 14 &&
                        y >= 0 && y <= 14)
                    {
                        if (matrix[x][y] != baseStatus)
                        {
                            break;
                        }
                        x += i;
                        y += j;
                        ++count;
                    }
                    --count;
                    x=point.x; y=point.y;
                    // 反向查找，由于count会多算一次，因此count先减去1
                    while (count < 5 &&
                        x >= 0 && x <= 14 &&
                        y >= 0 && y <= 14)
                    {
                        if (matrix[x][y] != baseStatus)
                        {
                            break;
                        }
                        x -= i; y -= j;
                        ++count;
                    }
                    if (count == 5)
                        return true;
                }
            }
            return false;
        }

        public string ExportToSgf()
        {
            using (StringWriter sw = new StringWriter())
            {
                SgfWriter writer = new SgfWriter(sw);
                var tree=recorder.ToSgfTree();
                writer.WriteSgfTree(tree);
                return sw.ToString();
            }
        }

    }
}
