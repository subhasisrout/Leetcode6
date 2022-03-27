using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class LargestRectangleUnderSkylineAE
    {
        public int LargestRectangleUnderSkyline(int[] heights)
        {
            Stack<int> indicesStack = new Stack<int>();
            int maxArea = 0;
            var heights2 = heights.ToList();
            heights2.Add(0); // Adding an extra building of height 0.
            for (int i = 0; i < heights2.Count; i++)
            {
                int currentHeight = heights2[i];
                while (indicesStack.Count != 0 && heights2[indicesStack.Peek()] >= currentHeight)
                {
                    var pillarHeight = heights2[indicesStack.Pop()];
                    int width;
                    if (indicesStack.Count == 0)
                        width = i;
                    else
                        width = i - indicesStack.Peek() - 1;

                    maxArea = Math.Max(maxArea, width * pillarHeight);
                }
                indicesStack.Push(i);
            }
            return maxArea;
        }
    }
}
