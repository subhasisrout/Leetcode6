using System.Collections.Generic;

// #RememberPattern
// This is pretty much template code.


namespace Leetcode
{
    public class GenerateParenthesisLC22
    {
        public IList<string> GenerateParenthesis(int n)
        {
            IList<string> result = new List<string>();
            BackTrack(result, "", 0, 0, n);
            return result;
        }
        private void BackTrack(IList<string> result, string curr, int open, int close, int max)
        {
            //base case
            if (curr.Length == max * 2)
            {
                result.Add(curr);
                return;
            }

            // if you are using stringbuilder, you will have to remove it (last char) after calling backtrack.
            // not needed for string as string are immutable and new string is created with appended "(", but the original string is unchanged. so no removal required.
            if (open < max) BackTrack(result, curr + "(", open + 1, close, max); 
            if (close < open) BackTrack(result, curr + ")", open, close + 1, max);
        }
    }
}
