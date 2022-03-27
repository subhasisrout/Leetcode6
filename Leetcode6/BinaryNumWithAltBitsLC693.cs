using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class BinaryNumWithAltBitsLC693
    {
        public bool HasAlternatingBits(int n)
        {
            if (n == 3)
                return false;
            int r = -1;
            int lastR = -1;
            while (n >= 2)
            {
                r = n % 2;
                if (lastR == r)
                    return false;
                n = n / 2;
                lastR = r;
            }

            return n != lastR;

        }
    }
}
