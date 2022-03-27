using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Look nowhere else. Only refer https://www.youtube.com/watch?v=q6IEA26hvXc

namespace Leetcode
{
    public class MedianOfTwoSortedArrays
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int[] A = null; //one with small length, on where binary search would be run
            int[] B = null; //one with big length
            if (nums1.Length < nums2.Length)
            {
                A = nums1;
                B = nums2;
            }
            else
            {
                A = nums2;
                B = nums1;
            }

            int total = A.Length + B.Length;
            int half = total / 2;

            // for binary search on A
            int l = 0;
            int r = A.Length - 1;

            int i = -1; // for A
            int j = -1; // for B

            while (true)
            {
                i = Convert.ToInt32(Math.Floor((l + r) * 1.0 / 2)); // needed for 0 and -1.. (i+j)/2 is 0. You want it to be -1.
                j = half - i - 2; // -2 because of i and j are indices.

                // below 4 lines are out-of-bounds checks
                int aLeft = (i >= 0) ? A[i] : Int32.MinValue;
                int aRight = (i + 1 < A.Length) ? A[i + 1] : Int32.MaxValue;
                int bLeft = (j >= 0) ? B[j] : Int32.MinValue;
                int bRight = (j + 1 < B.Length) ? B[j + 1] : Int32.MaxValue;

                // if valid partition
                if (aLeft <= bRight && bLeft <= aRight)
                {
                    if (total % 2 == 1) //odd
                    {
                        return Math.Min(aRight, bRight);
                    }
                    else //even
                    {
                        return (Math.Max(aLeft, bLeft) + Math.Min(aRight, bRight)) / 2.0; // note 2.0
                    }
                }
                else if (aLeft > bRight)
                {
                    r = i - 1;
                }
                else // implicit bLeft > aRight
                {
                    l = i + 1;
                }
            }
        }

    }
}
