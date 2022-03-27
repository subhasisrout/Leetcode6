using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// #RememberPattern

namespace Leetcode
{
    public class KthSmallestInBSTLeetcode230
    {
        public int KthSmallest(TreeNode root, int k)
        {
            int[] nums = new int[2];
            Inorder(root, k, nums);
            return nums[1];
        }
        public void Inorder(TreeNode root, int k,int[] nums)
        {
            if (root == null)
                return;

            Inorder(root.left, k, nums);
            nums[0] = nums[0] + 1;
            if (nums[0] == k)
            {
                nums[1] = root.val;
                return;
            }
            Inorder(root.right, k, nums);
        }

        public int FindMin(TreeNode node)
        {
            if (node != null && node.left == null)
                return node.val;
            else
                return FindMin(node.left);
        }
    }
}
