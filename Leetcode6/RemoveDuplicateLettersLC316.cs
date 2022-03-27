using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class RemoveDuplicateLettersLC316
    {
        public string RemoveDuplicateLetters(string s)
        {
            if (s == null || s.Length <= 1)
                return s;

            char[] inputArr = s.ToCharArray();
            Array.Sort(inputArr);

            if (s.Length == 2 && inputArr[0] == inputArr[1])
                return inputArr[0].ToString();
            else if (s.Length == 2 && s[0] != s[1])
                return new string(inputArr, 0, 2);

            int i = 0; // this will be incremented and set when distint
            int j = 1; // this will move forward

            while (j < inputArr.Length)
            {
                while (j < inputArr.Length && inputArr[j] != inputArr[i])
                {
                    i++;
                    j++;
                }
                while (j < inputArr.Length && inputArr[j] == inputArr[i])
                {
                    j++;
                }

                i++;
                if (j < inputArr.Length)
                {
                    inputArr[i] = inputArr[j];
                }
            }

            string result = new string(inputArr, 0, i);
            return result;
        }
    }
}
