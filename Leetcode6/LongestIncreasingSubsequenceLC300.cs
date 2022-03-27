using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// #LIS . Note this is longest increasing subsequence. There is another variant which is longest increasing subsequence SUM.
// #LC1626

namespace Leetcode
{
    public class LongestIncreasingSubsequenceLC300
    {
        public int LengthOfLIS(int[] nums)
        {
            int[] dp = new int[nums.Length];
            for (int i = 0; i < dp.Length; i++)
                dp[i] = 1; //base case. maxlength at the ith element would always be >= 1.

            for (int i = 1; i < nums.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        dp[i] = Math.Max(dp[j] + 1, dp[i]);
                    }
                }
            }
            return dp.Max();
        }
    }
}
