using System;

// #AE #Good explantion in AE #RememberPattern
// #Leetcode #LC 543

namespace Leetcode
{
    public class BinaryTreeDiameterAE
    {
		public int BinaryTreeDiameter(BinaryTree tree)
		{
			return this.BinaryTreeDiameterHelper(tree).Diameter;
		}
		internal TreeInfo BinaryTreeDiameterHelper(BinaryTree tree)
        {
			if (tree == null)
				return new TreeInfo(0, 0);

			var leftTreeInfo = BinaryTreeDiameterHelper(tree.left);
			var rightTreeInfo = BinaryTreeDiameterHelper(tree.right);

			var maxDiameterSoFar = Math.Max(leftTreeInfo.Diameter, rightTreeInfo.Diameter);			
			var currentDiameter = Math.Max(maxDiameterSoFar, leftTreeInfo.Height + rightTreeInfo.Height);

			var currentHeight = 1 + Math.Max(leftTreeInfo.Height, rightTreeInfo.Height);
			return new TreeInfo(currentDiameter, currentHeight);
		}
		public class BinaryTree
		{
			public int value;
			public BinaryTree left;
			public BinaryTree right;

			public BinaryTree(int value)
			{
				this.value = value;
			}
		}
		internal class TreeInfo
		{
			public int Diameter { get; set; }
			public int Height { get; set; }
			public TreeInfo(int diameter, int height)
			{
				this.Diameter = diameter;
				this.Height = height;
			}
		}
	}
	
}
