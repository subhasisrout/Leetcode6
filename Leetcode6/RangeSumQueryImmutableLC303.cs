// #prefixsum #easy #rangesumquery #rangesumquerymutable is tough
// Note Immutable is easy, mutable#LC307 is tough

namespace Leetcode6
{
    public class RangeSumQueryImmutableLC303
    {
        public class NumArray
        {
            int[] prefixSum = null;
            int[] nums = null;

            public NumArray(int[] nums)
            {
                this.nums = nums;
                int n = nums.Length;
                prefixSum = new int[n];
                prefixSum[0] = nums[0];
                for (int i = 1; i < n; i++)
                    prefixSum[i] = prefixSum[i - 1] + nums[i];
            }

            public int SumRange(int left, int right)
            {
                return prefixSum[right] - prefixSum[left] + this.nums[left];
            }
        }
    }
}
