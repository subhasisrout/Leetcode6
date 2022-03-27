using System;

// #DP

namespace Leetcode
{
    public class MinimumPathSumLC64
    {
        public int MinPathSum(int[][] grid)
        {
            if (grid.Length == 0 || grid[0].Length == 0)
                return 0;

            int[,] dpArray = new int[grid.Length, grid[0].Length];

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    dpArray[i,j] = grid[i][j];

                    if (i > 0 && j > 0)
                        dpArray[i, j] += Math.Min(dpArray[i - 1, j], dpArray[i, j - 1]);
                    else if (i > 0)
                        dpArray[i, j] += dpArray[i - 1, j];
                    else if (j > 0)
                        dpArray[i, j] += dpArray[i, j - 1];
                }

            }

            return dpArray[grid.Length-1, grid[0].Length-1];
        }
    }
}
