using System;
using System.Collections.Generic;

//Same as #LC31
//Used #Stack.ToArray()

namespace Leetcode
{
    public class NextGreaterElementIIILC556
    {
        public int NextGreaterElement(int n)
        {
            int[] nums = IntToDigitArray(n);
            if (nums.Length == 1) return -1;
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
                return -1;
            }

            int j = FindSmallestNumIndexInRightWhichIsGreaterThan(nums, i);
            Swap(nums, i - 1, j);
            Array.Reverse(nums, i, nums.Length - i);
            return DigitArrayToInt(nums);

        }
        private int[] IntToDigitArray(int n)
        {
            Stack<int> stack = new Stack<int>();
            while (n > 0)
            {
                int rem = n % 10;
                n = n / 10;
                stack.Push(rem);
            }
            return stack.ToArray();
        }
        private int DigitArrayToInt(int[] digits)
        {
            double n = 0;
            int k = 0;
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                n += digits[i] * Math.Pow(10, k);
                k++;
            }
            if (n > Int32.MaxValue) return -1;
            return Convert.ToInt32(n);
        }
        private int FindSmallestNumIndexInRightWhichIsGreaterThan(int[] nums, int i)
        {
            int smallest = nums[i];
            int smallestIdx = i;
            for (int k = i; k < nums.Length; k++)
            {
                if (nums[k] <= smallest && nums[k] > nums[i - 1])
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
