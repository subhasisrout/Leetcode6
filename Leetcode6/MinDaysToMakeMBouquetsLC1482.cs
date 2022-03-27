using System;
using System.Linq;

// #Medium problem becomes easy by breaking it into helper function. Michael Muinos explains very nicely - https://www.youtube.com/watch?v=BUZ0PLt1FAA
// #BinarySearch variant. Instead of array being sorted, we are using range of values (min-max) and halfing everytime.
// #Variant
// #LC875 is another variant. Solved directly in leetcode. Always break the binary-search part with helper function.
// Time complexity O(Nlog(maxA))

namespace Leetcode
{
    public class MinDaysToMakeMBouquetsLC1482
    {
        public int MinDays(int[] bloomDay, int m, int k)
        {
            if (m * k > bloomDay.Length) return -1;
            int result = Int32.MaxValue;
            int l = 1;
            int r = bloomDay.Max();
            int mid = l + (r - l) / 2;
            while (l <= r)
            {
                mid = l + (r - l) / 2;
                if (CanMakeMBouquetsInXDays(bloomDay, m, k, mid))
                {
                    result = Math.Min(result, mid);
                    r = mid - 1;
                }
                else
                    l = mid + 1;
            }
            return result;
        }
        private bool CanMakeMBouquetsInXDays(int[] bloomDay, int m, int k, int x)
        {
            int runningCount = 0; // flower count
            int b = 0; //for bouquets

            for (int i = 0; i < bloomDay.Length; i++)
            {
                if (bloomDay[i] <= x)
                {
                    runningCount++;
                    if (runningCount == k)
                    {
                        b++;
                        runningCount = 0;
                    }
                }
                else
                {
                    runningCount = 0;
                }
                if (b == m)
                    return true;
            }
            return false;
        }
    }
}
