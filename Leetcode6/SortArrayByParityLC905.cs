using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class SortArrayByParityLC905
    {
        //Below one is taken from kevin 
        public int[] SortArrayByParity(int[] A)
        {
            int lastEvenIndex = 0;
            int temp = -1;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] % 2 == 0)
                {
                    //swap A[i] with A[lastEvenIndex] (and inc lastEvenIndex)
                    temp = A[i];
                    A[i] = A[lastEvenIndex];
                    A[lastEvenIndex] = temp;
                    lastEvenIndex++;
                }

            }
            return A;
        }

        //Below one was my me. Both of the runtimes are equal.
        public int[] SortArrayByParity2(int[] A)
        {
            if (A == null || A.Length == 0)
                return A;

            int i = 0;
            int j = A.Length - 1;
            while (i < j)
            {
                if (A[i] % 2 != 0 && A[j] % 2 == 0)
                {
                    Swap(ref A[i], ref A[j]);
                    i++;
                    j--;
                }
                else if (A[i] % 2 == 0)
                {
                    i++;
                }
                else if (A[j] % 2 != 0)
                {
                    j--;
                }
            }
            return A;

        }

        private void Swap(ref int v1, ref int v2)
        {
            int temp = v1;
            v1 = v2;
            v2 = temp;
        }
    }
}
