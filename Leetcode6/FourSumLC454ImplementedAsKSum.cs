using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class FourSumLC454ImplementedAsKSum
    {
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            Array.Sort(nums);
            IList<IList<int>> ans = new List<IList<int>>();
            List<int> curr = new List<int>();

            void KSum(int k, int start, int kSumTarget)
            {
                if (k != 2)
                {
                    for (int i = start; i < nums.Length - (k - 1); i++)
                    {
                        if (i > start && nums[i] == nums[i - 1]) continue;

                        curr.Add(nums[i]);
                        KSum(k - 1, i + 1, kSumTarget - nums[i]);
                        curr.RemoveAt(curr.Count - 1);
                    }
                    return;
                }

                int l = start;
                int r = nums.Length - 1;
                while (l < r)
                {
                    if (nums[l] + nums[r] < kSumTarget)
                        l++;
                    else if (nums[l] + nums[r] > kSumTarget)
                        r--;
                    else
                    {
                        List<int> currCopy = new List<int>(curr);
                        currCopy.Add(nums[l]);
                        currCopy.Add(nums[r]);
                        ans.Add(new List<int>(currCopy));
                        while (l < r && nums[l] == nums[l + 1]) l++;
                        l++;
                    }
                }
            }
            KSum(4, 0, target);
            return ans;
        }
    }
}
