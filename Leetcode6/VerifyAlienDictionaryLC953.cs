using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class VerifyAlienDictionaryLC953
    {
        public bool IsAlienSorted(string[] words, string order)
        {
            //In my first attempt, I used a Hashmap/Dictionary, but I think this approach will take much less space
            //Just remember to subtract - 'a'
            int[] alphabet = new int[26];
            for (int i = 0; i < order.Length; i++)
            {
                alphabet[order[i] - 'a'] = i;
            }

            for (int i = 0; i < words.Length - 1; i++)
            {
                if (!WordsSorted(words[i], words[i + 1],alphabet))
                    return false;
            }
            return true;

        }

        private bool WordsSorted(string word1, string word2, int[] alphabet)
        {           
            char[] word1CharArray = word1.ToCharArray();
            char[] word2CharArray = word2.ToCharArray();

            for (int i = 0; i < Math.Min(word1CharArray.Length, word2CharArray.Length); i++)
            {
                if (alphabet[word1CharArray[i] - 'a'] < alphabet[word2CharArray[i] - 'a'])
                    return true;
                else if (alphabet[word1CharArray[i] - 'a'] > alphabet[word2CharArray[i] - 'a'])
                    return false;
                else
                    continue;
            }
            if (word1.Length > word2.Length)
                return false;
            else
                return true;

        }
    }
}
