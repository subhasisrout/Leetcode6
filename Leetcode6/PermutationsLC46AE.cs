using System;
using System.Collections.Generic;

// #AE
// PermutationsLC46 is more generic and can be applied in Permuatation-II as well. Learn that.

// 1,2,3 after for loop runs 3 times. i == j == 0. NO-OP.
// Now j == 1
//

namespace Leetcode
{
    public class PermutationsLC46AE
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();            
            PermuteHelper(0,nums,result);
            return result;
        }

        private void PermuteHelper(int i, int[] nums, IList<IList<int>> result)
        {
            if (i == nums.Length - 1)
                result.Add(new List<int>(nums));
            else
                for (int j = i; j < nums.Length; j++)
                {
                    this.Swap(nums, i, j);
                    this.PermuteHelper(i + 1, nums, result);
                    this.Swap(nums, i, j);
                }
        }

        private void Swap(int[] nums, int i, int j)
        {
            int tmp = nums[i];
            nums[i] = nums[j];
            nums[j] = tmp;
        }
    }
}
