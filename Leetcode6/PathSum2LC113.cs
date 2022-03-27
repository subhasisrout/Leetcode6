using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// #DFS #Backtracking in Binary Tree
// Inspired from https://www.youtube.com/watch?v=gUgT0W25jCM&t=679s Kenny talks code.
namespace Leetcode
{
    public class PathSum2LC113
    {
        public IList<IList<int>> PathSum(TreeNode root, int targetSum)
        {
            IList<IList<int>> result = new List<IList<int>>();
            PathSumUtil(root, result, new List<int>(), targetSum);
            return result;
        }

        private void PathSumUtil(TreeNode root, IList<IList<int>> result, IList<int> curr, int targetSum)
        {
            if (root == null) return;

            curr.Add(root.val);

            if (root.left == null && root.right == null && root.val == targetSum)
            {
                result.Add(new List<int>(curr)); // Dont return after this. This is not a base condition.
            }

            PathSumUtil(root.left, result, curr, targetSum - root.val);
            PathSumUtil(root.right, result, curr, targetSum - root.val);
            curr.RemoveAt(curr.Count - 1); // Backtracking
        }
    }
}
