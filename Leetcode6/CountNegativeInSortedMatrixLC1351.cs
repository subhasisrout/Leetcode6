using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class CountNegativeInSortedMatrixLC1351
    {
        public int CountNegatives(int[][] grid)
        {
            int negativeCount = 0;
            int firstNegativeIndex = -1;
            for (int i = 0; i < grid.Length; i++)
            {
                firstNegativeIndex = BinSearch(grid[i], 0, grid[i].Length - 1);
                if (firstNegativeIndex != -1)
                    negativeCount += (grid[i].Length - firstNegativeIndex);
                else if (firstNegativeIndex == 0) //optimization for not searching anymore down the row as it is sorted downwards too.
                {
                    negativeCount += (grid.Length - i) * (grid[i].Length);
                    break;
                }
            }
            return negativeCount;
        }

        private int BinSearch(int[] nums, int low, int high)
        {
            if (low > high)
                return -1;
            else
            {
                int mid = low + (high - low) / 2;
                if (nums[mid] <= -1 && mid == 0)
                    return mid; //0;
                else if (nums[mid] <= -1 && nums[mid - 1] >= 0)
                    return mid;
                else if (nums[mid] <= -1 && nums[mid - 1] <= -1)
                    return BinSearch(nums, low, mid - 1);
                else //(nums[mid] >= 0)
                    return BinSearch(nums, mid + 1, high);
            }
        }
    }
}
