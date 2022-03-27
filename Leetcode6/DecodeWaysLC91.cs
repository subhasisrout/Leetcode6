using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    //DP - Taken from CS Dojo https://www.youtube.com/watch?v=qli-JCrSwuk
    // Kevin's video is not intuitive
    public class DecodeWaysLC91
    {
        int result = 0;
        public int NumDecodings(string s)
        {
            if (s == null)
                return 0;
            int[] memo = new int[s.Length + 1];
            for (int i = 0; i < memo.Length; i++)
            {
                memo[i] = -1;
            }
            return NumWays(s, s.Length, memo);
        }

        private int NumWays(string s, int k, int[] memo) //k chars from end
        {
            if (k == 0)
                return 1;

            int idx = s.Length - k;
            if (s[idx] == '0')
                return 0;

            if (memo[k] != -1)
                return memo[k];

            result = NumWays(s, k - 1, memo);
            if (k >= 2 && Convert.ToInt32(s.Substring(idx, 2)) <= 26)
                result += NumWays(s, k - 2, memo);
            memo[k] = result;
            return result;
        }
    }
}
