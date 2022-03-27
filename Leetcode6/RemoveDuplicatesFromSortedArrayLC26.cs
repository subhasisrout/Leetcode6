using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class RemoveDuplicatesFromSortedArrayLC26
    {
        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0)
                return 0;

            int i = 0;
            int j = 0;

            while (j < nums.Length - 1)
            {
                while (nums[j] == nums[i] && j < nums.Length - 1)
                    j++;

                if (j > 0 && nums[j] != nums[j - 1])
                {
                    nums[i + 1] = nums[j];
                    i++;
                }
            }
            return i + 1;
        }
    }
}
