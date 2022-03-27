using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// #SlidingWindow pattern
// #RememberPattern
// refer MaxConsecutiveOnesIIILC1004

namespace Leetcode
{
    public class MaxConsecutiveOnesLC485
    {
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            int maxConsecutiveOnes = 0;
            int start = 0;
            int zeroCount = 0;

            for (int end = 0; end < nums.Length; end++)
            {
                if (nums[end] == 0)
                    zeroCount++;

                if (zeroCount > 0)
                {
                    if (nums[start] == 0)
                        zeroCount--;

                    start++;
                }

                Console.WriteLine($"{ maxConsecutiveOnes} ----- { end - start + 1}");
                maxConsecutiveOnes = Math.Max(maxConsecutiveOnes, end - start + 1);
                
            }
            return maxConsecutiveOnes;
        }
    }
}
