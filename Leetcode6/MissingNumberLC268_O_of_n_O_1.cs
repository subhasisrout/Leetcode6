
// Yet another approach is cyclic sort. This approach be used in variety of places. Examples
// LC268, LC448, LC287, LC442, LC645, LC41
// Idea taken from https://www.youtube.com/watch?v=JfinxytTYFQ


namespace Leetcode
{
    public class MissingNumberLC268_O_of_n_O_1
    {
        public int MissingNumber(int[] nums)
        {
            int presentSum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                presentSum += nums[i];
            }

            int totalSum = (nums.Length * (nums.Length + 1)) / 2;
            return totalSum - presentSum;
        }

        public int MissingNumber2(int[] nums)
        {

            // do cyclic sort
            int i = 0;
            while (i < nums.Length)
            {
                int currNum = nums[i];
                if (currNum != nums.Length && i != currNum)
                    Swap(nums, i, currNum);
                else
                    i++;
            }

            //go through the sorted arr
            for (int k = 0; k < nums.Length; k++)
            {
                if (k != nums[k])
                    return k;
            }
            return nums.Length;

        }
        private void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
