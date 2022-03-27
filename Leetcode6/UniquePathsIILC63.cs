using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// #DP
namespace Leetcode
{
    public class UniquePathsIILC63
    {
        Dictionary<string, int> memo = new Dictionary<string, int>();
        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            int m = obstacleGrid.Length;
            int n = obstacleGrid[0].Length;

            int[,] dpArray = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                if (obstacleGrid[i][0] == 0)
                    dpArray[i, 0] = 1;
                else
                    break;
            }
            for (int i = 0; i < n; i++)
            {
                if (obstacleGrid[0][i] == 0)
                    dpArray[0, i] = 1;
                else
                    break;
            }

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    if (obstacleGrid[i][j] == 0)
                        dpArray[i, j] = dpArray[i, j - 1] + dpArray[i - 1, j];
                    else
                        dpArray[i, j] = 0;
                }
            }
            return dpArray[m - 1, n - 1];
        }

        // Below is the top-down approach (memoization approach).
        // Inspired from Kunal Kushwaha. Link - https://www.youtube.com/watch?v=zg5v2rlV1tM
        public int UniquePathsWithObstaclesTopDown(int[][] obstacleGrid)
        {
            return DFS(obstacleGrid, 0, 0);
        }

        private int DFS(int[][] obstacleGrid, int i, int j)
        {
            if (memo.ContainsKey(i + "-" + j))
                return memo[i + "-" + j];

            if (i >= obstacleGrid.Length || j >= obstacleGrid[0].Length || obstacleGrid[i][j] == 1)
            {
                memo.Add(i + "-" + j, 0);
                return 0;
            }

            int totalCount = 0;
            //no need to add < 0 as we are only incrementing in DFS recursion. Check comment/base condition of LC62
            if (i == obstacleGrid.Length - 1 && j == obstacleGrid[0].Length - 1) 
                return 1;


            totalCount += DFS(obstacleGrid, i + 1, j);
            totalCount += DFS(obstacleGrid, i, j + 1);
            memo.Add(i + "-" + j, totalCount);
            return totalCount;
        }

    }
}
