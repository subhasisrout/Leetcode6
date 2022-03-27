using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class ValidPalindromeLC125
    {
        public bool IsPalindrome(string s)
        {
            if (s.Length == 0)
                return true;

            int i = 0;
            int j = s.Length - 1;

            while (i < j)
            {
                while (!Char.IsLetterOrDigit(s[i]))
                    i++;
                while (!Char.IsLetterOrDigit(s[j]))
                    j--;

                if (Char.ToLowerInvariant(s[i]) != Char.ToLowerInvariant(s[j]))
                    return false;
                else
                {
                    i++;
                    j--;
                }
            }
            return true;

        }
    }
}
