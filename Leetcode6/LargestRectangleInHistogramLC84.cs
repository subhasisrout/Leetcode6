using System;
using System.Collections.Generic;

// #RememberPattern
// #Stack #MonotonicStack
// This solution found in https://www.youtube.com/watch?v=0do2734xhnU
// is more #intuitive than #AlgoExpert #AE.
// This is mainly dividing the solution into 3 parts - finding lb, finding rb and calculating areas.
// find lb and rb can be done using brute force by looking all elements, all time. This uses Stack.
// Note lb[0] is -1 because we are storing index of "next smaller element". similarly rb[lastindex] = totalLength.


namespace Leetcode
{
    public class LargestRectangleInHistogramLC84
    {
        public int LargestRectangleArea(int[] heights)
        {            
            int maxArea = 0;
            int[] lb = new int[heights.Length];
            int[] rb = new int[heights.Length];
            Stack<int> stack = new Stack<int>();

            // fill lb (left bound) i.e. "next small element index" on the left
            lb[0] = -1;
            stack.Push(0);
            for (int i = 1; i < heights.Length; i++)
            {
                int currentHeight = heights[i];
                while (stack.Count != 0 && heights[stack.Peek()] >= currentHeight)
                {
                    stack.Pop();
                }

                // The goal of this for loop is to fill the lb[i] values.
                // If we have reached here - it means either the stack is empty or stackTop is < currentHeight 
                if (stack.Count == 0)
                    lb[i] = -1;
                else
                    lb[i] = stack.Peek();

                stack.Push(i);
            }


            // fill rb (right bound) i.e. "next small element index" on the right
            stack.Clear();
            rb[heights.Length - 1] = heights.Length; // as opposed to -1 for lb
            // just like 0-1 for lb, it is heights.Length -1 + 1 for rb. Note its the index.
            stack.Push(heights.Length - 1);
            for (int i = heights.Length - 2; i >= 0; i--)
            {
                int currentHeight = heights[i];
                while (stack.Count > 0 && heights[stack.Peek()] >= currentHeight)
                {
                    stack.Pop();
                }

                // The goal of this for loop is to fill the rb[i] values.
                // If we have reached here - it means either the stack is empty or stackTop is < currentHeight
                if (stack.Count == 0)
                    rb[i] = heights.Length;
                else
                    rb[i] = stack.Peek();

                stack.Push(i);
            }

            // calc areas
            for (int i = 0; i < heights.Length; i++)
            {
                int currentHeight = heights[i];
                int currentArea = currentHeight * (rb[i] - lb[i] - 1);
                maxArea = Math.Max(maxArea, currentArea);
            }
            return maxArea;
        }
    }
}
