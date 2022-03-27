using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class DeleteNodesReturnForestLC1110
    {
        public IList<TreeNode> DelNodes(TreeNode root, int[] to_delete)
        {
            List<TreeNode> remaining = new List<TreeNode>();
            HashSet<int> toDelete = new HashSet<int>();
            for (int i = 0; i < to_delete.Length; i++)
            {
                toDelete.Add(to_delete[i]);
            }

            RemoveNodes(root, toDelete, remaining);
            if (!toDelete.Contains(root.val))
                remaining.Add(root);

            return remaining;
 
        }

        private TreeNode RemoveNodes(TreeNode root, HashSet<int> toDelete, List<TreeNode> remaining)
        {
            if (root == null)
                return null;

            root.left = RemoveNodes(root.left, toDelete, remaining);
            root.right = RemoveNodes(root.right, toDelete, remaining);

            if (toDelete.Contains(root.val))
            {
                if (root.left != null)
                    remaining.Add(root.left);
                if (root.right != null)
                    remaining.Add(root.right);

                return null;
            }
            return root;
        }
    }
}
