using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Inspired from https://www.youtube.com/watch?v=vu7Tbpv0H18&t=935s Kenny Talks code
// Iterative solution. Rarely you see iterative solutions for binary trees
// Its just about 2 pointers. One for going down (outer loop) and one for going right (inner loop)

namespace LeetcodeLC116
{
    public class PopulatingNextRightPointersInEachNodeLC116
    {
        public Node Connect(Node root)
        {
            Node levelStart = root;
            while (levelStart != null)
            {
                Node curr = levelStart;
                while (curr != null)
                {
                    if (curr.left != null)
                        curr.left.next = curr.right;
                    if (curr.right != null && curr.next != null)
                        curr.right.next = curr.next.left;
                    
                    curr = curr.next; // This is automatically taken care by the above pointer assignments. Try visualizing with 1-2-3-4-5-6-7 (perfect binary tree)            
                    //above line is for "go right"
                }
                levelStart = levelStart.left; //go down
            }
            return root;
        }

    }
    public class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node next;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, Node _left, Node _right, Node _next)
        {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
    }
    
}
