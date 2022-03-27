using System.Collections.Generic;

// The key is not only Level order traversal #BFS
// But also do the traversal from right to left <------------------
// <-----------
// <-----------
// You could also do the traversal from left to right, then you will have to keep a track of the levels and first node of the level.
// RIght to left traversal is more elegant.

namespace Leetcode
{
    public class FindBottomLeftTreeValueLC513
    {
        public int FindBottomLeftValue(TreeNode root)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            TreeNode node = null;
            while (queue.Count != 0)
            {
                node = queue.Dequeue();
                if (node.right != null) //Sequencing of pushing right first is important
                    queue.Enqueue(node.right);
                if (node.left != null)
                    queue.Enqueue(node.left);
            }
            return node.val;
        }
    }
}
