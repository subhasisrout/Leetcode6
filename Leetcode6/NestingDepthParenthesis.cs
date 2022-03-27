using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class NestingDepthParenthesis
    {
        public int MaxDepth(string s)
        {
            int currDepth = 0;
            int maxDepth = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    currDepth++;
                    maxDepth = Math.Max(maxDepth, currDepth);
                }
                else if (s[i] == ')')
                    currDepth--;
            }
            return maxDepth;
        }
    }
}
