using System;
using System.Collections.Generic;

//Refer this rather than Kevin Naughton Jr. This explanation is much better as the recursion tree for DFS was drawn
// https://www.youtube.com/watch?v=j9_qWJClp64
// #DFS #Graph #Backtrack
// Very similar to LC39. Please check.
// #RememberPattern
namespace Leetcode
{
    public class CombinationSum2LC40
    {
        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            List<IList<int>> results = new List<IList<int>>();
            if (candidates == null || candidates.Length == 0)
                return results;

            Array.Sort(candidates);
            FindCombinationsToTarget(candidates, new List<int>(), 0, target, results);
            return results;
        }

        private void FindCombinationsToTarget(int[] candidates, List<int> current, int startIndex, int target, List<IList<int>> results)
        {
            if (target == 0)
            {
                results.Add(new List<int>(current));
                return;
            }

            for (int i = startIndex; i < candidates.Length; i++) //refer diagram
            {
                if (i != startIndex && candidates[i] == candidates[i - 1]) //duplicate item.
                    continue;

                if (candidates[i] > target)
                    break;

                current.Add(candidates[i]);
                FindCombinationsToTarget(candidates, current, i + 1, target - candidates[i], results); // only difference in LC39, its (i) instead of (i + 1)
                current.RemoveAt(current.Count - 1);
            }
        }
    }
}
