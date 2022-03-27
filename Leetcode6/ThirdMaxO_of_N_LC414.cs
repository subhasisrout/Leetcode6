using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class ThirdMaxO_of_N_LC414
    {
        public int ThirdMax(int[] nums)
        {
            int max = int.MinValue; //nonEmpty array, so max will always be there
            for (int i = 0; i < nums.Length; i++)
                max = Math.Max(max, nums[i]);

            int? secondMax = null;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == max)
                    continue;
                if (secondMax != null)
                    secondMax = Math.Max(secondMax.Value, nums[i]);
                else
                    secondMax = nums[i];

            }

            int? thirdMax = null;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == max || (secondMax != null && nums[i] == secondMax.Value))
                    continue;
                if (thirdMax != null)
                    thirdMax = Math.Max(thirdMax.Value, nums[i]);
                else
                    thirdMax = nums[i];
            }

            if (thirdMax != null)
                return thirdMax.Value;
            else if (max != int.MinValue)
                return max;
            else
                return secondMax.Value;
        }
    }
}
