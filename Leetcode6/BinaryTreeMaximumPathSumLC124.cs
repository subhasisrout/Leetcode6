using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Present in #AE, but solution not elegant.

namespace Leetcode
{
    public class BinaryTreeMaximumPathSumLC124
    {
        int result = Int32.MinValue;
        public int MaxPathSum(TreeNode root)
        {
            DFSPostOrder(root);
            return result;
        }
        private int DFSPostOrder(TreeNode root)
        {
            if (root == null)
                return 0;
            int left = Math.Max(0, DFSPostOrder(root.left)); //if -ve just discard the entire subtree. you are better off not taking it
            int right = Math.Max(0, DFSPostOrder(root.right));
            result = Math.Max(result, left + right + root.val); //triangle can also be a result like this /\
            return Math.Max(left, right) + root.val; // at any given node, return only max of left OR right + VAL
                                                     //as  this cannot be a valid path  \
                                                     //                                 /\
                                                     // you have to pick one path.
        }
    }
}
