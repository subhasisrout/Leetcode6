using System;

// #AE
// Easier and more intuitive version in Algo Expert

namespace Leetcode
{
    public class SortedSquaresLC977
    {
        public int[] SortedSquares(int[] A)
        {
            if (A == null || A.Length == 0)
                return null;

            if (A.Length == 1)
                return new int[] { A[0] * A[0] };

            int i = 0;
            int j = 0;
            while (A[j] < 0)
            {
                j++;
            }
            if (j > 0)
                i = j - 1;

            int[] result = new int[A.Length];

            if ( j == 0)
            {
                for (int k = 0; k < A.Length; k++)
                {
                    result[k] = A[k] * A[k];
                }
                return result;
            }

            int counter = 0;
            while (j < A.Length && i >= 0)
            {
                if (Math.Abs(A[i]) < Math.Abs(A[j]))
                {
                    result[counter++] = A[i] * A[i];
                    i--;
                }
                else
                {
                    result[counter++] = A[j] * A[j];
                    j++;
                }
            }

            while (j < A.Length)
            {
                result[counter++] = A[j] * A[j];
                j++;
            }

            while (i >= 0)
            {
                result[counter++] = A[i] * A[i];
                i--;
            }


            return result;
        }


        //Below is from AlgoExpert (much easier to understand)
        public int[] SortedSquaredArray(int[] nums)
        {
            int[] result = new int[nums.Length];
            int small = 0;
            int big = nums.Length - 1;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (Math.Abs(nums[small]) >= Math.Abs(nums[big]))
                {
                    result[i] = nums[small] * nums[small];
                    small++;
                }
                else
                {
                    result[i] = nums[big] * nums[big];
                    big--;
                }
            }
            return result;

        }
    }
}
