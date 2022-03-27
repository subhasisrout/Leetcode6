using System;

// #LC #Leetcode 45 #Medium #Hard
// There is also a O(N) and constant space solution, but much clever and trickier.
// #RememberPattern

namespace Leetcode
{
    public class MinimumNumberOfJumpsAE
    {
        public static int MinNumberOfJumps(int[] nums)
        {
            int[] jumps = new int[nums.Length];
            jumps[0] = 0;
            for (int i = 1; i < jumps.Length; i++)
                jumps[i] = Int32.MaxValue;

            for (int i = 1; i < nums.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[j] + j >= i)
                        jumps[i] = Math.Min(jumps[i], 1 + jumps[j]);
                }
            }
            return jumps[jumps.Length - 1];
        }
    }
}
