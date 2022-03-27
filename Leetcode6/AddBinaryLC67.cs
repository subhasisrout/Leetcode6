using System;
using System.Text;

namespace Leetcode
{
    public class AddBinaryLC67
    {
        public string AddBinary(string a, string b)
        {
            int len1 = a.Length;
            int len2 = b.Length;
            int carry = 0;
            int partialResult = 0;
            StringBuilder result = new StringBuilder();

            while (len1 > 0 || len2 > 0)
            {
                if (len1 > 0 && len2 > 0)
                    partialResult = (a[len1 - 1] - '0') + (b[len2 - 1] -'0') + carry;
                else if (len1 > 0)
                    partialResult = (a[len1 - 1] - '0') + carry;
                else if (len2 > 0)
                    partialResult = (b[len2 - 1] - '0') + carry;
                if (partialResult == 2)
                {
                    carry = 1;
                    partialResult = 0;
                }
                else if (partialResult == 3)
                {
                    carry = 1;
                    partialResult = 1;
                }
                else
                {
                    carry = 0;
                }
                result.Insert(0, partialResult);
                len1--;
                len2--;
            }
            if (carry == 1)
                result.Insert(0, carry);



            return result.ToString();







        }
    }
}
