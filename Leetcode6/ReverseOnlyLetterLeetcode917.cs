using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class ReverseOnlyLetterLeetcode917
    {
        public string ReverseOnlyLetters(string S)
        {
            char[] arr = S.ToCharArray();
            int i = 0;
            int j = arr.Length - 1;
            while (i < j)
            {
                while (i < j && !Char.IsLetter(arr[i]))
                    i++;
                while (j > i && !Char.IsLetter(arr[j]))
                    j--;

                char temp = arr[i];
                arr[i++] = arr[j];
                arr[j--] = temp;
            }
            return new string(arr);
        }
    }
}
