using System;
using System.Collections;
using System.Collections.Generic;

// # Implementation using LinkedList as well as inbuilt stack (with another stack<int[]>)

namespace Leetcode2
{
    public class MinStack
    {
        Node head = null;
        /** initialize your data structure here. */
        public MinStack()
        {
            
        }

        public void Push(int val)
        {
            if (head == null)
                head = new Node(val, val, null);
            else
                head = new Node(val, Math.Min(val, head.min), head);
        }

        public void Pop()
        {
            head = head.next;
        }

        public int Top()
        {
            return head.val;
        }

        public int GetMin()
        {
            return head.min;
        }
    }

    public class Node
    {

        public int min { get; private set; }
        public int val { get; private set; }
        public Node next { get; private set; }

        public Node(int val, int min, Node next)
        {
            this.val = val;
            this.next = next;
            this.min = min;
        }

        
    }

    public class MinStack2
    {
        Stack<int> stack;
        Stack<int[]> minMaxStack;
        /** initialize your data structure here. */
        public MinStack2()
        {
            stack = new Stack<int>();
            minMaxStack = new Stack<int[]>();
        }

        public void Push(int number)
        {
            if (stack.Count == 0)
            {                
                minMaxStack.Push(new int[] { number, number }); // 0th index is min and 1st index is max
            }    
            else
            {
                var currentMin = minMaxStack.Peek()[0];
                var currentMax = minMaxStack.Peek()[1];
                minMaxStack.Push(new int[] {Math.Min(number,currentMin), Math.Max(number,currentMax) });
            }
            stack.Push(number);
        }

        public void Pop()
        {
            stack.Pop();
            minMaxStack.Pop();
        }

        public int Top()
        {
            return stack.Peek();
        }

        public int GetMin()
        {
            return minMaxStack.Peek()[0];
        }
    }
}
