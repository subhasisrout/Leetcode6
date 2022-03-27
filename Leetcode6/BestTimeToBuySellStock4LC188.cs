using System;


//dp[k,j] --- max profit that can be made from i transactions up till j days.

namespace Leetcode
{
    public class BestTimeToBuySellStock4LC188
    {
        public int MaxProfit(int k, int[] prices)
        {
            if (prices == null || prices.Length <= 1) return 0;

            int[,] dp = new int[k + 1, prices.Length];

            // all zeroes for the first column. There can be no profit for a single trading day.
            for (int i = 0; i < dp.GetLength(0); i++)
                dp[i, 0] = 0;

            // all zeroes for the first row. There can be no profit for 0th transaction. k=0.
            for (int j = 0; j < dp.GetLength(1); j++)
                dp[0, j] = 0;


            for (int t = 1; t < dp.GetLength(0); t++)
            {
                int maxProfitThusFar = Int32.MinValue;
                for (int d = 1; d < prices.Length; d++)
                {
                    int profitIfNoTransactionOnjthDay = dp[t, d - 1];

                    maxProfitThusFar = Math.Max(maxProfitThusFar, dp[t - 1, d - 1] - prices[d - 1]); // this line "buying a stock" in day d-1 + profit on day d-1.
                    // prices[d] is added with the assumption that share is sold. so that amount is added to the profit
                    dp[t, d] = Math.Max(profitIfNoTransactionOnjthDay, maxProfitThusFar + prices[d]); // max of (no transaction on jth day, transaction on jth day).
                }
            }
            return dp[dp.GetLength(0) - 1, dp.GetLength(1) - 1];
        }
    }
}
