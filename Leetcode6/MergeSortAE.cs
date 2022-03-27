using System;
using System.Linq;

// #Easy To Remember
// #This forms the base for many questions and is also important as a standalone question.

namespace Leetcode
{
    public class MergeSortAE
    {
        public static int[] MergeSort(int[] nums)
        {
            if (nums.Length <= 1)
                return nums;

            int mid = nums.Length / 2;
            int[] leftHalf = nums.Take(mid).ToArray();
            int[] rightHalf = nums.Skip(mid).ToArray();
            return Merge2SortedArray(MergeSort(leftHalf), MergeSort(rightHalf));
        }

        private static int[] Merge2SortedArray(int[] arr1, int[] arr2)
        {
            int[] finalSortedArr = new int[arr1.Length + arr2.Length];
            int i = 0;
            int j = 0;
            int k = 0;
            while (i < arr1.Length && j < arr2.Length)
            {
                if (arr1[i] <= arr2[j])
                {
                    finalSortedArr[k] = arr1[i];
                    i++;
                }
                else
                {
                    finalSortedArr[k] = arr2[j];
                    j++;
                }
                k++; // index for final sorted array. Needs to be increased for all cases.
            }

            // Either i is out of bound or j is out of bounds or both
            while (i < arr1.Length)
            {
                finalSortedArr[k] = arr1[i];
                i++;
                k++;
            }
            while (j < arr2.Length)
            {
                finalSortedArr[k] = arr2[j];
                j++;
                k++;
            }
            return finalSortedArr;
        }
    }
}
