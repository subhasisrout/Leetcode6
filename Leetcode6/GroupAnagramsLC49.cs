using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class GroupAnagramsLC49
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();
            for (int i = 0; i < strs.Length; i++)
            {
                string currentWord = strs[i];
            
                //START - this approach is just to find if 2 words are same. abcba will be represented as 22100000000000.
                //The other alternative is to sort the word, which is more expensive.
                char[] currCharArray = currentWord.ToCharArray();
                int[] numArr = new int[26];
                for (int j = 0; j < currCharArray.Length; j++)
                {
                    numArr[currCharArray[j] - 'a'] = numArr[currCharArray[j] - 'a'] + 1;
                }
                StringBuilder sb = new StringBuilder();
                for (int j = 0; j < numArr.Length; j++)
                {
                    sb.Append(numArr[j]);
                }
                string currWordUnique = sb.ToString();
                //END


                if (!map.ContainsKey(currWordUnique))
                    map.Add(currWordUnique, new List<string>());

                map[currWordUnique].Add(currentWord);
            }

            IList<IList<string>> output = new List<IList<string>>();
            foreach (var item in map.Values)
            {
                output.Add(item);
            }
            return output;
        }

        // Below is a self written 4 line solution (using helper method to return charfreqsortedbykey like a1e1t1)
        public IList<IList<string>> GroupAnagrams2(string[] strs)
        {
            Dictionary<string, IList<string>> groups = new Dictionary<string, IList<string>>();
            for (int i = 0; i < strs.Length; i++)
            {
                string charCountOfWordSortedByChar = GetCharCountOfWordSortedByChar(strs[i]);
                if (!groups.ContainsKey(charCountOfWordSortedByChar))
                    groups.Add(charCountOfWordSortedByChar, new List<string>());
                groups[charCountOfWordSortedByChar].Add(strs[i]);
            }
            return groups.Values.ToList();
        }

        public string GetCharCountOfWordSortedByChar(string word)
        {
            Dictionary<char, int> charCountMap = new Dictionary<char, int>();
            for (int i = 0; i < word.Length; i++)
            {
                if (!charCountMap.ContainsKey(word[i]))
                    charCountMap.Add(word[i], 0);
                charCountMap[word[i]]++;
            }

            StringBuilder valuesSortedByKeys = new StringBuilder();
            foreach (var item in charCountMap.OrderBy(i => i.Key))
            {
                valuesSortedByKeys.Append(item.Key);
                valuesSortedByKeys.Append(item.Value);
            }

            return valuesSortedByKeys.ToString();
        }
    }
}
