using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// #DFS #Graph
namespace Leetcode
{
    public class NumberOfIslandsLC200
    {
        public int NumIslands(char[][] grid)
        {
            int count = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    int islandSize = DFS(grid, i, j);
                    if (islandSize > 0)
                        count++;
                }

            }
            return count;
        }

        private int DFS(char[][] grid, int i, int j)
        {
            if (i < 0 || i >= grid.Length || j < 0 || j >= grid[i].Length || grid[i][j] == '0')
                return 0;

            int count = 1;
            grid[i][j] = '0';
            count += DFS(grid, i, j + 1);
            count += DFS(grid, i, j - 1);
            count += DFS(grid, i - 1, j);
            count += DFS(grid, i + 1, j);
            return count;
        }
    }
}
