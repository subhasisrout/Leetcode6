using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Idea taken from "Kenny talks code" - https://www.youtube.com/watch?v=vu7Tbpv0H18

namespace Leetcode
{
    public class ConstructBinaryTreeFromPreOrderAndInOrderLC105
    {
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            return BuildTreeHelper(0, 0, inorder.Length - 1, preorder, inorder);
        }
        private TreeNode BuildTreeHelper(int preStart, int inStart, int inEnd, int[] preorder, int[] inorder)
        {
            if (preStart >= preorder.Length) return null;
            if (inStart > inEnd) return null;

            TreeNode root = new TreeNode(preorder[preStart]);

            int inIdx = -1;
            for (int i = inStart; i <= inEnd; i++)
            {
                if (inorder[i] == preorder[preStart])
                {
                    inIdx = i;
                    break;
                }
            }

            root.left = BuildTreeHelper(preStart + 1, inStart, inIdx - 1, preorder, inorder);
            root.right = BuildTreeHelper(preStart + inIdx - inStart + 1, inIdx + 1, inEnd, preorder, inorder);
            return root;

            // preStart + inIdx - inStart + 1... means for any inorder sublist between inStart and inEnd
            // you found the root at inIdx, so just advance the "preStart" by (inIdx-inStart+1)
            // you can easily absorb by thinking about the initial case where inStart=0
        }
    }
}
