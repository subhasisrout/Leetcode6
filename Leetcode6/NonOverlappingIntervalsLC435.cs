using System;

// Basically you want to greedily pick the the intervals which ends soon so as to accomodate more intervals (or remove less intervals)
// Excellent explaination at Neetcode https://www.youtube.com/watch?v=nONCGxWoUfM


namespace Leetcode
{
    public class NonOverlappingIntervalsLC435
    {
        public int EraseOverlapIntervals(int[][] intervals)
        {
            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0])); // Single liner instead of using #IComparer
            int count = 0;
            int closingTime = intervals[0][1];
            for (int i = 1; i < intervals.Length; i++)
            {
                var curr = intervals[i];
                if (curr[0] >= closingTime) // the adjacent interval is not overlapping. so we are good. not need to inc count. just update the closingTime
                    closingTime = curr[1];
                else // the adjacent interval IS overlapping. remove the one which ends late (or pick the one which ends soon (so math.min)). inc count.
                {
                    count++;
                    closingTime = Math.Min(closingTime, curr[1]);
                }

            }
            return count;
        }
    }
}
