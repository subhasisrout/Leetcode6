using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class FindTheDifferenceLC389
    {
        public char FindTheDifference(string s, string t)
        {
            int tCount = 0;
            int sCount = 0;

            for (int i = 0; i < t.Length; i++)
            {
                tCount += t[i] - '0';
            }
            for (int i = 0; i < s.Length; i++)
            {
                sCount += s[i] - '0';
            }

            return (char)('a' + (char)((tCount -sCount) - '0') - 1);

        }
    }
}
