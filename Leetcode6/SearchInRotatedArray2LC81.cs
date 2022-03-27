using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class SearchInRotatedArray2LC81
    {
        public bool Search(int[] nums, int target)
        {
            return BinSearch(nums, 0, nums.Length - 1, target);
        }
        private bool BinSearch(int[] nums, int start, int end, int target)
        {
            while (start <= end) // Note <= EQUAL
            {
                int mid = start + (end - start) / 2;
                if (nums[mid] == target) return true;

                if (nums[start] == nums[mid] && nums[end] == nums[mid]) // Extra block from SearchInRotatedArray
                {
                    start++;
                    end--;
                }
                else if (nums[start] <= nums[mid])
                {
                    if (target >= nums[start] && target < nums[mid])
                    {
                        end = mid - 1;
                    }
                    else
                    {
                        start = mid + 1;
                    }
                }
                else
                {
                    if (target <= nums[end] && target > nums[mid])
                    {
                        start = mid + 1;
                    }
                    else
                    {
                        end = mid - 1;
                    }
                }
            } // end of while loop

            return false;
        }
    }
}
