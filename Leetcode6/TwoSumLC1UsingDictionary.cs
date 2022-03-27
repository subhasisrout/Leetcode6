using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class TwoSumLC1UsingDictionary
    {
        public int[] TwoSum(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
                return null;

            Dictionary<int, int> seenNums = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (seenNums.ContainsKey(target - nums[i]))
                    return new int[] { i, seenNums[target - nums[i]] };
                seenNums[nums[i]] = i;
            }
            return null;
        }
    }
}
