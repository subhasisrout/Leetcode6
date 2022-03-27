// Remember slow and fast are NOT slow fast indices, but rather number reffered by the indices
// #RememberPattern
// Explanation in https://www.youtube.com/watch?v=dfIqLxAf-8s
// Other option for O(1) solution is "CHANGING THE ARRAY" by multiplying numbers by -1.

// Actual Floyd algorithm works for linkedlist. We have convert array to linkedlist using the approach3
// at https://leetcode.com/problems/find-the-duplicate-number/solution/


// Yet another approach is cyclic sort. This approach be used in variety of places. Examples
// LC268, LC448, LC287, LC442, LC645, LC41
// Idea taken from https://www.youtube.com/watch?v=JfinxytTYFQ


namespace Leetcode
{
    public class FindDuplicateNumberLC287FloydCycleDetection
    {
        public int FindDuplicate(int[] nums)
        {
            int slow = 0;
            int fast = 0;
            do
            {
                slow = nums[slow];
                fast = nums[nums[fast]];
            }
            while (slow != fast);

            slow = 0;
            // fast is where it met in the last loop

            while (slow != fast)
            {
                slow = nums[slow];
                fast = nums[fast];

            }
            return slow; //or fast as both are same.
        }

        public int FindDuplicate2(int[] nums)
        {

            // do cyclic sort
            int i = 0;
            while (i < nums.Length)
            {
                if (nums[nums[i] - 1] != nums[i])
                    Swap(nums, i, nums[i] - 1);
                else
                    i++;
            }
            return nums[nums.Length - 1];
        }
        private void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
