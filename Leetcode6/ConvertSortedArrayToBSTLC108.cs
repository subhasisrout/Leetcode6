// #RememberPattern
namespace Leetcode
{
    public class ConvertSortedArrayToBSTLC108
    {
        public TreeNode SortedArrayToBST(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return null;
            return ArrayToBSTUtil(nums, 0, nums.Length - 1);
        }

        private TreeNode ArrayToBSTUtil(int[] nums, int start, int end)
        {
            if (start > end)
                return null;

            int mid = start + (end - start) / 2;
            TreeNode node = new TreeNode(nums[mid]);
            node.left = ArrayToBSTUtil(nums, start, mid - 1);
            node.right = ArrayToBSTUtil(nums, mid + 1, end);
            return node;
        }
    }
}
