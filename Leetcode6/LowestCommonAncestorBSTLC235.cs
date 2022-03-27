using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// #RememberPattern

namespace Leetcode
{
    public class LowestCommonAncestorBSTLC235
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            return GetLCA(root, p, q);
        }

        private TreeNode GetLCA(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root.val > p.val && root.val > q.val)
                return GetLCA(root.left, p, q);
            else if (root.val < p.val && root.val < q.val)
                return GetLCA(root.right, p, q);
            else
                return root;
        }
    }
}
