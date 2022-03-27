using System.Collections.Generic;
using System.Linq.Expressions;

// #Backtrack
// Basics for LC784

namespace Leetcode
{
    public class PermutationOfCharsUsingCase
    {
        public IList<string> Permutations(string word)
        {
            IList<string> result = new List<string>();
            char[] letters = word.ToCharArray();
            DfsAndBacktrack("", result, letters, 0);
            return result;
        }
        private void DfsAndBacktrack(string current, IList<string> result, char[] letters, int index)
        {
            if (current.Length == letters.Length)
                result.Add(current);
            if (index >= letters.Length)
                return;
            DfsAndBacktrack(current + char.ToLower(letters[index]), result, letters, index + 1);
            DfsAndBacktrack(current + char.ToUpper(letters[index]), result, letters, index + 1);
            
        }
    }
}
