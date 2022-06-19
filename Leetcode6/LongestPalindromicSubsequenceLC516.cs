// Note this is not substring BUT subsequence, Hence the need for dp
// LongestPalindromicSubStringAE is nonDP

namespace Leetcode6
{
    public class LongestPalindromicSubsequenceLC516
    {
        public int LongestPalindromeSubseq(string s)
        {
            int n = s.Length;
            int[,] dp = new int[n, n]; //dp[i,j] will contain LCSubSeq from index i and j (both inclusive)

            // The key here is to not imagine these are row and col
            // but plain i,j pointers to a string.
            // we start with the smallest string i.e i=n-1
            for (int i = n - 1; i >= 0; i--)
            {
                dp[i, i] = 1; //every single letter character i.e. i == j
                for (int j = i + 1; j < n; j++)
                {
                    if (s[i] == s[j])
                    {
                        dp[i, j] = 2 + dp[i + 1, j - 1];
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i + 1, j], dp[i, j - 1]); //Max of ignoring the left char (i+1) vs ignoring the right char (j-1)
                    }
                }
            }
            return dp[0, n - 1]; //result for the FULL STRING. Hence from 0 to n-1 index.
        }
    }
}
