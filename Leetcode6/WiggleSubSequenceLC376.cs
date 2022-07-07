// Inspired from Leetcode solution.
// For intuition refer Leetcode solution animation Linear DP using O(n) time and O(n) space.
// Then from O(n) space -> You will realize you can do with constant space as you only need last updated up and down.
namespace Leetcode6
{
    public class WiggleSubSequenceLC376
    {
        public int WiggleMaxLength(int[] nums)
        {
            int up = 1;
            int down = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > nums[i - 1])
                    up = down + 1;
                else if (nums[i] < nums[i - 1])
                    down = up + 1;
            }
            return Math.Max(up, down);
        }
    }
}
