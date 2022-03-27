using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class LongestCommonPrefixLC14
    {
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 0)
                return "";
            StringBuilder result = new StringBuilder();
            string currentWord;
            int index = 0;
            char currentChar = '#';
            char prevChar = '#';
            while (1 == 1)
            {
                for (int i = 0; i < strs.Length; i++) // Loop through all words for a given "index"
                {
                    currentWord = strs[i];
                    if (index == currentWord.Length)
                    {
                        return result.ToString();
                    }
                    prevChar = currentChar;
                    currentChar = currentWord[index];
                    if (i != 0 && prevChar != currentChar)
                        return result.ToString();
                }
                result.Append(currentChar);

                index++;
            }
            return result.ToString();

        }
    }
}
