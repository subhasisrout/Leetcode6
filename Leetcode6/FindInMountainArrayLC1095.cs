using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This is a combination of PeakIndexOfMountainArrayLC852 (start<end) +
// Normal Binary Search for distinct inc/dec elements. (start<=end)

namespace Leetcode
{
    public class FindInMountainArrayLC1095
    {
        public int FindInMountainArray(int target, MountainArray mountainArr)
        {
            int result = -1;
            int peakIdx = PeakIndexInMountainArray(mountainArr);
            if (mountainArr.Get(peakIdx) == target)
                return peakIdx;
            result = NormalBinarySearchDistinctElements(mountainArr, 0, peakIdx - 1, target, true); //look in first half/ inc half
            if (result == -1)
                return NormalBinarySearchDistinctElements(mountainArr, peakIdx + 1, mountainArr.Length() - 1, target, false);
            else
                return result;
        }



        private int PeakIndexInMountainArray(MountainArray mountainArr)
        {
            return BinSearchForFindingPeakIndex(mountainArr, 0, mountainArr.Length() - 1);
        }
        private int BinSearchForFindingPeakIndex(MountainArray mountainArr, int start, int end)
        {
            while (start < end) // not less than (not less than or equal to)
            {
                int mid = start + (end - start) / 2;
                if (mountainArr.Get(mid + 1) < mountainArr.Get(mid))
                    end = mid; // answer could be mid, so we are not doing end = mid-1
                else
                    start = mid + 1; // answer could never be mid, thats why we are doing start = mid + 1
            }
            return start; // or end or mid
        }
        private int NormalBinarySearchDistinctElements(MountainArray mountainArr, int start, int end, int target, bool isIncHalf)
        {
            while (start <= end)
            {
                int mid = start + (end - start) / 2;
                if (mountainArr.Get(mid) == target)
                    return mid;
                else if (mountainArr.Get(mid) > target)
                {
                    if (isIncHalf)
                        end = mid - 1;
                    else
                        start = mid + 1;
                }
                else
                {
                    if (isIncHalf)
                        start = mid + 1;
                    else
                        end = mid - 1;
                }
            }
            return -1;
        }
    }



    public class MountainArray
    {
        public int Get(int index) { return -1; }
        public int Length() { return -1; }
  }
}
