using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Gobang
{
    /// <summary>
    /// 15x15的五子棋棋盘
    /// </summary>
    public class Panel
    {
        public int[][] matrix;

        public Panel()
        {
            matrix = new int[15][];
            for(int i=0;i<matrix.Length; i++)
            {
                matrix[i] = new int[15];
            }
        }

    }
}
