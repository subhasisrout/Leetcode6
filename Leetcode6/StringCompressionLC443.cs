using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class StringCompressionLC443
    {
        public int Compress(char[] chars)
        {
            int i = 0;
            int j = 0;
            while (j < chars.Length)
            {
                char currentChar = chars[j];
                int currentCount = 1;
                j = j + 1;
                while (j < chars.Length && currentChar == chars[j])
                {
                    j++;
                    currentCount++;
                }
                chars[i] = currentChar;
                if (currentCount > 1)
                {
                    char[] countArr = currentCount.ToString().ToCharArray();
                    for (int ii = 0; ii < countArr.Length; ii++)
                    {
                        chars[i + 1] = countArr[ii];
                        i++;
                    }
                    i++;

                    // chars[i + 1] = (char)(currentCount + '0');
                    // i = i + 2;
                }
                else
                {
                    i = i + 1;
                }
            }
            return i;
        }

        private char[] convertintToChar(int N)
        {

            // Count digits in number N 
            int m = N;
            int digit = 0;

            while (m > 0)
            {

                // Increment number of digits 
                digit++;

                // Truncate the last 
                // digit from the number 
                m /= 10;
            }

            // Declare char array for result 
            char[] arr;

            // Declare duplicate char array 
            char[] arr1 = new char[digit + 1];

            // Memory allocaton of array 
            arr = new char[digit];

            // Separating integer into digits and 
            // accomodate it to character array 
            int index = 0;

            while (N > 0)
            {

                // Separate last digit from 
                // the number and add ASCII 
                // value of character '0' is 48 
                arr1[++index] = (char)(N % 10 + '0');

                // Truncate the last 
                // digit from the number 
                N /= 10;
            }

            // Reverse the array for result 
            int i;
            for (i = 0; i < index; i++)
            {
                arr[i] = arr1[index - i];
            }

            // Return char array 
            return (char[])arr;
        }
    }
}
