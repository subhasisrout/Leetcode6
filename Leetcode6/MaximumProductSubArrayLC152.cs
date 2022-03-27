using System;

// #Clever 
// Solution taken from Leetcode discussion  https://leetcode.com/problems/maximum-product-subarray/discuss/183483/JavaC%2B%2BPython-it-can-be-more-simple

/* Explaination
First, if there's no zero in the array, then the subarray with maximum product must start with the first element or end with the last element. 
And therefore, the maximum product must be some prefix product or suffix product. So in this solution, we compute the prefix product A and suffix product B, 
and simply return the maximum of A and B.

What if there are zeroes in the array? Well, we can split the array into several smaller ones. 
That's to say, when the prefix product is 0, we start over and compute prefix profuct from the current element instead. 
And this is exactly what A[i] *= (A[i - 1]) or 1 does

 */


namespace Leetcode
{
    public class MaximumProductSubArrayLC152
    {
        public int MaxProduct(int[] nums)
        {
            int result = Int32.MinValue;
            int l = 0;
            int r = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                l = ((l == 0) ? 1 : l) * nums[i];
                r = ((r == 0) ? 1 : r) * nums[nums.Length - 1 - i];
                result = Math.Max(result, Math.Max(l, r));
            }
            return result;
        }
    }
}
