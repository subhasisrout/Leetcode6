using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// #BackTrack

namespace Leetcode
{
    public class UniquePathsIIILC980
    {
        int empty = 1;
        int result;
        public int UniquePathsIII(int[][] grid)
        {
            int startRow = 0;
            int startCol = 0;


            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        startRow = i;
                        startCol = j;
                    }
                    else if (grid[i][j] == 0)
                    {
                        empty++;
                    }
                }
            }
            DFSAndBackTrack(grid, startRow, startCol);
            return result;
        }
        private void DFSAndBackTrack(int[][] grid, int i, int j)
        {
            if (i < 0 || j < 0 || i >= grid.Length || j >= grid[0].Length || grid[i][j] < 0)
                return;

            if (grid[i][j] == 2)
            {
                if (0 == empty) //valid result, only if all blocks are covered.
                {
                    result++;
                }
                return; //return anyway
            }


            empty--;
            grid[i][j] = -2; // This is serving as visited. No separate visited[][] needed.
            DFSAndBackTrack(grid, i + 1, j);
            DFSAndBackTrack(grid, i - 1, j);
            DFSAndBackTrack(grid, i, j + 1);
            DFSAndBackTrack(grid, i, j - 1);
            empty++;
            grid[i][j] = 0;
        }
    }
}
