using System;
using System.Collections.Generic;

// Below solution is elegant and is from #AlgoExpert #AE
// #Leetcode #LC56

namespace Leetcode
{
    public class MergeOverlappingIntervalsAE
    {
        public int[][] MergeOverlappingIntervals(int[][] intervals)
        {
            List<int[]> result = new List<int[]>();
            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0])); // Single liner instead of using an #IComparer
            int curr = 0;
            result.Add(intervals[curr]);
            int currResult = 0;
            while (curr < intervals.Length - 1)
            {
                if (intervals[curr + 1][0] <= result[currResult][1])
                {
                    result[currResult][1] = Math.Max(intervals[curr + 1][1], result[currResult][1]);
                    curr++;
                }
                else
                {
                    result.Add(intervals[curr + 1]);
                    currResult++;
                    curr++;
                }
            }
            return result.ToArray();
        }
    }
    
}
