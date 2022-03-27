using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//try this code with abc2[d]. you will understand the logic.

namespace Leetcode
{
    public class DecodeStringLC394
    {
        public string DecodeString(string s)
        {
            Stack<string> interimResultStack = new Stack<string>();
            Stack<int> countStack = new Stack<int>();
            String result = "";
            int idx = 0;
            while (idx < s.Length)
            {
                // 4 cases - number (multiple digits), [, ], letter
                // idx is increased in each of cases in their block
                if (char.IsDigit(s[idx]))
                {
                    int count = 0;
                    while (idx < s.Length && char.IsDigit(s[idx]))
                    {
                        count = 10 * count + (s[idx] - '0');
                        idx++;
                    }
                    countStack.Push(count);
                }
                else if (s[idx] == '[')
                {
                    interimResultStack.Push(result);
                    result = "";
                    idx++;
                }
                else if (s[idx] == ']') //try this code with abc2[d]. you will understand the logic.
                {
                    StringBuilder temp = new StringBuilder(interimResultStack.Pop());
                    int times = countStack.Pop();
                    for (int i = 0; i < times; i++)
                        temp.Append(result);

                    result = temp.ToString();
                    idx++;
                }
                else
                {
                    result += s[idx++];
                }
            }
            return result;
        }
    }
}
