using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// #DP
namespace Leetcode
{
    public class HouseRobberLC198
    {
        public int Rob(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;

            if (nums.Length == 1)
                return nums[0];

            if (nums.Length == 2)
                return Math.Max(nums[0], nums[1]);

            int[] dpArray = new int[nums.Length];

            dpArray[0] = nums[0];
            dpArray[1] = Math.Max(nums[0], nums[1]);

            //for the third house, you have to decide - should i rob the third + first house OR should i rob the second house.

            //that is exactly what is happening in the line inside the loop. put i=2 (for third house) and verify.
            for (int i = 2; i < nums.Length; i++)
            {
                dpArray[i] = Math.Max(nums[i] + dpArray[i - 2], dpArray[i - 1]);
            }

            return dpArray[nums.Length - 1];
        }
    }

}
