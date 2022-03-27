using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class SumOfRootToLeafLC1022
    {
        // naive solution from me (O of n squared)
        public int SumRootToLeaf(TreeNode root)
        {
            int[] pathvals = new int[1000];
            int sum = 0;
            DFS(root, pathvals, 0, ref sum);
            return sum;
        }

        private void DFS(TreeNode root, int[] pathvals, int level, ref int sum)
        {
            if (root == null)
                return;

            pathvals[level] = root.val;
            level++;

            if (root.left == null && root.right == null)
            {
                int pathSum = GetNumFromBin(pathvals, level);
                sum += pathSum;
            }

            DFS(root.left, pathvals, level, ref sum);
            DFS(root.right, pathvals, level, ref sum);
        }

        private int GetNumFromBin(int[] pathvals, int level)
        {
            int result = 0;
            int exp = 0;
            for (int i = level - 1; i >= 0; i--)
            {
                if (pathvals[i] == 1)
                    result += Convert.ToInt32(Math.Pow(2, exp));
                exp++;
            }
            return result;
        }

        // Optimized (from leetcode)
        public int SumRootToLeaf2(TreeNode root)
        {
            if (root == null)
                return 0;
            int sum = 0;
            DFS(root, root.val, ref sum);
            return sum;
        }

        private void DFS(TreeNode root, int current, ref int sum)
        {
            if (root == null)
                return;

            if (root.left == null && root.right == null)
                sum += current;

            if (root.left != null)
                DFS(root.left, 2 * current + root.left.val, ref sum);

            if (root.right != null)
                DFS(root.right, 2 * current + root.right.val, ref sum);

        }
    }
}
