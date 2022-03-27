// #Similar question from AlgoExpert - you dont need to maintain the 
// order of other elements. To do that, you can use 2 pointers (i pointing to 0)
// and j (pointing to length - 1). i++ and j-- accordingly.

// Neetcode approach is intuitive. Check below.

namespace Leetcode
{
    public class MoveZeroesLC283
    {
        public void MoveZeroes(int[] nums)
        {
            int index = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                    nums[index++] = nums[i];
            }

            for (int i = index; i < nums.Length; i++)
            {
                nums[i] = 0;
            }
        }

        // Another approach from #Neetcode. More intuitive maintaining 2 pointer left and right
        // left for tracking nonZeroes and right for iterating through the array.
        // This is effectively "paritioning the array to zeros and non-zeros"
        public void MoveZeroes2(int[] nums)
        {
            int l = 0; //pointer for nonZero. So always has to start with 0.
            int r = 0; // for iteration

            while (r < nums.Length)
            {
                if (nums[r] != 0)
                {
                    Swap(nums, l, r);
                    l++; //next available position
                }
                r++;
            }
        }
        private void Swap(int[] nums, int i, int j)
        {
            int tmp = nums[i];
            nums[i] = nums[j];
            nums[j] = tmp;
        }

    }
}
