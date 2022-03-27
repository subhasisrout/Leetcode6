namespace Leetcode
{
    public class SameTreeLC100
    {
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null || q == null)
                return p == q;

            if (p.val != q.val)
                return false;

            return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }
    }
}
