using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class IsSubsequenceLC392
    {
        public bool IsSubsequence(string s, string t)
        {
            if (string.IsNullOrEmpty(s))
                return true;

            int s_index = 0;

            for (int i = 0; i < t.Length; i++)
            {
                if (t[i] == s[s_index])
                {
                    s_index++;
                }

                if (s_index >= s.Length)
                    return true;
            }
            return false;
        }
    }
}
