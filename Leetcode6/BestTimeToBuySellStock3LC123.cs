using System;

// Taken from pepcoding. Quite intuitive explaination. https://www.youtube.com/watch?v=wuzTpONbd-0

namespace Leetcode
{
    public class BestTimeToBuySellStock3LC123
    {
        public int MaxProfit(int[] prices)
        {

            //left to right pass - Selling in a specific day and bought at a min price before in the left.
            int maxProfitIfSoldTodayOrBefore = 0;
            int minBuyingPrice = prices[0];
            int[] dpl = new int[prices.Length];

            for (int i = 1; i < prices.Length; i++)
            {
                minBuyingPrice = Math.Min(minBuyingPrice, prices[i]);
                maxProfitIfSoldTodayOrBefore = Math.Max(maxProfitIfSoldTodayOrBefore, prices[i] - minBuyingPrice);
                dpl[i] = maxProfitIfSoldTodayOrBefore;
            }


            //right to left pass - Buying in a specific day and selling at a max price after in the right.
            int maxProfitIfBoughtTodayOrAfter = 0;
            int maxSellingPrice = prices[prices.Length - 1];
            int[] dpr = new int[prices.Length];

            for (int i = prices.Length - 2; i >= 0; i--)
            {
                maxSellingPrice = Math.Max(maxSellingPrice, prices[i]);
                maxProfitIfBoughtTodayOrAfter = Math.Max(maxProfitIfBoughtTodayOrAfter, maxSellingPrice - prices[i]);
                dpr[i] = maxProfitIfBoughtTodayOrAfter;
            }


            // check max of dpl and dpr
            int result = 0;
            for (int i = 0; i < dpl.Length; i++)
            {
                result = Math.Max(result, dpl[i] + dpr[i]);
            }

            return result;
        }
    }
}
