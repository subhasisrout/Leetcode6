using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// #2D Array
// #MaxOfEachRowAndCol
// Similar to MatrixLuckyNumberLC1380 but there the result is in a HashSet.

namespace Leetcode
{
    public class MaxIncreaseToKeepCitySkylineLC807
    {
        public int MaxIncreaseKeepingSkyline(int[][] grid)
        {
            List<int> maxRows = new List<int>();
            List<int> maxCols = new List<int>();
            int result = 0;

            // Below loop is to find maxValue for each row
            for (int i = 0; i < grid.Length; i++)
            {
                maxRows.Add(grid[i].Max());
            }

            // Below loop is to find maxValue for each col
            // This pattern can be useful elsewhere.
            for (int j = 0; j < grid.Length; j++)
            {
                int maxColValue = int.MinValue;
                for (int i = 0; i < grid[j].Length; i++)
                {
                    maxColValue = Math.Max(grid[i][j], maxColValue);
                }
                maxCols.Add(maxColValue);
            }

            // BELOW IS A MORE ELEGANT AND FAST WAY OF FINDING MAX'S OF ALL ROWS AND COLS
            // TAKEN FROM LEETCODE SOLUTION
            //var maxI = new int[grid.Length];
            //var maxJ = new int[grid[0].Length];
            //for (int i = 0; i < grid.Length; i++)
            //{
            //    for (int j = 0; j < grid.Length; j++)
            //    {
            //        if (maxI[i] < grid[i][j])
            //            maxI[i] = grid[i][j];
            //        if (maxJ[j] < grid[i][j])
            //            maxJ[j] = grid[i][j];

            //    }
            //}

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    int localMaxRowVal = maxRows[i];
                    int localMaxColVal = maxCols[j];
                    int localMinOfBothMax = Math.Min(localMaxColVal, localMaxRowVal);
                    result += (localMinOfBothMax - grid[i][j]);
                }

            }

            return result;


        }
    }
}
