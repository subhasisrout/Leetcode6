using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// DFS is very short and easy to remember too. Also you can easily solve 2 other variants described below.
// Just remember the base condition and result[level].Add(root.val)

// 3 difference from Binary Tree Level Order Traversal II LC107
//      a. Add to the main result list in the front by using .Insert(0, item)
//      b. Instead of pre use post. i.e Add to the currList after recursion.
//      c. Add to the curr List using result[result.Count - level - 1].Add(root.val).


// 1 if condition and you will acheive Zigzag LC103.
// Condition for adding to inner List
/*
if (level % 2 == 1)
    result[level].Insert(0, root.val);
else
    result[level].Add(root.val);
*/

namespace Leetcode
{
    public class LevelOrderLC102
    {
        public IList<IList<int>> LevelOrder2(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();

            if (root == null)
                return result;

            

            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);

            Queue<TreeNode> queueForNodesForAGivenLevel = null;
            List<int> listLevel = null;
            while (q.Count != 0)
            {
                //loop for a given level
                queueForNodesForAGivenLevel = new Queue<TreeNode>();
                listLevel = new List<int>();
                
                while (q.Count != 0)
                {
                    TreeNode node = q.Dequeue();
                    queueForNodesForAGivenLevel.Enqueue(node);  // or we can use .Count and do a for loop. (from Kevin's video)               
                }
                
                while (queueForNodesForAGivenLevel.Count != 0)
                {
                    TreeNode nodeAtAGivenLevel = queueForNodesForAGivenLevel.Dequeue();
                    listLevel.Add(nodeAtAGivenLevel.val);
                    if (nodeAtAGivenLevel.left != null)
                        q.Enqueue(nodeAtAGivenLevel.left);
                    if (nodeAtAGivenLevel.right != null)
                        q.Enqueue(nodeAtAGivenLevel.right);
                }
                result.Add(listLevel);
            }
            return result;
        }

        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            LevelOrderHelper(root, result, 0);
            return result;
        }

        private void LevelOrderHelper(TreeNode root, IList<IList<int>> result, int level)
        {
            if (root == null)
                return;
            if (level == result.Count)
            result.Add(new List<int>()); //.Insert(0,..) for the second variant.

            result[level].Add(root.val); // This will be after recursion for the second variant and with [.Count - level - 1]
            LevelOrderHelper(root.left, result, level + 1);
            LevelOrderHelper(root.right, result, level + 1);

        }
    }
}
