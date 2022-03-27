using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class RangeSumBSTLC938
    {
        public int RangeSumBST(TreeNode root, int L, int R)
        {
            int sum = 0;
            if (root == null)
                return sum;

            //Idea of using BFS is simpler, easier to understand, and does not use recursion.
            // It is also efficient as we are adding checks before enqueueing.
            // Also recursion has a limitation - It can only go n-stack deep.

            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            TreeNode current = null;
            while (q.Count != 0)
            {
                current = q.Dequeue();
                if (current.val >= L && current.val <= R)
                    sum += current.val;

                if (current.left != null && current.val >= L)
                    q.Enqueue(current.left);

                if (current.right != null && current.val <= R)
                    q.Enqueue(current.right);
            }

            return sum;
        }
    }
}
