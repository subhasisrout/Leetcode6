// #RememberPattern
namespace Leetcode
{
    public class InsertToBSTLC701
    {
        public TreeNode InsertIntoBST(TreeNode root, int val)
        {
            if (root == null)
            {
                root = new TreeNode(val);
                return root;
            }
            else if (root.val < val)
            {
                root.right = InsertIntoBST(root.right, val);
            }
            else
            {
                root.left = InsertIntoBST(root.left, val);
            }
            return root;
        }
    }
}
