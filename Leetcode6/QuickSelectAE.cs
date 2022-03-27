// #You could also use a heap of size k

//IGNORE THIS AND REFER KthLargestElementLC215 (#NeetCode) for mind map.
namespace Leetcode
{
    public class QuickSelectAE
    {
        public static int Quickselect(int[] nums, int k)
        {
            QuickSelectHelper(nums, 0, nums.Length - 1, k);
            return nums[k - 1];
        }

        private static void QuickSelectHelper(int[] array, int start, int end, int k)
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
            if (right == k - 1)
                return;
            else if (k - 1 < right)
                QuickSelectHelper(array, start, right - 1, k); // (because at 'right', now is the NEW 'pivot')
            else
                QuickSelectHelper(array, right + 1, end, k);
        }

        private static void Swap(int[] arr, int index1, int index2)
        {
            int tmp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = tmp;
        }
    }
}
