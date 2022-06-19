// #Hard #Greedy #State #BinaryTree #DFS
// Added 2 solution from Leetcode solution and discussions.

// Greedy Approach (HashSet based) is intuitive.
namespace Leetcode6
{
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

    public class MinCameraCoverLC968
    {
        // Greedy approach
        public int MinCameraCover(TreeNode root)
        {
            int ans = 0;
            HashSet<TreeNode?> coveredSet = new HashSet<TreeNode?>();
            coveredSet.Add(null);
            DFS(root, null);
            return ans;

            void DFS(TreeNode node, TreeNode? parent)
            {
                if (node != null)
                {
                    DFS(node.left, node);
                    DFS(node.right, node);

                    //if its a root node OR 1 above the leaf node.
                    if (
                        (parent == null && !coveredSet.Contains(node))
                        ||
                        (!coveredSet.Contains(node.left) || !coveredSet.Contains(node.right))
                       )
                    {
                        coveredSet.Add(node);
                        coveredSet.Add(node.left);
                        coveredSet.Add(node.right);
                        coveredSet.Add(parent);
                        ans++;
                    }

                }
            }

        }

        // Using States with DFS
        public int MinCameraCover2(TreeNode root)
        {
            int ans = 0;
            return (DFS(root) == CameraState.PLEASE_COVER) ? ++ans : ans;

            CameraState DFS(TreeNode root)
            {
                if (root == null)
                    return CameraState.COVERED;

                CameraState lState = DFS(root.left);
                CameraState rState = DFS(root.right);

                if (lState == CameraState.PLEASE_COVER || rState == CameraState.PLEASE_COVER)
                {
                    ans++;
                    return CameraState.HAS_CAMERA;
                }

                if (lState == CameraState.HAS_CAMERA || rState == CameraState.HAS_CAMERA)
                {
                    return CameraState.COVERED;
                }

                return CameraState.PLEASE_COVER;
            }
        }

        public enum CameraState
        {
            HAS_CAMERA,
            COVERED,
            PLEASE_COVER
        }
    }
}
