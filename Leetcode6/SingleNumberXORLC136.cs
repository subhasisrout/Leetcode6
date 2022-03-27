using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class SingleNumberXORLC136
    {
        public int SingleNumber(int[] nums)
        {
            //other solution using extra space is to use a hashset
            int result = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                result = result ^ nums[i];
            }
            return result;
        }
    }
}
