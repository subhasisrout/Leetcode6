// #BFS #Level Order Traversal
// Level Order is more intuitive.
// If you want to use DFS. You can first find the maxDepth (height) of the tree (easy) and find the left and right sum for that level.

namespace Leetcode6
{
    public class DeepestLeavesSumLC1302
    {
        public int DeepestLeavesSum(TreeNode root)
        {
            Queue<TreeNode> q = new Queue<TreeNode>();
            int sum = 0;
            q.Enqueue(root);
            while (q.Count > 0)
            {
                int size = q.Count;
                sum = 0;
                while (size > 0)
                {
                    var node = q.Dequeue();
                    sum += node.val;
                    if (node.left != null)
                        q.Enqueue(node.left);
                    if (node.right != null)
                        q.Enqueue(node.right);
                    size--;
                }
            }
            return sum;
        }

        public int DeepestLeavesSum2(TreeNode root)
        {

            int height = MaxDepth(root);
            return MaxAtLevel(root, height);

            int MaxAtLevel(TreeNode root, int maxLevel) // Step 2 - Find sum for that height
            {
                if (root == null)
                    return 0;

                if (maxLevel == 1)
                    return root.val;

                return MaxAtLevel(root.left, maxLevel - 1) + MaxAtLevel(root.right, maxLevel - 1);
            }
            int MaxDepth(TreeNode root) //Step 1 - Find the height
            {
                if (root == null)
                    return 0;
                else
                {
                    int ldepth = MaxDepth(root.left);
                    int rdepth = MaxDepth(root.right);
                    if (ldepth > rdepth)
                        return ldepth + 1;
                    else
                        return rdepth + 1;
                }
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
