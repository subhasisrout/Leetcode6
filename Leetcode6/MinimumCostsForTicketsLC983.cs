using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// #DP
// Excellent explaination and intuition in https://www.youtube.com/watch?v=aUE5EgqZkb0

namespace Leetcode
{
    public class MinimumCostsForTicketsLC983
    {
        public int MincostTickets(int[] days, int[] costs) // days 1,3,4,9,35
        {                                                   
            int maxDate = days[days.Length - 1]; //days are sorted. maxDate = 35
            int[] dp = new int[maxDate + 1]; //dp[] length 36
            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < days.Length; i++)
            {
                set.Add(days[i]); //set of the arr. thats it.
            }

            for (int i = 1; i < dp.Length; i++)
            {
                int c1 = dp[i - 1]; //for first day, i = 1
                int c2 = (i - 7) > 0 ? dp[i - 7] : 0;
                int c3 = (i - 30) > 0 ? dp[i - 30] : 0;
                if (set.Contains(i))
                {
                    dp[i] = Math.Min(c1 + costs[0], Math.Min(c2 + costs[1], c3 + costs[2]));
                }
                else
                {
                    dp[i] = dp[i - 1];
                }
            }
            return dp[dp.Length - 1];
        }
    }
}
