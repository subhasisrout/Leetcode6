// Exactly same as #LCS #Clever
// #RememberPattern of #LCS

namespace Leetcode6
{
    public class DeleteOperationFor2StringsLC583
    {
        public int MinDistance(string word1, string word2)
        {
            int m = word1.Length;
            int n = word2.Length;
            int[,] dp = new int[m + 1, n + 1];
            for (int i = 0; i < m + 1; i++)
            {
                for (int j = 0; j < n + 1; j++)
                {
                    if (i == 0 || j == 0)
                        continue;
                    if (word1[i - 1] == word2[j - 1])
                        dp[i, j] = 1 + dp[i - 1, j - 1];
                    else
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }

            return m + n - (2 * dp[m, n]);
        }
    }
}
