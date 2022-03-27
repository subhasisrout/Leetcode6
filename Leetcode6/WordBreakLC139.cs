using System.Collections.Generic;

// Excellent intuition from Pepcoding https://www.youtube.com/watch?v=2NaaM_z_Jig
// #DP dp[i] contains the number of sentences that can be formed.
// for a given 'i', check if the suffixes are present in the dictionary.

namespace Leetcode
{
    public class WordBreakLC139
    {
        public bool WordBreak(string s, IList<string> wordDict)
        {
            HashSet<string> set = new HashSet<string>();
            foreach (var str in wordDict)
            {
                set.Add(str);
            }

            int[] dp = new int[s.Length];

            for (int i = 0; i < dp.Length; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    string wordToCheck = s.Substring(j, i - j + 1);
                    if (set.Contains(wordToCheck))
                    {
                        if (j > 0)
                        {
                            dp[i] += dp[j - 1];
                        }
                        else
                        {
                            dp[i] = 1;
                        }
                    }
                }
            }
            return dp[dp.Length - 1] > 0;
        
        }
    }
}
