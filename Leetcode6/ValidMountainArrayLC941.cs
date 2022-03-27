using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class ValidMountainArrayLC941
    {
        public bool ValidMountainArray(int[] A)
        {
            if (A.Length < 3)
                return false;

            int i = 0;
            bool isIncreasing = true;
            bool peakFound = false;
            while (i < A.Length - 1)
            {
                if (A[i] == A[i + 1])
                    return false;

                if (isIncreasing)
                {
                    if (A[i] < A[i + 1])
                    {
                        i++;
                        continue;
                    }
                    else
                    {                        
                        isIncreasing = false;
                        if (i > 0) peakFound = true;
                        i++;
                    }
                }
                else
                {
                    if (A[i] > A[i + 1])
                    {
                        i++;
                        continue;
                    }
                    else
                        return false;
                }                
            }

            if (peakFound)
                return true;
            return false;
        }
    }
}
