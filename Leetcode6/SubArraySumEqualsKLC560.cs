using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class SubArraySumEqualsKLC560
    {
        public int SubarraySum(int[] nums, int k)
        {
            int[] presum = new int[nums.Length + 1];

            for (int i = 1; i <= nums.Length; i++)
            {
                presum[i] = presum[i - 1] + nums[i - 1];
            }

            int count = 0;
            for (int i = 0; i < presum.Length; i++)
            {
                for (int j = i + 1; j < presum.Length; j++)
                {
                    if (presum[j] - presum[i] == k)
                        count++;
                }

            }
            return count;
        }

            public int SubarraySumLowPerf(int[] nums, int k)
        {
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int subTotal = 0;
                int j = i;
                while (j < nums.Length)
                {
                    subTotal += nums[j];
                    j++;
                    if (subTotal == k)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
