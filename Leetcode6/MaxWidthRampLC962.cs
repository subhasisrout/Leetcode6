// #TODO Absorb intuition
// #Looks like a pattern

using System;
using System.Collections.Generic;

namespace Leetcode
{
    public class MaxWidthRampLC962
    {
        public int MaxWidthRamp(int[] A)
        {
            int n = A.Length;
            int[] B = new int[n];
            for (int i = 0; i < A.Length; ++i)
            {
                B[i] = i;
            }
            Array.Sort(B, new IndexPositionValueComparer(A));

            int ans = 0;
            int m = n;
            for (int i = 0; i < B.Length; i++)
            {
                ans = Math.Max(ans, B[i] - m);
                m = Math.Min(m, B[i]);
            }
            return ans;
        }
    }
    public class IndexPositionValueComparer : IComparer<int>
    {
        private int[] A;
        public IndexPositionValueComparer(int[] aValues)
        {
            A = aValues;
        }
        public int Compare(int x, int y)
        {
            if (A[x] != A[y])
                return A[x].CompareTo(A[y]);
            return x.CompareTo(y);
        }
    }
}
