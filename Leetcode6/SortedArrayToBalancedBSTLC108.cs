using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class SortedArrayToBalancedBSTLC108
    {
        public TreeNode SortedArrayToBST(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return null;

            return ArrayToBstUtil(nums, 0, nums.Length - 1);

        }

        private TreeNode ArrayToBstUtil(int[] nums, int left, int right)
        {
            if (left > right)
                return null;

            int mid = left + (right - left) / 2;
            TreeNode current = new TreeNode(nums[mid]);

            current.left = ArrayToBstUtil(nums, left, mid - 1);
            current.right = ArrayToBstUtil(nums, mid + 1, right);

            return current;
        }
    }
}
