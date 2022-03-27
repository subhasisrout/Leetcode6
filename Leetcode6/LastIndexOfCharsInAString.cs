using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class LastIndexOfCharsInAString
    {
        public int[] GetLastIndexOfCharsInAString(string s)
        {
            //assumption the string would contain all lower case characters
            int[] indices = new int[26];
            char[] arrChar = s.ToCharArray();
            for (int i = 0; i < arrChar.Length; i++)
            {
                indices[arrChar[i] - 'a'] = i;
            }

            return indices;
        }
    }
}
