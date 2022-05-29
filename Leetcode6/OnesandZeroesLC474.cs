// Inspired from https://leetcode.com/problems/ones-and-zeroes/discuss/95807/0-1-knapsack-detailed-explanation.
// #RememberPattern #Knapsack #01Knapsack #multidimensionalarray #3darray #int[,,]
namespace Leetcode6
{
    public class OnesandZeroesLC474
    {
        public int FindMaxForm(string[] strs, int m, int n)
        {
            int l = strs.Length;
            int[,,] dp = new int[l + 1, m + 1, n + 1];
            int[] nums = null;

            for (int i = 0; i < l + 1; i++)
            {
                nums = new int[2];
                if (i > 0)
                    SetNums(strs[i - 1]);
                for (int j = 0; j < m + 1; j++)
                {
                    for (int k = 0; k < n + 1; k++)
                    {
                        if (i == 0)
                            dp[i, j, k] = 0;
                        else if (nums[0] <= j && nums[1] <= k)
                            dp[i, j, k] = Math.Max(dp[i - 1, j, k], 1 + dp[i - 1, j - nums[0], k - nums[1]]);
                        else
                            dp[i, j, k] = dp[i - 1, j, k];
                    }
                }
            }
            return dp[l, m, n];

            void SetNums(string word)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i] == '0')
                        nums[0]++;
                    else
                        nums[1]++;
                }
            }
        }
    }
}
