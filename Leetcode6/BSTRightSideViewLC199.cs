using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class BSTRightSideViewLC199
    {
        public IList<int> RightSideView(TreeNode root)
        {
            List<int> result = new List<int>();
            if (root == null)
                return new List<int>();

            return BFS(root);

        }

        private List<int> BFS(TreeNode root)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            Queue<TreeNode> innerQ = new Queue<TreeNode>();
            List<int> result = new List<int>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                //Dequeue all elements and store the last element
                TreeNode lastElementInLevel = null;
                while (queue.Count > 0)
                {                    
                    lastElementInLevel = queue.Dequeue();
                    innerQ.Enqueue(lastElementInLevel);
                }
                //END
                result.Add(lastElementInLevel.val);
                while (innerQ.Count > 0)
                {
                    var x = innerQ.Dequeue();
                    if (x.left != null) queue.Enqueue(x.left);
                    if (x.right != null) queue.Enqueue(x.right);
                }
            }
            return result;
        }
    }
    
}
