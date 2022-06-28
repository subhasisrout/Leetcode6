// #Greedy since only deletion is allowed.
// Check #Leetcode solution for 3 solutions.
namespace Leetcode6
{
    public class MinimumDeletionsToMakeCharFreqUniqueLC1647
    {
        public int MinDeletions(string s)
        {
            int[] freq = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                char ch = s[i];
                freq[ch - 'a'] += 1;
            }
            HashSet<int> seen = new HashSet<int>();
            int delCount = 0;
            for (int i = 0; i < 26; i++)
            {
                while (freq[i] > 0 && seen.Contains(freq[i]))
                {
                    freq[i] -= 1;
                    delCount++;
                }
                seen.Add(freq[i]);
            }
            return delCount;
        }
    }
}
