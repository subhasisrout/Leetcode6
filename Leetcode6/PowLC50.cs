using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class PowLC50
    {
        public double MyPow(double x, int n)
        {
            if (n == 0) return 1;
            if (n < 0)
            {
                x = 1 / x;
                // if we add n = n * -1, it will blow up at Int32.MinValue (--2147483648).
                // Because -2147483648*-1 = 2147483648, which is greater than Int32.MaxValue (2147483647)
                return (n % 2 == 0) ? MyPow(x * x, -(n / 2)) : x * MyPow(x * x, -(n / 2)); //n = n * -1;
            }
            return (n % 2 == 0) ? MyPow(x * x, n / 2) : x * MyPow(x * x, n / 2);
        }

    }
}
