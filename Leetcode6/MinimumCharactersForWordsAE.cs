using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class MinimumCharactersForWordsAE
    {
        public string[] MinimumCharactersForWords(string[] words)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();
            for (int i = 0; i < words.Length; i++)
            {
                string currWord = words[i];
                Dictionary<char, int> mapForCurrentWord = new Dictionary<char, int>();
                for (int j = 0; j < currWord.Length; j++)
                {                    
                    if (!mapForCurrentWord.ContainsKey(currWord[j]))
                        mapForCurrentWord.Add(currWord[j], 1);
                    else
                        mapForCurrentWord[currWord[j]] = mapForCurrentWord[currWord[j]] + 1;
                }
                foreach (var key in mapForCurrentWord.Keys)
                {
                    if (!map.ContainsKey(key))
                    {
                        map.Add(key, mapForCurrentWord[key]);
                    }
                    else if (map[key] < mapForCurrentWord[key])
                    {
                        map[key] = mapForCurrentWord[key];
                    }
                    // else if map[key] >= mapForCurrentWord[key], dont do anything.
                }
            }
            List<string> result = new List<string>();
            foreach (var key in map.Keys)
            {
                int n = map[key];
                while (n > 0)
                {
                    result.Add(key.ToString());
                    n--;
                }
            }
            return result.ToArray();
        }
    }
}
