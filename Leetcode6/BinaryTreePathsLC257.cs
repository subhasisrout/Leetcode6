using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class BinaryTreePathsLC257
    {
        public IList<string> BinaryTreePaths(TreeNode root)
        {
            IList<string> paths = new List<string>();
            if (root == null)
                return paths;

            DFS(root, "", paths);

            return paths;
        }
        private void DFS(TreeNode root,string path, IList<string> paths)
        {
            path += root.val.ToString();

            if (root.left == null && root.right == null)
            {
                paths.Add(path);
                return;
            }

            if (root.left != null)
                DFS(root.left, path + "->", paths);
            if (root.right != null)
                DFS(root.right, path + "->", paths);
        }
    }
}
