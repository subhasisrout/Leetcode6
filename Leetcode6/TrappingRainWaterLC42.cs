// Excellent solution and explanation in GoodTecher https://www.youtube.com/watch?v=wz00uI9mDXA
// #TrickySolution

using System;

namespace Leetcode
{
    public class TrappingRainWaterLC42
    {
        public int Trap(int[] heights)
        {
            int result = 0;
            if (heights == null || heights.Length == 0)
                return result;

            int[] maxHeightsOnLeft = new int[heights.Length + 1];
            maxHeightsOnLeft[0] = 0;

            for (int i = 0; i < heights.Length; i++)
            {
                maxHeightsOnLeft[i + 1] = Math.Max(heights[i], maxHeightsOnLeft[i]);
            }

            int maxHeightSoFarRight = 0;
            for (int i = heights.Length - 1; i >= 0; i--)
            {
                maxHeightSoFarRight = Math.Max(maxHeightSoFarRight, heights[i]);
                int minOfLeftAndRight = Math.Min(maxHeightSoFarRight, maxHeightsOnLeft[i]);
                if (minOfLeftAndRight > heights[i])
                    result += minOfLeftAndRight - heights[i];
            }
            return result;
        }
    }
}
