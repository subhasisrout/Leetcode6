using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class RansomNoteLC383
    {
        public bool CanConstruct(string ransomNote, string magazine)
        {
            char[] ransomNoteArr = ransomNote.ToCharArray();

            char[] magazineArr = magazine.ToCharArray();
            Dictionary<char, int> map = new Dictionary<char, int>();
            for (int i = 0; i < magazine.Length; i++)
            {
                if (map.ContainsKey(magazineArr[i]))
                    map[magazineArr[i]] = map[magazineArr[i]] + 1;
                else
                    map.Add(magazineArr[i], 1);
            }

            for (int i = 0; i < ransomNote.Length; i++)
            {
                if (map.ContainsKey(ransomNote[i]) && map[ransomNote[i]] > 0)
                    map[ransomNote[i]] = map[ransomNote[i]] - 1;
                else
                    return false;
            }
            return true;
        }
    }
}
