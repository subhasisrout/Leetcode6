using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// #SlidingWindow
// #RememberPattern
// Leetcode solution is very intuitive. Check the concept of "DesirableWord".
// Using the leetcode concept and intuition, I wrote the below code myself.

namespace Leetcode
{
    public class MinimumWindowSubstringLC76
    {
        public string MinWindow(string s, string t)
        {
            Dictionary<char, int> tMap = new Dictionary<char, int>();
            for (int i = 0; i < t.Length; i++)
            {
                if (tMap.ContainsKey(t[i]))
                    tMap[t[i]] = tMap[t[i]] + 1;
                else
                    tMap.Add(t[i], 1);
            }

            int l = 0;
            int r = 0;
            int minSubstringLen = Int32.MaxValue;
            int finalL = 0;
            int finalR = 0;
            bool foundMin = false;

            Dictionary<char, int> windowCounts = new Dictionary<char, int>();
            while (r < s.Length)
            {
                //Update windowCounts (4 lines below)
                if (windowCounts.ContainsKey(s[r]))
                    windowCounts[s[r]] += 1;
                else
                    windowCounts.Add(s[r], 1);

                while (l <= r && IsStringDesirable(s, t, l, r, tMap, windowCounts))
                {
                    if (r - l + 1 < minSubstringLen)
                    {
                        minSubstringLen = r - l + 1;
                        finalL = l;
                        finalR = r;
                        foundMin = true;
                    }
                    windowCounts[s[l]] -= 1; //Update windowCounts (1 line only)
                    l++;
                }
                r++;
            }
            if (foundMin)
                return s.Substring(finalL, finalR - finalL + 1);
            return "";
        }

        private bool IsStringDesirable(string s, string t, int l, int r, Dictionary<char, int> tMap, Dictionary<char, int> windowCounts)
        {
            if (r - l + 1 < t.Length) return false;

            foreach (char key in tMap.Keys)
            {
                if (windowCounts.ContainsKey(key) && windowCounts[key] >= tMap[key])
                    continue;
                else
                    return false;
            }
            return true;

        }
    }
}
