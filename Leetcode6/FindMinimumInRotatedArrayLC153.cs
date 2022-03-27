using System;

// #Rotated #Recurive #Self solution by me from scratch
// Write the iterative solution for the same.

namespace Leetcode
{
    public class FindMinimumInRotatedArrayLC153
    {
        public int FindMin(int[] nums)
        {
            if (nums.Length == 1) return nums[0];

            int[] result = new int[1];
            result[0] = Int32.MaxValue;
            FindMinHelper(nums, 0, nums.Length - 1, result);
            return result[0];
        }

        private void FindMinHelper(int[] nums, int l, int r, int[] result)
        {
            if (l == r) //one element in the array
            {
                result[0] = Math.Min(result[0], nums[l]);
            }
            else if (r == l + 1) //two element in the array
            {
                int localMin = Math.Min(nums[l], nums[r]);
                result[0] = Math.Min(localMin, result[0]);
            }
            else if (nums[l] < nums[r]) // the half which is sorted
            {
                int localMin = nums[l];
                result[0] = Math.Min(localMin, result[0]);
            }
            else // // the half which contains the pivot
            {
                int mid = l + (r - l) / 2;
                FindMinHelper(nums, l, mid, result);
                FindMinHelper(nums, mid + 1, r, result);
            }
        }
    }
}
