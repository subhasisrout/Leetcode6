using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// #Less lines of code - idea https://www.youtube.com/watch?v=W9QJ8HaRvJQ
// The code I submitted had lot of if-else checks and boundary condition checks.

// Note its about finding #pivot. Finding pivot here is different from finding pivot in rotated array LC33

namespace Leetcode
{
    public class PeakIndexOfMountainArrayLC852
    {
        public int PeakIndexInMountainArray(int[] arr)
        {
            return BinSearch(arr, 0, arr.Length - 1);
        }
        private int BinSearch(int[] arr, int start, int end)
        {
            while (start < end) // not less than (not less than or equal to)
            { 
                int mid = start + (end - start) / 2;
                if (arr[mid + 1] < arr[mid])
                    end = mid; // answer could be mid, so we are not doing end = mid-1
                else
                    start = mid + 1; // answer could never be mid, thats why we are doing start = mid + 1
            }
            return start; // or end or mid
        }
    }
}
