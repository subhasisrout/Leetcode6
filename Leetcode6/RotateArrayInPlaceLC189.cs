//REMEMBERPATTERN Literally 4 lines
// Try writing and observing.


namespace Leetcode
{
    public class RotateArrayInPlaceLC189
    {
        public void Rotate(int[] nums, int k)
        {
            k = k % nums.Length;
            Reverse(nums, 0, nums.Length - 1);
            Reverse(nums, 0, k - 1);
            Reverse(nums, k, nums.Length - 1);
        }
        private void Reverse(int[] nums, int start, int end)
        {
            int i = start;
            int j = end;
            while (i < j)
            {
                Swap(nums, i, j);
                i++;
                j--;
            }            
        }
        private void Swap(int[] arr, int index1, int index2)
        {
            int tmp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = tmp;
        }



    }
}
