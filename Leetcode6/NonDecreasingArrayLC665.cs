// Inspired from #Neetcode #Array
namespace Leetcode6
{
    public class NonDecreasingArrayLC665
    {
        public bool CheckPossibility(int[] nums)
        {
            int count = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] < nums[i - 1])
                {
                    count++;
                    //either nums[i-1] is set to nums[i] //First preference
                    //or nums[i] to be set to nums[i-1] //Second preference
                    if (i - 1 == 0 || (i - 2 >= 0 && nums[i - 2] <= nums[i]))
                        nums[i - 1] = nums[i];
                    else
                        nums[i] = nums[i - 1];
                }
                if (count >= 2) return false;

            }
            return true;

        }
    }
}
}
