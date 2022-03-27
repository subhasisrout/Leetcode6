// #RememberPattern
// Learnt from Leetcode discussions

namespace Leetcode
{
    public class MaximumBinaryTreeLC654
    {
        public TreeNode ConstructMaximumBinaryTree(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return null;
            return MaxBinTreeUtil(nums, 0, nums.Length - 1);

        }

        public TreeNode MaxBinTreeUtil(int[] nums, int start, int end)
        {
            if (start > end)
                return null;

            int maxIndex = start;
            for (int i = start + 1; i <= end; i++)
            {
                if (nums[i] > nums[maxIndex])
                    maxIndex = i;
            }

            TreeNode treeNode = new TreeNode(nums[maxIndex]);

            treeNode.left = MaxBinTreeUtil(nums, start, maxIndex - 1);
            treeNode.right = MaxBinTreeUtil(nums, maxIndex + 1, end);
            return treeNode;
        }
    }
}
