//#LC5 #Leetcode Runs in O(n^2)
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class LongestPalindromicSubStringAE
    {
        public static string LongestPalindromicSubstring(string s)
        {
            string longestPalindrome = string.Empty;
            for (int i = 0; i < s.Length; i++)
            {
                string tempStr = GetPalindromeSubstringAt(i, s);
                if (tempStr.Length > longestPalindrome.Length)
                    longestPalindrome = tempStr;
                tempStr = GetPalindromeSubstringAt(i, s, true);
                if (tempStr.Length > longestPalindrome.Length)
                    longestPalindrome = tempStr;
            }
            return longestPalindrome;
        }

        private static string GetPalindromeSubstringAt(int i, string str, bool isPivotInBetween2Letters = false)
        {
            if (!isPivotInBetween2Letters)
            {
                int l = i - 1;
                int r = i + 1;
                string currSubStr = str[i].ToString();
                bool inLoop = false;
                while (l >= 0 && r <= str.Length - 1 && str[l] == str[r])
                {
                    //currSubStr = str.Substring(l, r - l + 1); instead of doing this inside loop, moved it to Line 41,42
                    inLoop = true;
                    l--;
                    r++;
                }
                if (inLoop)
                    currSubStr = str.Substring(l + 1, r - l - 1);
                return currSubStr;
            }
            else
            {
                int l = i - 1;
                int r = i;
                string currSubStr = "";
                bool inLoop = false;
                while (l >= 0 && r <= str.Length - 1 && str[l] == str[r])
                {
                    //currSubStr = str.Substring(l, r - l + 1);
                    inLoop = true;
                    l--;
                    r++;
                }
                if (inLoop)
                    currSubStr = str.Substring(l + 1, r - l - 1);
                return currSubStr;
            }
        }
    }
}
