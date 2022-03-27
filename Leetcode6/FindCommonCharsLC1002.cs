using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Leetcode
{
    public class FindCommonCharsLC1002
    {
        public IList<string> CommonChars(string[] A)
        {
            IList<string> result = new List<string>();
            int[] minCharArrayCount = new int[26]; //how many a's , b's...etc are present (min so far)
            for (int i = 0; i < 26; i++)
            {
                minCharArrayCount[i] = Int32.MaxValue;
            }

            for (int i = 0; i < A.Length; i++)
            {
                string word = A[i];
                char[] wordChars = word.ToCharArray();
                int[] localCharArrayCount = new int[26];
                for (int j = 0; j < wordChars.Length; j++)
                {
                    int localIndex = wordChars[j] - 'a';
                    localCharArrayCount[localIndex]++; //how many a's , b's...etc are present for specific word.
                }
                for (int k = 0; k < 26; k++)
                {
                    minCharArrayCount[k] = Math.Min(minCharArrayCount[k], localCharArrayCount[k]);
                }
            }

            //Below is creating result from minCharArrayCount
            for (int i = 0; i < 26; i++)
            {
                int cnt = minCharArrayCount[i];
                while (cnt > 0)
                {
                    result.Add(Convert.ToString((char)(i + 'a')));
                    cnt--;
                }
            }

            return result;
        }
    }
}
