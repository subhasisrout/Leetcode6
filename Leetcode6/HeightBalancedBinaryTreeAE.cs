using System;

// #RememberPattern #Similar to #BinaryTreeDiameterAE on the use of #TreeInfo class
// #LC #Leetcode 110

namespace Leetcode
{
    public class HeightBalancedBinaryTreeAE
    {
        public bool HeightBalancedBinaryTree(BinaryTree tree)
        {
            return GetTreeInfo(tree).IsBalanced;
        }

        internal TreeInfo GetTreeInfo(BinaryTree node)
        {
            if (node == null)
                return new TreeInfo(true, -1);

            var leftTreeInfo = GetTreeInfo(node.left);
            var rightTreeInfo = GetTreeInfo(node.right);

            var isBalanced = leftTreeInfo.IsBalanced && rightTreeInfo.IsBalanced && Math.Abs(leftTreeInfo.Height - rightTreeInfo.Height) <= 1;
            var height = 1 + Math.Max(leftTreeInfo.Height, rightTreeInfo.Height);
            return new TreeInfo(isBalanced, height);
        }

        internal class TreeInfo
        {
            public bool IsBalanced { get; set; }
            public int Height { get; set; }
            public TreeInfo(bool isBalanced, int height)
            {
                this.IsBalanced = isBalanced;
                this.Height = height;
            }
        }
        public class BinaryTree
        {
            public int value;
            public BinaryTree left = null;
            public BinaryTree right = null;

            public BinaryTree(int value)
            {
                this.value = value;
            }
        }
    }
}
