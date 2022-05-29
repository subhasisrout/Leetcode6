
// Inspired from Leetcode solution.

namespace Leetcode6
{
    public class LongestValidParenthesesLC32
    {
        public int LongestValidParentheses(string s)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(-1); // consider case "())" ====> 1-(-1) = 2 or plain case "()" ===> 1-(-1)
            int maxValidLen = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    stack.Push(i);
                }
                else
                {
                    stack.Pop();
                    if (stack.Count == 0)
                    {
                        stack.Push(i);
                    }
                    else //Consider case "(((())" ===> Stack is not empty but maxValidLen will be updated 2 (4-2) then 4 (5-1).
                    {
                        maxValidLen = Math.Max(maxValidLen, i - stack.Peek());
                    }
                }
            }
            return maxValidLen;

        }
    }
}
