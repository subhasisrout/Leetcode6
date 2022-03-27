// #Similar to the thought process required for rain water trapping (TrappingRainWaterLC42)
// I am keeping 2 separate arrays for left and right and one iteration for product
// This can be optimized by keeping just to left and combining the (right + result) in 1 iteration.
namespace Leetcode
{
    public class ArrayOfProductsExceptSelfLC234AE
    {
        public int[] ProductExceptSelf(int[] nums)
        {
            int[] productOfAllNumsLeftOfIndex = new int[nums.Length];
            //int[] productOfAllNumsRightOfIndex = new int[nums.Length];
            int[] result = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                if (i == 0)
                    productOfAllNumsLeftOfIndex[i] = 1;
                else
                    productOfAllNumsLeftOfIndex[i] = productOfAllNumsLeftOfIndex[i - 1] * nums[i - 1];
            }

            var productOfAllRightNumsSoFar = 1;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (i == nums.Length - 1)
                    result[i] = 1 * productOfAllNumsLeftOfIndex[i];
                else
                {
                    productOfAllRightNumsSoFar = productOfAllRightNumsSoFar * nums[i + 1];
                    result[i] = productOfAllRightNumsSoFar * productOfAllNumsLeftOfIndex[i];
                }
            }

            //for (int i = 0; i < nums.Length; i++)
            //{
            //    result[i] = productOfAllNumsLeftOfIndex[i] * productOfAllNumsRightOfIndex[i];
            //}

            return result;
        }
    }
}
