using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    //https://www.youtube.com/watch?v=trFw8IDw2Vg
    // #Dictionary #Hashmap
    public class SortCharByFreqLeetcode451
    {
        public string FrequencySort(string s)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            char[] arr = s.ToCharArray();
            int count;
            foreach (var c in arr)
            {
                if (dict.TryGetValue(c, out count))
                    dict[c] = count + 1;
                else
                    dict[c] = 1;
            }

            var kvPair = dict.OrderByDescending(x => x.Value); // #line to remember

            StringBuilder result = new StringBuilder();
            foreach (var item in kvPair)
            {
                for (int i = 0; i < item.Value; i++)
                {
                    result.Append(item.Key);
                }
            }
            return result.ToString();
        }
    }
}
