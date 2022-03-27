using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class SymmetricTreeLC101
    {
        public bool IsSymmetric(TreeNode root)
        {
            if (root == null)
                return true;
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            List<TreeNode> nodesAtALevel = new List<TreeNode>();
            while (q.Count != 0)
            {
                while (q.Count != 0)
                {
                    nodesAtALevel.Add(q.Dequeue());
                }
                if (!IsListSymmetric(nodesAtALevel))
                    return false;
                else
                {
                    foreach (var node in nodesAtALevel)
                    {
                        if (node != null)
                        {
                            q.Enqueue(node.left);
                            q.Enqueue(node.right);
                        }
                    }
                    nodesAtALevel = new List<TreeNode>();
                }

            }
            return true;
        }
        private bool IsListSymmetric(List<TreeNode> list)
        {
            int i = 0;
            int j = list.Count - 1;
            while (i < j)
            {
                if (list[i] == null && list[j] != null)
                    return false;
                if (list[j] == null && list[i] != null)
                    return false;
                if (list[i] != null && list[j] != null && list[i].val != list[j].val)
                    return false;
                i++;
                j--;

            }
            return true;
        }

        public bool IsSymmetric2(TreeNode root)
        {
            if (root == null)
                return true;

            return IsSymmetric2(root.left, root.right);
        }

        private bool IsSymmetric2(TreeNode left, TreeNode right)
        {
            if (left == null || right == null)
                return left == right;

            if (left.val != right.val)
                return false;

            return IsSymmetric2(left.left, right.right) && IsSymmetric2(left.right, right.left);
        }
    }
}
