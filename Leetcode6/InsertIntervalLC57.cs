using System;
using System.Collections.Generic;

// Intuitive explaination at
// https://leetcode.com/problems/insert-interval/discuss/21602/Short-and-straight-forward-Java-solution

namespace Leetcode
{
    public class InsertIntervalLC57
    {
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            // intervals is already sorted
            List<int[]> result = new List<int[]>();
            int i = 0;
            int newIntervalStartTime = newInterval[0];
            int newIntervalEndTime = newInterval[1];
            // since the intervals are already sorted, add all the intervals before the newInterval starts
            while (i < intervals.Length && intervals[i][1] < newIntervalStartTime)
            {
                result.Add(intervals[i]);
                i++;
            }

            // Merge setting newIntervalStart and EndTime. Expand the newInterval by updating EndTime
            // and compare newIntervalEndTime in the loop.
            while (i < intervals.Length && intervals[i][0] <= newIntervalEndTime)
            {
                newIntervalStartTime = Math.Min(intervals[i][0], newIntervalStartTime);
                newIntervalEndTime = Math.Max(intervals[i][1], newIntervalEndTime);
                i++;
            }
            result.Add(new int[] { newIntervalStartTime, newIntervalEndTime });

            // since the intervals are already sorted, add all the intervals after the newInterval-merged ends
            while (i < intervals.Length)
            {
                result.Add(intervals[i]);
                i++;
            }


            return result.ToArray();

        }
    }
}
