using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class SumOfLeftLeavesLC404
    {
        public int SumOfLeftLeaves(TreeNode root)
        {
            int sum = 0;
            if (root == null)
                return sum;

            DFS(root, ref sum);
            return sum;
        }

        private void DFS(TreeNode root, ref int sum)
        {
            if (root == null)
                return;

            if (root.left != null && root.left.left == null && root.left.right == null)
                sum += root.left.val;

            DFS(root.left, ref sum);
            DFS(root.right, ref sum);
        }
    }
}
