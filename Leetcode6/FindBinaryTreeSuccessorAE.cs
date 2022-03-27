using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class FindBinaryTreeSuccessorAE
    {
		public BinaryTree FindSuccessor(BinaryTree tree, BinaryTree node)
		{
			if (node.right != null)
				return LeftMostChildOfNode(node.right);

			BinaryTree currentNode = node;
			while (currentNode.parent != null && currentNode.parent.right == currentNode)
				currentNode = currentNode.parent;

			return currentNode.parent; // this would either by NULL or the parent
		}

        private BinaryTree LeftMostChildOfNode(BinaryTree node)
        {
			while (node.left != null)
				node = node.left;
			return node;
        }
    }
	public class BinaryTree
	{
		public int value;
		public BinaryTree left = null;
		public BinaryTree right = null;
		public BinaryTree parent = null;

		public BinaryTree(int value)
		{
			this.value = value;
		}
	}
}
