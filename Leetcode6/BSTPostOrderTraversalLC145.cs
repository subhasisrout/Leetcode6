using System.Collections.Generic;

namespace Leetcode
{
    public class BSTPostOrderTraversalLC145
    {
        public IList<int> PostorderTraversal(TreeNode root)
        {
            IList<int> retval = new List<int>();
            if (root == null)
                return retval;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count != 0)
            {
                TreeNode curr = stack.Pop();
                retval.Insert(0, curr.val);
                if (curr.left != null)
                    stack.Push(curr.left);
                if (curr.right != null)
                    stack.Push(curr.right);
            }

            //PostOrderTraversalUtil(root, retval);
            return retval;
        }
        public void PostOrderTraversalUtil(TreeNode root, IList<int> retval)
        {
            if (root == null)
                return;
            PostOrderTraversalUtil(root.left, retval);
            PostOrderTraversalUtil(root.right, retval);
            retval.Add(root.val);

        }
    }
}
