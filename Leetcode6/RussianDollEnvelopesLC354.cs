// #LIS #LongestIncreasingSubsequence #IComparer #LISUsingNLogN #LC300

// #TODO - Absorb intuition of LISNLogN (Special binary search variant with edge case)

namespace Leetcode6
{
    public class RussianDollEnvelopesLC354
    {
        public int MaxEnvelopes(int[][] envelopes)
        {
            Array.Sort(envelopes, new Comparer());
            return LengthOfLIS(envelopes);
        }
        public int LengthOfLIS(int[][] nums)
        {
            int len = 0;
            int[] dp = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                int l = 0;
                int r = len;
                while (l < r)
                {
                    int mid = l + (r - l) / 2;
                    if (dp[mid] < nums[i][1]) l = mid + 1;
                    else r = mid;

                }
                dp[l] = nums[i][1];
                if (l == len)
                    len++;
            }

            return len;

        }
        class Comparer : IComparer<int[]>
        {
            public int Compare(int[] x, int[] y)
            {
                if (x[0] != y[0])
                    return x[0].CompareTo(y[0]);
                else
                    return y[1].CompareTo(x[1]);
            }
        }

    }
}
