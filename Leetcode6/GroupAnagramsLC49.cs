using System.Text;

namespace Leetcode
{
    public class GroupAnagramsLC49
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            //START - this approach is just to find if 2 words are same. abcba will be represented as 22100000000000.
            //The other alternative is to sort the word, which is more expensive.

            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();
            int[] chars = null;
            for (int i = 0; i < strs.Length; i++)
            {
                chars = new int[26];
                StringBuilder sbChars = new StringBuilder();
                string strChars = "";
                var word = strs[i];
                for (int k = 0; k < word.Length; k++)
                {
                    chars[word[k] - 'a'] = chars[word[k] - 'a'] + 1;
                }
                for (int k = 0; k < 26; k++)
                {
                    sbChars.Append(chars[k]);
                    sbChars.Append(','); //some kind of delim is needed for case like - "bdddddddddd", "bbbbbbbbbbc"
                    //010100000000....010100000 (You can see both words would be same without delim)
                }
                strChars = sbChars.ToString();


                if (!(map.ContainsKey(strChars)))
                    map.Add(strChars, new List<string>());
                map[strChars].Add(word);
            }


            IList<IList<string>> result = new List<IList<string>>();
            foreach (var kv in map)
            {
                result.Add(kv.Value);
            }

            return result;
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
