using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// #RememberPattern

namespace Leetcode
{
    public class MajorityElementLC169_O_of_n_BoyerMooreAlgo
    {
        public int MajorityElement(int[] nums)
        {
            int majority = nums[0];
            int count = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == majority)
                {
                    count++;
                }
                else
                {
                    count--;
                }
                if (count == 0)
                {
                    majority = nums[i];
                    count++; //start count from 1;
                }
            }
            return majority;
        }
    }
}
