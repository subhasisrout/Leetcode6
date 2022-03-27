using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class NumberComplementLC476
    {
        public int FindComplement(int num)
        {
            if (num == 0)
                return 1;

            if (num == 1)
                return 0;

            int result = 0;
            int r = 0; // remainder
            int leftPos = 0;
            while (num >= 2)
            {
                r = num % 2;
                if (r == 0)
                    result += (int)Math.Pow(2, leftPos);
                num >>= 1; //num = num / 2;
                leftPos++;
            }

            return result;
        }
    }
}
