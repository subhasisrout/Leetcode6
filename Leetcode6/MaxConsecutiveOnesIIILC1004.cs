using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// #SlidingWindow pattern
// #RememberPattern
// Explaination good in https://www.youtube.com/watch?v=TAMLsfGiyOg

namespace Leetcode
{
    public class MaxConsecutiveOnesIIILC1004
    {
        public int LongestOnes(int[] A, int K)
        {
            if (A == null || A.Length == 0)
                return 0;

            int start = 0;
            int maxConsecutiveOnes = 0;
            int zeroCount = 0;

            for (int end = 0; end < A.Length; end++)
            {
                if (A[end] == 0)
                    zeroCount++;

                while (zeroCount > K)
                {
                    if (A[start] == 0)
                    {
                        zeroCount--;    //1 zero will be out of the window
                    }
                    start++;            //slide the start of window
                }

                maxConsecutiveOnes = Math.Max(maxConsecutiveOnes, end - start + 1);
            }
            return maxConsecutiveOnes;
        }
    }
}
