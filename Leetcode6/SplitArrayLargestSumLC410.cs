// #Binary Search variant of trying all possiblities of answers.
// Similar to Koko Eating Bananas LC875 and MinDaysToMakeMBouquetsLC1482

namespace Leetcode
{
    public class SplitArrayLargestSumLC410
    {
        public int SplitArray(int[] nums, int m)
        {
            int l = 0;
            int r = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                r += nums[i];
                l = Math.Max(l, nums[i]);
            }
            int result = r;

            // Binary Search with left as MAX(array) and right as SUM(array)
            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                if (IsValid(mid))
                {
                    result = mid;
                    r = mid - 1;
                }
                else
                {
                    l = mid + 1;
                }
            }
            return result;

            bool IsValid(int largest)
            {
                int subArrays = 0;
                int currSum = 0;
                for (int i = 0; i < nums.Length; i++)
                {
                    currSum += nums[i];
                    if (currSum > largest)
                    {
                        subArrays++;
                        currSum = nums[i];
                        if (subArrays + 1 > m)
                            return false;
                    }
                }
                return true;
            }

        }
    }
}
