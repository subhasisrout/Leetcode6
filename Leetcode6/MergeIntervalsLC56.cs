using System;
using System.Collections.Generic;
using System.Linq;

// Taken from Leetcode solution
// I guess its more intuitive than MergeOverlappingIntervalsAE.cs
// #Smart way to Sort (one liner)

namespace Leetcode
{
    public class MergeIntervalsLC56
    {
        public int[][] Merge(int[][] intervals)
        {
            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0])); // Single liner instead of using an #IComparer
            List<int[]> merged = new List<int[]>();
            merged.Add(intervals[0]);
            for (int i = 1; i < intervals.Length; i++)
            {
                // Add to merged as new entry if item's start is strictly greater than last element's endTime of merged
                if (merged.Last()[1] < intervals[i][0])
                    merged.Add(intervals[i]);
                else //only update the endTime. No new entry created.
                    merged.Last()[1] = Math.Max(merged.Last()[1], intervals[i][1]);
            }
            return merged.ToArray(); 
        }
    }
}
