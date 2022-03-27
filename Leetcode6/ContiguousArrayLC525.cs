using System;
using System.Collections.Generic;

// From Leetcode solution
// Documented in scanned photo
// The key is to understand the graph (x-y axis) in Leetcode solution 2 (although using solution 3 here)


namespace Leetcode
{
    public class ContiguousArrayLC525
    {
        public int FindMaxLength(int[] nums)
        {
            Dictionary<int, int> cancellingCountsIndexMap = new Dictionary<int, int>();
            int maxLength = 0;
            int runningCancelledCount = 0;
            // Detailed explanation in scanned photo (right hand side page)
            cancellingCountsIndexMap.Add(0, -1); //meaning no index found (-1) where cancelling counts is 0.

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                    runningCancelledCount += -1;
                else
                    runningCancelledCount += 1;

                if (cancellingCountsIndexMap.ContainsKey(runningCancelledCount))
                    maxLength = Math.Max(maxLength, i - cancellingCountsIndexMap[runningCancelledCount]);
                else
                    cancellingCountsIndexMap.Add(runningCancelledCount, i);
            }
            return maxLength;
        }
    }
}
