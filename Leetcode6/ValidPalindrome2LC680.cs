using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class ValidPalindrome2LC680
    {
        public bool ValidPalindrome(string s)
        {
            int i = 0;
            int j = s.Length - 1;

            while (i < j)
            {
                if (s[i] != s[j])
                {
                    return IsValidPalindrome(s, i + 1, j) || IsValidPalindrome(s, i, j - 1);
                }
                i++;
                j--;
            }
            return true;

        }

        private bool IsValidPalindrome(string s, int u, int v)
        {
            while (u < v)
            {
                if (s[u++] != s[v--])
                    return false;
            }
            return true;
        }
    }
}
