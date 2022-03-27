using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class AddStringsLC415
    {
        public string AddStrings(string num1, string num2)
        {
            int len1 = num1.Length;
            int len2 = num2.Length;

            int i = len1 - 1;
            int j = len2 - 1;
            StringBuilder result = new StringBuilder();
            int carry = 0;

            while(i>=0 || j>=0)
            {
                int partialResult = ((i < 0) ? 0 :Convert.ToInt32(num1[i] - '0')) + ((j < 0) ? 0 : Convert.ToInt32(num2[j] - '0')) + carry;
                result.Append(partialResult % 10);
                if (partialResult >= 10)
                    carry = partialResult / 10;
                else
                    carry = 0;
                i--;
                j--;
            }

            if (carry != 0)
                result.Append(carry);

            var outputArr = result.ToString().ToCharArray();
            Array.Reverse(outputArr);
            return new string(outputArr);
        }
    }
}
