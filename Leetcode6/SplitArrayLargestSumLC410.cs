using System;

// #Binary Search variant of trying all possiblities of answers.
// Similar to Koko Eating Bananas LC875 and MinDaysToMakeMBouquetsLC1482


namespace Leetcode
{
    public class SplitArrayLargestSumLC410
    {
        public int SplitArray(int[] nums, int m)
        {
            int max = 0;
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                max = Math.Max(nums[i], max);
                sum += nums[i];
            }

            if (m == 1) return sum;

            // binary search
            int start = max;
            int end = sum;

            while (start <= end)
            {
                int mid = start + (end - start) / 2;
                if (IsValid(mid, nums, m))
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }
            return start;
        }

        private bool IsValid(int target, int[] nums, int m)
        {
            int total = 0;
            int count = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                total += nums[i];
                if (total > target)
                {
                    total = nums[i];
                    count++;
                    if (count > m)
                        return false;
                }
            }
            return true;

        }
    }
}
