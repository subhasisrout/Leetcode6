using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class ValidateParenthesisLC20
    {
        public bool IsValid(string str)
        {
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '(' || str[i] == '{' || str[i] == '[')
                    stack.Push(str[i]);
                else
                {
                    if (stack.Count == 0) return false;
                    var lastIn = stack.Pop();
                    if (str[i] == ']' && lastIn != '[')
                        return false;
                    else if (str[i] == '}' && lastIn != '{')
                        return false;
                    else if (str[i] == ')' && lastIn != '(')
                        return false;
                }
            }
            return stack.Count == 0; ;
        }
    }
}
