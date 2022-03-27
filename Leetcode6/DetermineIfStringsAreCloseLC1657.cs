using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
#GoodQuestion
Key here is the following - 
1. Both string have the same set of charracters. (
2. Both string have the same frequency of charracters.
*/

namespace Leetcode
{
    public class DetermineIfStringsAreCloseLC1657
    {
        public bool CloseStrings(string word1, string word2)
        {
            Dictionary<char, int> map1 = new Dictionary<char, int>();
            Dictionary<char, int> map2 = new Dictionary<char, int>();
            HashSet<int> word1KeySet = new HashSet<int>();
            HashSet<int> word2KeySet = new HashSet<int>();

            for (int i = 0; i < word1.Length; i++)
            {
                if (map1.ContainsKey(word1[i]))
                    map1[word1[i]] = map1[word1[i]] + 1;
                else
                {
                    map1.Add(word1[i], 1);
                    word1KeySet.Add(word1[i]);
                }
            }

            for (int i = 0; i < word2.Length; i++)
            {
                if (map2.ContainsKey(word2[i]))
                    map2[word2[i]] = map2[word2[i]] + 1;
                else
                {
                    map2.Add(word2[i], 1);
                    word2KeySet.Add(word2[i]);
                }
            }

            if (!word1KeySet.SetEquals(word2KeySet))
                return false;

            var map1Values = map1.Values.ToList();
            var map2Values = map2.Values.ToList();

            map1Values.Sort();
            map2Values.Sort();

            if (map1Values.Count != map2Values.Count)
                return false;

            for (int i = 0; i < map1Values.Count; i++)
            {
                if (map1Values[i] != map2Values[i])
                    return false;
            }
            return true;


        }
    }
}
