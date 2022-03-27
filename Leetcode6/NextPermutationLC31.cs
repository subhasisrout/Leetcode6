using System;

// #Array subset Reverse
// Inspired from https://www.geeksforgeeks.org/find-next-greater-number-set-digits/ and Leetcode solution



namespace Leetcode
{
    public class NextPermutationLC31
    {
        public void NextPermutation(int[] nums)
        {
            if (nums.Length == 1) return;
            int i = -1;
            for (int k = nums.Length - 1; k >= 0; k--)
            {
                if (k > 0 && nums[k - 1] < nums[k])
                {
                    i = k;
                    break;
                }
            }

            if (i == -1)
            { //nums array is sorted descending. So next permutation not possible.
                Array.Sort(nums);
                return;
            }

            int j = FindSmallestNumIndexInRightWhichIsGreaterThan(nums, i);
            Swap(nums, i - 1, j);
            Array.Reverse(nums, i, nums.Length - i);

        }
        private int FindSmallestNumIndexInRightWhichIsGreaterThan(int[] nums, int i)
        {
            int smallest = nums[i];
            int smallestIdx = i;
            for (int k = i; k < nums.Length; k++)
            {
                if (nums[k] <= smallest && nums[k] > nums[i - 1]) // "<=" will take care of edge case like [2,3,1,3,3]
                {
                    smallest = nums[k];
                    smallestIdx = k;
                }
            }
            return smallestIdx;
        }
        private void Swap(int[] nums, int i, int j)
        {
            int tmp = nums[i];
            nums[i] = nums[j];
            nums[j] = tmp;
        }
    }
}
