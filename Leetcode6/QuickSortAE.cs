// #Also has application in QuickSelect (to find kth smallest/largest number in linear time)

namespace Leetcode
{
    public class QuickSortAE
    {
        public static int[] QuickSort(int[] nums)
        {
            QuickSortHelper(nums, 0, nums.Length - 1);
            return nums;
        }

        private static void QuickSortHelper(int[] array, int start, int end)
        {
            if (end <= start)
                return;
            int pivot = start;
            int left = start + 1;
            int right = end;

            while (left <= right)
            {
                if (array[left] > array[pivot] && array[right] < array[pivot])
                    Swap(array, left, right);
                else if (array[left] <= array[pivot])
                    left++;
                else if (array[right] >= array[pivot])
                    right--;
            }
            Swap(array, pivot, right);
            QuickSortHelper(array, start, right - 1); // (because at 'right', now is the NEW 'pivot')
            QuickSortHelper(array, right + 1, end);
            // For better space complexity, The sequence of the above 2 recursion calls should be such that the the smaller subarray is called first.
            // Below is what I got from AE
            // bool isLeftSubArraySmaller = right - 1 - start < end - (right + 1)
            // if (isLeftSubArraySmaller), keep the above sequence, else switch it.
        }

        private static void Swap(int[] arr, int index1, int index2)
        {
            int tmp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = tmp;
        }
    }
}
