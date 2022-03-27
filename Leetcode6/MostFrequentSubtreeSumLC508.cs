using System;
using System.Collections.Generic;


// #DFS recursion with return val.
// return val not used in the main caller method.

namespace Leetcode
{
    public class MostFrequentSubtreeSumLC508
    {
        int maxVal = 0;
        public int[] FindFrequentTreeSum(TreeNode root)
        {
            Dictionary<int, int> counts = new Dictionary<int, int>();
            DFSPostOrder(root, counts); //dont care of the return value here. Only needed in the recursion
            // Once we come out of the above line, we only use the counts MAP and the maxVal;

            List<int> result = new List<int>();
            foreach (var item in counts)
            {
                if (item.Value == maxVal)
                    result.Add(item.Key);
            }

            return result.ToArray();
        }

        private int DFSPostOrder(TreeNode root, Dictionary<int, int> counts)
        {
            if (root == null)
                return 0;
            int left = DFSPostOrder(root.left, counts);
            int right = DFSPostOrder(root.right, counts);

            int sum = left + right + root.val;

            if (counts.ContainsKey(sum))
                counts[sum] = counts[sum] + 1;
            else
                counts[sum] = 1;

            maxVal = Math.Max(maxVal, counts[sum]);
            return sum;
        }
    }
}
