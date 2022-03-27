using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class CountServersThatCommunicateLC1267
    {
        public int CountServers(int[][] grid)
        {
            int totalServers = 0;
            int isolatedServers = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        totalServers++;
                        grid[i][j] = 2;
                        if (!IsThereAnyOtherServerInTheRow(grid, i) && !IsThereAnyOtherServerInTheCol(grid, j))
                            isolatedServers++;
                        grid[i][j] = 1;
                    }
                }

            }
            return totalServers - isolatedServers;
        }

        private bool IsThereAnyOtherServerInTheRow(int[][] grid, int i)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                if (grid[i][j] == 1)
                    return true;
            }
            return false;
        }

        private bool IsThereAnyOtherServerInTheCol(int[][] grid, int j)
        {
            for (int i = 0; i < grid.Length; i++)
            {
                if (grid[i][j] == 1)
                    return true;
            }
            return false;
        }
    }
}
