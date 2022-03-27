using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Cannot use #int.TryParse, as it can cause overflow
// #Deque in .NET as #LinkedList
// #MonotonicStack #Stack
// char to "singleDigitInt"

namespace Leetcode
{
    public class RemoveKDigitsLC402
    {
        public string RemoveKdigits(string num, int k)
        {
            //edge case
            if (num.Length == k) return "0";
            LinkedList<int> stack = new LinkedList<int>();
            for (int i = 0; i < num.Length; i++)
            {
                int curr = num[i] - '0';
                while (stack.Count > 0 && k > 0 && stack.Last.Value > curr)
                {
                    stack.RemoveLast();
                    k--;
                }
                stack.AddLast(curr);
            }
            //process the stack if k is not yet 0. case 123, k=1
            while (k > 0)
            {
                stack.RemoveLast();
                k--;
            }

            StringBuilder result = new StringBuilder();
            string resultStr = "";
            while (stack.Count > 0)
            {
                result.Append(stack.First.Value);
                stack.RemoveFirst();
            }
            resultStr = result.ToString().TrimStart('0');
            return resultStr == "" ? "0" : resultStr;
        }
    }
}
