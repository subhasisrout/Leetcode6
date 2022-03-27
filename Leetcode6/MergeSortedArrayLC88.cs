using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// #SlightTwist
// Here you scan from right to left. i.e. Find the larget element and put it in the end.
// The reason is - we cannot use extra space. nums1 has the capacity for m+n elements.

namespace Leetcode
{
    public class MergeSortedArrayLC88
    {
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            if (n == 0)
                return;
            if (m == 0)
            {
                for (int k = 0; k < n; k++)
                {
                    nums1[k] = nums2[k];
                }
                return;
            }

            int i = m - 1;
            int j = n - 1;
            int tail = m + n - 1;
            while (i >= 0 && j >= 0)
            {
                if (nums1[i] > nums2[j])
                {
                    //put nums1[i] in nums1[tail], reduce i, reduce tail
                    nums1[tail] = nums1[i];
                    i--;
                    tail--;
                }
                else
                {
                    //put nums2[j] in nums1[tail], reduce j, reduce tail
                    nums1[tail] = nums2[j];
                    j--;
                    tail--;
                }
            }

            //either i<0 or i<0
            if (i < 0)
            {
                while (j >= 0)
                {
                    nums1[tail] = nums2[j];
                    j--;
                    tail--;
                }
            }
            else
            {
                //i part is already sorted in nums1
            }
        }
    }
}
