using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class FlipImageLC832
    {
        public int[][] FlipAndInvertImage(int[][] A)
        {
            for (int i = 0; i < A.Length; i++)
            {
                int u = 0;
                int v = A[i].Length - 1;

                while (u <= v)
                {
                    if (A[i][u] == A[i][v] && u!=v)
                    {
                        A[i][u] = A[i][u] ^ 1;
                        A[i][v] = A[i][v] ^ 1;
                    }
                    else if (u == v)
                    {
                        A[i][u] = A[i][u] ^ 1;
                    }
                    u++;
                    v--;
                }

            }

            //As per LEETCODE, the below is faster swapping and inverting together.

            //for (int i = 0; i < A.Length; i++)
            //{                
            //    int u = 0;
            //    int v = A[i].Length - 1;
            //    while (u < v)
            //    {
            //        SwapAndInvertTwoNumbers(ref A[i][u], ref A[i][v]);
            //        u++;
            //        v--;
            //    }
            //    if (u == v)
            //        A[i][u] = A[i][u] ^ 1;
            //}


            return A;
        }
        public void SwapAndInvertTwoNumbers(ref int a, ref int b)
        {
            int temp = a;
            a = b ^ 1;
            b = temp ^ 1;
        }
    }
}
