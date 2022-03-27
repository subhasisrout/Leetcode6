using System;
using System.Collections.Generic;

// #Maths  - Alice needs to maximize a1 + b1.
// a1 - Maximize because Alice gets it.
// b1 - Maximize because Bob does not get it. So - a1 + b1.

// Also look at LC877 - its just "return true;".

namespace Leetcode
{
    public class StoneGame6LC1686
    {
        public int StoneGameVI(int[] aliceValues, int[] bobValues)
        {
            int n = aliceValues.Length;
            int[][] sums = new int[n][];
            for (int i = 0; i < n; i++)
            {
                sums[i] = new int[] { aliceValues[i] + bobValues[i], aliceValues[i], bobValues[i] };
            }

            Array.Sort(sums, new SumComparer());

            int a = 0; //for aiice points
            int b = 0; //for bob points

            for (int i = 0; i < n; i++)
            {
                if (i % 2 == 0)
                    a += sums[i][1];
                else
                    b += sums[i][2];
            }

            if (a > b)
                return 1;
            else if (a < b)
                return -1;
            return 0;
        }

        private class SumComparer : IComparer<int[]>
        {
            public int Compare(int[] x, int[] y)
            {
                return y[0].CompareTo(x[0]); //0th index contain the sum
            }
        }
    }
}
