using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class SubtreeOfAnotherTreeLC572
    {
        public bool IsSubtree(TreeNode s, TreeNode t)
        {
            if (s == null)
                return false;
            else if (IsSameTree(s, t))
                return true;
            else return IsSubtree(s.left, t) || IsSubtree(s.right, t);

        }

        // The below helper method is similar helper method SymmetricTreeLC101

        private bool IsSameTree(TreeNode s, TreeNode t)
        {
            if (s == null || t == null)
                return s == t;
            else if (s.val != t.val)
                return false;
            else
                return IsSameTree(s.left, t.left) && IsSameTree(s.right, t.right);
            
        }
    }
}
