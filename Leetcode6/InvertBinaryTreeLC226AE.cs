// #AlgoExpert #AE
// Done using both Iterative approach using BFS/Level order traversal using a queue..
// and recursive approach.


using System;
using System.Collections.Generic;

namespace Leetcode
{
    public class InvertBinaryTreeLC226AE
    {
        public TreeNode InvertTree2(TreeNode root)
        {
            if (root == null)
                return null;

            var tmp = root.left;
            root.left = root.right;
            root.right = tmp;

            InvertTree2(root.left);
            InvertTree2(root.right);
            return root;
        }

        public TreeNode InvertTree(TreeNode root)
        {
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);            
            while (q.Count > 0)
            {
                TreeNode node = q.Dequeue();
                if (node != null)
                {
                    SwapLeftRightChildren(node);
                    q.Enqueue(node.left);
                    q.Enqueue(node.right);
                }
            }
            return root;
        }

        private void SwapLeftRightChildren(TreeNode node)
        {
            var tmp = node.left;
            node.left = node.right;
            node.right = tmp;
        }
    }
}
