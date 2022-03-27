using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class FindPivotInShiftedSortedArray
    {
        public int FindPivot(int[] nums)
        {
            return FindPivotHelper(nums, 0, nums.Length - 1);
        }

        public int FindPivotHelper(int[] nums, int low, int high)
        {
            int mid = low + (high - low) / 2;

            if (mid < high && nums[mid] > nums[mid + 1])
                return mid;

            if (mid > low && nums[mid] < nums[mid - 1])
                return mid - 1;

            if (nums[low] >= nums[mid])
                return FindPivotHelper(nums, low, mid - 1);

            return FindPivotHelper(nums, mid + 1, high);

        }
    }
}
