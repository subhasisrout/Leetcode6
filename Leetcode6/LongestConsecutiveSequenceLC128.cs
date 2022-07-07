// Note unlike LargestRangeAE , this does not give the actual list of numbers. Only count.

namespace Leetcode6
{
    public class LongestConsecutiveSequenceLC128
    {
        public int LongestConsecutive(int[] nums)
        {
            HashSet<int> set = new HashSet<int>(nums);
            int longest = 0;

            foreach (int n in nums)
            {
                if (!set.Contains(n - 1)) //i.e 'n' is the start of seq
                {
                    int length = 0;
                    while (set.Contains(n + length)) //for the first iter in the while loop (n+0 == n), so n will be found and longest will never be 0 (set outside)
                    {
                        length += 1;
                    }
                    longest = Math.Max(longest, length);
                }
            }
            return longest;
        }
    }
}
