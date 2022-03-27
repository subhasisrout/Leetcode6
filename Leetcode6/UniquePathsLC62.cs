using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// #DP
namespace Leetcode
{
    public class UniquePathsLC62
    {
        Dictionary<string, int> memo = new Dictionary<string, int>();
        public int UniquePaths(int m, int n)
        {
            int[,] dpArray = new int[m, n];
            for (int i = 0; i < m; i++)
            {
                dpArray[i, 0] = 1;
            }
            for (int i = 0; i < n; i++)
            {
                dpArray[0, i] = 1;
            }

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    dpArray[i, j] = dpArray[i, j - 1] + dpArray[i - 1, j];
                }
            }
            return dpArray[m - 1, n - 1];
        }

        // Below is the top-down approach (memoization approach).
        // Inspired from Kunal Kushwaha. Link - https://www.youtube.com/watch?v=zg5v2rlV1tM
        public int UniquePathsTopDown(int m, int n)
        {
            return DFS(m, n, 0, 0);
        }
        private int DFS(int m, int n, int i, int j)
        {
            if (memo.ContainsKey(i + "-" + j))
                return memo[i + "-" + j];

            int totalCount = 0;
            //no need to add < 0 as we are only incrementing in DFS recursion. Also to make it work with i == m-1 && j == n-1,
            //you need to add another base condition if (i >= m || j >= n) return 0;
            if (i == m - 1 || j == n - 1) 
                return 1;


            totalCount += DFS(m, n, i + 1, j);
            totalCount += DFS(m, n, i, j + 1);
            memo.Add(i + "-" + j, totalCount);
            return totalCount;
        }

    }
}
