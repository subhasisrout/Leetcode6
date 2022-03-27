using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// TODO: Absorb intuition completely

namespace Leetcode
{
    public class PathSum3LC437
    {
        int count;
        int target;
        Dictionary<int, int> map = new Dictionary<int, int>();
        public int PathSum(TreeNode root, int targetSum)
        {
            target = targetSum;
            DFSPreOrder(root, 0);
            return count;
        }
        private void DFSPreOrder(TreeNode root, int currSum)
        {
            if (root == null)
                return;

            currSum += root.val;

            if (currSum == target)
                count++;

            if (map.ContainsKey(currSum - target))
                count += map[currSum - target];

            // add currSum to map
            if (map.ContainsKey(currSum))
                map[currSum] += 1;
            else
                map.Add(currSum, 1);

            DFSPreOrder(root.left, currSum);
            DFSPreOrder(root.right, currSum);

            //backtrack (reduce currSum count by 1)
            map[currSum] = map[currSum] - 1;
        }
    }
}
