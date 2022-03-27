using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Looks like there are a variety of questions around this logic.
//#Leetcode #LC503
//#RememberPattern
//Excellent explaination from pepcoding for one of its variety (Next greater element on right) 
// instead of being circular - https://www.youtube.com/watch?v=rSf9vPtKcmI
// #AlgoExpert #AE second solution uses above in addition of making it circular.
// The tip in #AE for circular array of iterating  (2*len) mod len is GREAT.

namespace Leetcode
{
    public class NextGreaterElementAE
    {
        public int[] NextGreaterElement(int[] nums)
        {
            int[] result = new int[nums.Length];
            for (int i = 0; i < result.Length; i++)
                result[i] = -1;

            Stack<int> stack = new Stack<int>();
            
            // General formula shared in PepCoding video
            // Pop, Update Result, Push currentVal
            // -,a,+
            for (int i = nums.Length * 2 - 1; i >= 0; i--) //Trick for traversing array twice.
            {
                int idx = i % nums.Length; //Trick for traversing array twice.
                while (stack.Count > 0 && stack.Peek() <= nums[idx]) // pop the small (or equal) elements
                {
                    stack.Pop();
                }

                if (stack.Count > 0)
                    result[idx] = stack.Peek();

                stack.Push(nums[idx]);
            }


            return result;
        }
    }
}
