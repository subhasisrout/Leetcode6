using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Came up with the below solution. Track the global minimum and during each step towards right, either update it or update maxProfit.

namespace Leetcode
{
    public class BestTimeToBuySellStock1LC121
    {
        public int MaxProfit(int[] prices)
        {
            if (prices == null || prices.Length == 0) return 0;

            int maxProfit = 0;
            int globalMin = prices[0];
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] < globalMin)
                {
                    globalMin = prices[i];
                }
                else
                {
                    maxProfit = Math.Max(maxProfit, prices[i] - globalMin);
                }
            }
            return maxProfit;
        }
    }
}
