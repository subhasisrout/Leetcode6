using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class MaxAreaLC11
    {
        public int MaxArea(int[] height)
        {
            int i = 0;
            int j = height.Length - 1;
            int maxArea = -1;

            while (i < j)
            {
                int currMaxArea = Math.Min(height[i], height[j]) * (j - i);
                if (currMaxArea > maxArea)
                    maxArea = currMaxArea;

                if (height[i] < height[j])
                    i++;
                else
                    j--;
            }
            return maxArea;

        }
    }
}
