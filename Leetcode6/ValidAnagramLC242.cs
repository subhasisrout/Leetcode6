using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class ValidAnagramLC242
    {
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
                return false;

            int[] arr = new int[26];
            
            char[] sArr = s.ToCharArray();
            char[] tArr = t.ToCharArray();

            for (int i = 0; i < sArr.Length; i++)
            {
                arr[sArr[i] - 'a']++;
                arr[tArr[i] - 'a']--;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != 0)
                    return false;
            }
            return true;


            //Dictionary<char, int> map = new Dictionary<char, int>();

            //char[] sArr = s.ToCharArray();
            //for (int i = 0; i < sArr.Length; i++)
            //{
            //    if (map.ContainsKey(sArr[i]))
            //        map[sArr[i]] = map[sArr[i]] + 1;
            //    else
            //        map.Add(sArr[i], 1);
            //}

            //char[] tArr = t.ToCharArray();
            //for (int i = 0; i < tArr.Length; i++)
            //{
            //    if (!map.ContainsKey(tArr[i]))
            //        return false;
            //    else
            //        map[tArr[i]] = map[tArr[i]] - 1;
            //}

            ////at the end all dictionary key counts should be 0

            //return !map.Values.Any(x => x != 0);

        }

    }
}
