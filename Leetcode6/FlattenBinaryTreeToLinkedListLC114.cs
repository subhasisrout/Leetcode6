// Inspired from #Neetcode #Clear explaination at https://www.youtube.com/watch?v=rKnD7rLT0lI
namespace Leetcode6
{
    public class FlattenBinaryTreeToLinkedListLC114
    {
        public void Flatten(TreeNode root)
        {
            dfs(root);
            TreeNode dfs(TreeNode root)
            {
                if (root == null)
                    return null;

                var leftTail = dfs(root.left);
                var rightTail = dfs(root.right);
                if (root.left != null) //works with both (leftTail != null) (root.left != null)
                {
                    leftTail.right = root.right; // stick the leftTail (flattened left subtree) to roots right.
                    root.right = root.left;
                    root.left = null;
                }
                // Above 3 lines does all the pointer changes and the sequence is IMP.
                // Note root.right is modified AFTER is used.
                // Note root.left is modified AFTER is used.

                //this DFS returns a node.
                //We want to return the rightTail, if thats not present return leftTail, if thats not present return the node itself
                if (rightTail != null)
                    return rightTail;
                else if (leftTail != null)
                    return leftTail;
                return root;
            }

        }
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
    }
}
