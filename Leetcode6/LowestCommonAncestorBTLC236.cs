using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// #RememberPattern

namespace Leetcode
{
    public class LowestCommonAncestorBTLC236
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
                return null;

            if (root == p || root == q)
                return root;

            TreeNode fromLeft = LowestCommonAncestor(root.left, p, q);
            TreeNode fromRight = LowestCommonAncestor(root.right, p, q);

            if (fromLeft == null && fromRight == null) return null;
            else if (fromLeft != null && fromRight != null) return root;
            else if (fromLeft != null && fromRight == null) return fromLeft;
            else return fromRight;


        }
    }
}
