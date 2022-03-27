using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class SubrectangleQueriesLC1476
    {
        private int[][] rectangle;
        public SubrectangleQueriesLC1476(int[][] rectangle)
        {
            this.rectangle = rectangle;
        }

        public void UpdateSubrectangle(int row1, int col1, int row2, int col2, int newValue)
        {
            for (int i=row1; i<=row2;i++)
            {
                for (int j = col1; j <= col2; j++)
                {
                    rectangle[i][j] = newValue;
                }
            }
        }

        public int GetValue(int row, int col)
        {
            return rectangle[row][col];
        }
    }
}
