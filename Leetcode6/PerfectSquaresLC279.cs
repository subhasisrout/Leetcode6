using System;

// For visualization/intuition, refer pepcoding at - https://www.youtube.com/watch?v=aZuQXkO0-XA
namespace Leetcode
{
    public class PerfectSquaresLC279
    {
        public int NumSquares(int n)
        {
            int[] dp = new int[n + 1];
            dp[0] = 0;
            dp[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                dp[i] = Int32.MaxValue;
                for (int j = 1; j * j <= i; j++)
                {
                    int rem = i - (j * j);
                    dp[i] = Math.Min(dp[i], dp[rem] + 1);
                }
            }

            return dp[n];
        }
    }
}
