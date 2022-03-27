using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// #OnlineAssessment OA

namespace Leetcode
{
    public class OAMaxNumOfNonIntersectingSegmentsOfLen2OfEqualSum
    {
        public int Solution(int[] A)
        {
            if (A == null || A.Length <= 1)
                return 0;

            int[] adjSums = new int[A.Length - 1];
            Dictionary<int, int> map = new Dictionary<int, int>();
            int result = Int32.MinValue;

            // populate adjSums (for 2 consecutive nums), ignoring cases like 1,3,1
            for (int i = 0; i < A.Length - 1; i++)
            {
                adjSums[i] = A[i] + A[i + 1];
                if (i > 0 && adjSums[i - 1] == adjSums[i])
                    adjSums[i] = Int32.MinValue; //flagged for ignoring
            }

            // get counts of each sum
            for (int i = 0; i < adjSums.Length; i++)
            {
                if (adjSums[i] == Int32.MinValue)
                    continue;

                if (map.ContainsKey(adjSums[i]))
                    map[adjSums[i]] += 1;
                else
                    map.Add(adjSums[i], 1);
            }

            //find the entry in the dict with max value.
            foreach (var key in map.Keys)
            {
                result = Math.Max(result, map[key]);
            }

            return result;
        }
    }
}
