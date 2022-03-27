using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Taken from leetcode solution - approach 3

namespace Leetcode
{
    public class BestTimeToBuySellStock2LC122
    {
        public int MaxProfit(int[] prices)
        {
            int totalProfit = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] > prices[i - 1])
                    totalProfit += prices[i] - prices[i - 1];
            }
            return totalProfit;
        }
    }
}
