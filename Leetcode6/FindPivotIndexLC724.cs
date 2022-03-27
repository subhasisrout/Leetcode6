// #PrefixSum

namespace Leetcode
{
    public class FindPivotIndexLC724
    {
        public int PivotIndex(int[] nums)
        {
            int totalSum = 0;
            int leftSum = 0;
            for (int i = 0; i < nums.Length; i++)
                totalSum += nums[i];
            for (int i = 0; i < nums.Length; i++)
            {
                int rightSum = totalSum - leftSum - nums[i]; //leftSum and rightSum do NOT include nums[i]
                if (leftSum == rightSum)
                    return i;

                leftSum += nums[i]; //accumulate as you check.
            }
            return -1;
        }
    }
}
