using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Similar idea of MergeIntervals #LC56
// #Neetcode - https://leetcode.com/problems/remove-covered-intervals/

namespace Leetcode
{
    public class RemoveCoveredIntervalsLC1288
    {
        public int RemoveCoveredIntervals(int[][] intervals)
        {
            //Sort by startTime asc and if they are equal, sort by endTime desc.
            Array.Sort(intervals, (a, b) => {
                if (a[0] != b[0])
                    return a[0].CompareTo(b[0]);
                else
                    return b[1].CompareTo(a[1]);
            });
            List<int[]> merged = new List<int[]>();
            merged.Add(intervals[0]);
            for (int i = 1; i < intervals.Length; i++)
            {
                if (merged.Last()[1] >= intervals[i][1] && merged.Last()[0] <= intervals[i][0])
                    continue;
                else
                    merged.Add(intervals[i]);
            }
            return merged.Count;
        }
    }
}
