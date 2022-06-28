// Beatifully explained in https://www.youtube.com/watch?v=WMsWPz-KZoo
namespace Leetcode6
{
    public class MinimumDeletionsToMakeArrayBeautifulLC2216
    {
        public int MinDeletion(int[] nums)
        {
            int cnt = 0;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                //(i-cnt) will make sure that index evaluation is always happening on updated array (after removal)
                //Note - the key idea is to scan from left and remove the first left offending element.
                if ((i - cnt) % 2 == 0 && nums[i] == nums[i + 1])
                    cnt++;
            }
            if ((nums.Length - cnt) % 2 != 0) return ++cnt; //after all removals done, if the array length is odd
            return cnt;
        }
    }
}
