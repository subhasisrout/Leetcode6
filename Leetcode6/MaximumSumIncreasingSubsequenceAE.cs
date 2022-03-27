using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// #AE #DP. Excellent intuitive explaination in AE.

namespace Leetcode
{
    public class MaximumSumIncreasingSubsequenceAE
    {
		public static List<List<int>> MaxSumIncreasingSubsequence(int[] array)
		{
			int[] sums = (int[]) array.Clone(); // max sum at a particular index (with constraint in place) NOT the answer till a specific index;
			int maxSumIdx = 0;
			int[] pastIdxSequences = new int[array.Length];
            for (int i = 0; i < pastIdxSequences.Length; i++)
				pastIdxSequences[i] = -1;

            for (int i = 0; i < array.Length; i++)
            {
                int currNum = array[i];
                for (int j = 0; j <= i; j++)
                {
                    int otherNum = array[j];
                    if (otherNum < currNum && sums[j] + currNum >= sums[i])
                    {
                        sums[i] = sums[j] + currNum;
                        pastIdxSequences[i] = j;
                    }
                }
                if (sums[i] > sums[maxSumIdx])
                    maxSumIdx = i;
            }

            List<int> result1 = new List<int>();
            result1.Add(sums[maxSumIdx]);

            List<List<int>> result = new List<List<int>>();
            result.Add(result1);
            result.Add(BuildResultList(array, pastIdxSequences, maxSumIdx));

            return result;
		}

        private static List<int> BuildResultList(int[] array, int[] pastIdxSequences, int currIdx)
        {
            List<int> result = new List<int>();
            while (currIdx != -1)
            {
                var currNum = array[currIdx];
                result.Insert(0, currNum);
                currIdx = pastIdxSequences[currIdx];
            }

            return result;
        }
    }
}
