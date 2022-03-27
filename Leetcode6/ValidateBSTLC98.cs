using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// #RememberPattern

namespace Leetcode
{
    public class ValidateBSTLC98
    {
        public bool IsValidBST(TreeNode root)
        {
            return DFS(root, null, null);
        }
        private bool DFS(TreeNode root,int? max, int? min)
        {
            if (root == null)
                return true;
            else if ((max.HasValue && root.val >= max.Value) || (min.HasValue && root.val <= min.Value))
                return false;
            else
                return DFS(root.left, root.val, min) && DFS(root.right, max, root.val);
        }
    }
}
