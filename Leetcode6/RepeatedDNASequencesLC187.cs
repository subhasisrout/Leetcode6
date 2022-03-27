using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class RepeatedDNASequencesLC187
    {
        public IList<string> FindRepeatedDnaSequences(string s)
        {
            List<string> retval = new List<string>();
            Dictionary<string, int> map = new Dictionary<string, int>();
            string word = "";
            for (int i = 0; i <= s.Length - 10; i++)
            {
                word = s.Substring(i, 10);
                if (map.ContainsKey(word))
                    map[word] = map[word] + 1;
                else
                    map.Add(word, 1);
            }

            foreach (var item in map)
            {
                if (item.Value > 1)
                    retval.Add(item.Key);
            }

            return retval;
        }
    }
}
