using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class CombinationSumLC39
    {
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {            
            IList<IList<int>> result = new List<IList<int>>();
            if (candidates == null || candidates.Length == 0)
                return result;
            Array.Sort(candidates);
            CombinationSumUtil(candidates, target, 0, new List<int>(), result);
            return result;
        }

        private void CombinationSumUtil(int[] candidates, int target, int startIndex, IList<int> currentList, IList<IList<int>> result)
        {
            if (target < 0) return;
            if (target == 0)
            {
                result.Add(new List<int>(currentList));
                return;
            }
            for (int i = startIndex; i < candidates.Length; i++)
            {
                currentList.Add(candidates[i]);
                CombinationSumUtil(candidates, target - candidates[i], i, currentList, result);
                currentList.RemoveAt(currentList.Count - 1);
            }
        }
    }
}
