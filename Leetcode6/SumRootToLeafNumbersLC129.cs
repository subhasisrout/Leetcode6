using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Only taken the conceptual overview from Neetcode https://www.youtube.com/watch?v=Jk16lZGFWxE
// In almost all solution including Neetcode one, the dfs helper is returning the int.
// I have used backtracking approach. Similar to that of PathSum2 LC113

namespace Leetcode
{
    public class SumRootToLeafNumbersLC129
    {
        public int SumNumbers(TreeNode root)
        {
            int[] result = new int[] { 0 };
            int[] currNum = new int[] { 0 };
            SumNumbersUtil(root, currNum, result);
            return result[0];
        }
        private void SumNumbersUtil(TreeNode root, int[] currNum, int[] result)
        {
            if (root == null)
                return;

            currNum[0] = currNum[0] * 10 + root.val;

            if (root.left == null && root.right == null)
            {
                result[0] += currNum[0];
            }

            SumNumbersUtil(root.left, currNum, result);
            SumNumbersUtil(root.right, currNum, result);

            // Note the below backtracking step is not needed, if instead of accumulating to the
            // result, I directly return. 
            // But this is a pattern and can be applied in lot of problems like - PathSum2 
            currNum[0] = (currNum[0] - root.val) / 10;
        }
    }
}
