
using System;
using System.Linq;

namespace Leetcode
{
    public class HouseRobberLC213
    {
        public int Rob(int[] nums)
        {
            if (nums.Length == 1) return nums[0];
            return Math.Max(RobHelper(0, nums.Length - 2, nums), RobHelper(1, nums.Length - 1, nums));
        }
        private int RobHelper(int startIdx, int endIdx, int[] nums)
        {
            int n = endIdx - startIdx + 1;
            if (n == 1) return nums[startIdx];
            int[] dp = new int[n];
            dp[0] = nums[startIdx];
            dp[1] = Math.Max(nums[startIdx], nums[startIdx + 1]);
            for (int i = startIdx + 2; i <= endIdx; i++)
            {
                int idx = (startIdx == 1) ? i - 1 : i; //hack for the second with startIdx = 1. It messes up the dp Array.
                dp[idx] = Math.Max(dp[idx - 1], nums[i] + dp[idx - 2]);
            }
            return dp[n - 1];

        }

        // Below method without HELPER is MORE INTUITIVE
        public int Rob2(int[] nums)
        {
            if (nums.Length <= 2) return nums.Max();
            int[] dp = new int[nums.Length - 1];
            dp[0] = nums[0];
            dp[1] = Math.Max(nums[0], nums[1]);
            // 0 to secondlast
            for (int i = 2; i < nums.Length - 1; i++)
            {
                dp[i] = Math.Max(dp[i - 1], dp[i - 2] + nums[i]);
            }
            int ans1 = dp[dp.Length - 1];


            //1 to last.. Try to write the num[] and dp[] and visualize
            dp = new int[nums.Length - 1];
            dp[0] = nums[1];
            dp[1] = Math.Max(nums[2], nums[1]);
            for (int i = 3; i < nums.Length; i++)
            {
                dp[i - 1] = Math.Max(dp[i - 2], dp[i - 3] + nums[i]); // note now its dp[i-1], dp[i-2], dp[i-3] because 'i' is for nums (not dp) and its 1 ahead.
            }

            int ans2 = dp[dp.Length - 1];

            return Math.Max(ans1, ans2);
        }

    }
}
