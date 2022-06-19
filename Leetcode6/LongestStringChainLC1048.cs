// #DP
// Inspired from Leetcode discussion - https://leetcode.com/problems/longest-string-chain/discuss/294890/JavaC%2B%2BPython-DP-Solution

namespace Leetcode6
{
    public class LongestStringChainLC1048
    {
        public int LongestStrChain(string[] words)
        {
            Dictionary<string, int> lenMap = new Dictionary<string, int>();
            Array.Sort(words, (a, b) => a.Length - b.Length);
            int result = 0;
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                int best = 0;
                for (int k = 0; k < word.Length; k++)
                {
                    string prev = word.Substring(0, k) + word.Substring(k + 1);
                    if (!lenMap.ContainsKey(prev))
                        best = Math.Max(best, 1);
                    else
                        best = Math.Max(best, lenMap[prev] + 1);
                }
                if (!lenMap.ContainsKey(word))
                    lenMap.Add(word, best);
                result = Math.Max(result, best);
            }
            return result;

        }
    }
}
