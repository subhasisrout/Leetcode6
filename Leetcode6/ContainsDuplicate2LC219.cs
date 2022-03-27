using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class ContainsDuplicate2LC219
    {
        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0)
                return false;

            for (int i = 0; i < nums.Length; i++)
            {
                int j = i + 1;
                while (j - i <= k && j <= nums.Length - 1)
                {
                    if (nums[i] == nums[j])
                        return true;
                    else
                        j++;
                }
            }
            return false;
        }
    }
}
