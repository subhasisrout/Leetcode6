using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class MinimumDominoRotationLC1007
    {
        public int MinDominoRotations(int[] A, int[] B)
        {
            int minNumSwaps = Math.Min(NumSwaps(
               A[0], A, B), NumSwaps(B[0], A, B));
            minNumSwaps = Math.Min(minNumSwaps, NumSwaps(A[0], B, A));
            minNumSwaps = Math.Min(minNumSwaps, NumSwaps(B[0], B, A));

            if (minNumSwaps == int.MaxValue)
                return -1;
            return minNumSwaps;

        }

        private int NumSwaps(int v, int[] a, int[] b)
        {
            int numSwaps = 0; 
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != v && b[i] != v)
                    return int.MaxValue;
                else if (a[i] != v && b[i] == v)
                {
                    numSwaps++;
                }
            }
            return numSwaps;
        }
    }
}
