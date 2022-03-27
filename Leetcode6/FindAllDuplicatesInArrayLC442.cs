using System;
using System.Collections.Generic;

// Yet another approach is cyclic sort. This approach be used in variety of places. Examples
// LC268, LC448, LC287, LC442, LC645, LC41
// Idea taken from https://www.youtube.com/watch?v=JfinxytTYFQ

namespace Leetcode
{
    public class FindAllDuplicatesInArrayLC442
    {
        public IList<int> FindDuplicates(int[] nums)
        {
            IList<int> result = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int currIdxAbs = Math.Abs(nums[i]);
                if (nums[currIdxAbs - 1] < 0)
                    result.Add(currIdxAbs);
                else
                    nums[currIdxAbs - 1] = nums[currIdxAbs - 1] * -1;
            }
            return result;
        }

        public IList<int> FindDuplicates2(int[] nums)
        {
            IList<int> result = new List<int>();

            // do cyclic sort
            int i = 0;
            while (i < nums.Length)
            {
                if (nums[nums[i] - 1] != nums[i])
                    Swap(nums, i, nums[i] - 1);
                else
                    i++;
            }

            //loop through the cyclic sorted array
            for (int k = 0; k < nums.Length; k++)
            {
                if (k != nums[k] - 1)
                    result.Add(nums[k]);
            }

            return result;
        }
        private void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
