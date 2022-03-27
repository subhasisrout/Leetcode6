using System;
using System.Collections.Generic;

// Note a valid #BST have left child STRICTLY less than the parent and right child could be equal to or greater than the parent.
// left child < parent <= right child
// #List.GetRange method is useful for slicing
// #Leetcode #LC 1008


namespace Leetcode
{
    public class ReconstructBSTAE
    {
		public class BST
		{
			public int value;
			public BST left = null;
			public BST right = null;

			public BST(int value)
			{
				this.value = value;
			}
		}

        // Approach 1 - ( O(n^2) time)
        /*public BST ReconstructBst(List<int> preOrderTraversalValues)
        {
            if (preOrderTraversalValues.Count == 0)
                return null;

            BST rootNode = new BST(preOrderTraversalValues[0]);
            int rightNodeIdx = preOrderTraversalValues.Count;
            for (int i = 1; i < preOrderTraversalValues.Count; i++)
            {
                if (preOrderTraversalValues[i] > preOrderTraversalValues[0])
                {
                    rightNodeIdx = i;
                    break;
                }
            }

            var leftSubtree = ReconstructBst(preOrderTraversalValues.GetRange(1, rightNodeIdx - 1));
            var rightSubtree = ReconstructBst(preOrderTraversalValues.GetRange(rightNodeIdx, (preOrderTraversalValues.Count - rightNodeIdx)));
            rootNode.left = leftSubtree;
            rootNode.right = rightSubtree;
            return rootNode;
        }*/

        class TreeInfo
        {
            public int RootIdx { get; set; }
            public TreeInfo(int rootIdx)
            {
                this.RootIdx = rootIdx;
            }
        }

        public BST ReconstructBst(List<int> preOrderTraversalValues)
        {
            TreeInfo treeInfo = new TreeInfo(0);
            return ConstructBST(Int32.MinValue, Int32.MaxValue, preOrderTraversalValues, treeInfo);
        }

        // Approach 2. #Tightening the constraints (#lowerBound and #upperBound). Time complexity O(n). 
        // Looks like this approach will work for all kind of list (inOrder, PreOrder, PostOrder).
        // Obviosly for InOrder traversal, we can do in logarithmic times (because its sorted).
        private BST ConstructBST(int lowerBound, int upperBound, List<int> preOrderTraversalValues, TreeInfo currentSubtree)
        {
            if (currentSubtree.RootIdx == preOrderTraversalValues.Count)
                return null;

            int currentSubtreeRootIdx = currentSubtree.RootIdx;
            int currentSubtreeVal = preOrderTraversalValues[currentSubtreeRootIdx];

            if (currentSubtreeVal < lowerBound || currentSubtreeVal >= upperBound)
                return null;

            currentSubtree.RootIdx = currentSubtree.RootIdx + 1;
            var leftSubtree = ConstructBST(lowerBound, currentSubtreeVal, preOrderTraversalValues, currentSubtree);
            var rightSubtree = ConstructBST(currentSubtreeVal, upperBound, preOrderTraversalValues, currentSubtree);
            BST root = new BST(currentSubtreeVal);
            root.left = leftSubtree;
            root.right = rightSubtree;
            return root;
        }
    }
}
