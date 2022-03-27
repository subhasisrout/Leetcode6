
using System;

namespace Leetcode
{
    public class IndexEqualsValueAE
    {
        public int IndexEqualsValue(int[] array)
        {
            int l = 0;
            int r = array.Length - 1;
            int minSoFar = Int32.MaxValue;
            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                if (array[mid] >= mid)
                {
                    if (array[mid] == mid)
                        minSoFar = Math.Min(minSoFar, mid);
                    r = mid - 1;
                }
                else if (array[mid] <= mid)
                {
                    if (array[mid] == mid)
                        minSoFar = Math.Min(minSoFar, mid);
                    l = mid + 1;
                }
            }

            return minSoFar == Int32.MaxValue ? -1 : minSoFar;
        }
    }
}
