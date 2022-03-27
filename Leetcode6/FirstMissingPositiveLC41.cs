using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// approach used is cyclic sort. This approach be used in variety of places. Examples
// LC268, LC448, LC287, LC442, LC645, LC41
// Idea taken from https://www.youtube.com/watch?v=JfinxytTYFQ

namespace Leetcode
{
    public class FirstMissingPositiveLC41
    {
        public int FirstMissingPositive(int[] nums)
        {

            // do cyclic sort
            int i = 0;
            while (i < nums.Length)
            {
                if (nums[i] >= 1 && nums[i] < nums.Length && nums[nums[i] - 1] != nums[i])
                    Swap(nums, i, nums[i] - 1);
                else
                    i++;
            }

            // loop through
            for (int k = 0; k < nums.Length; k++)
            {
                if (nums[k] != k + 1)
                    return (k + 1);
            }

            return nums.Length + 1;// case when arr is [1,2,3] or just [1]
        }
        private void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
