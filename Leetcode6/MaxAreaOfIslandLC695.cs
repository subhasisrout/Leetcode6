using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// #RememberPattern

namespace Leetcode
{
    public class MaxAreaOfIslandLC695
    {
        public int MaxAreaOfIsland(int[][] grid)
        {
            int max = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        max = Math.Max(max,DFS(grid, i, j));
                    }

                }
            }
            return max;
        }

        private int DFS(int[][] grid, int i, int j)
        {
            if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length || grid[i][j] == 0)
                return 0;

            int count = 1;
            grid[i][j] = 0;
            count += DFS(grid, i, j + 1);
            count += DFS(grid, i, j - 1);
            count += DFS(grid, i - 1, j);
            count += DFS(grid, i + 1, j);
            return count;
        }
    }
}
