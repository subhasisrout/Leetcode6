using System;
using System.Collections.Generic;


// #Clever #Maths 
// Approach - Find any diagonal say (\). Now look for its other pair i.e (/)

namespace Leetcode
{
    public class MinimumAreaRectangleLC939
    {
        public int MinAreaRect(int[][] points)
        {
            HashSet<string> pointsSet = new HashSet<string>();
            int minArea = Int32.MaxValue;
            for (int i = 0; i < points.Length; i++)
                pointsSet.Add(points[i][0] + "#" + points[i][1]);

            for (int i = 0; i < points.Length; i++)
            {
                for (int j = 0; j < points.Length; j++)
                {
                    if (i == j)
                        continue;

                    int[] point1 = points[i];
                    int[] point2 = points[j];

                    // if they are in same line, continue.
                    if (!(point1[0] != point2[0] && point1[1] != point2[1]))
                        continue;

                    string desiredPoint1 = point1[0] + "#" + point2[1];
                    string desiredPoint2 = point2[0] + "#" + point1[1];

                    if (pointsSet.Contains(desiredPoint1) && pointsSet.Contains(desiredPoint2))
                    {
                        int area = Convert.ToInt32(Math.Abs(point1[0] - point2[0]) * Math.Abs(point1[1] - point2[1]));
                        minArea = Math.Min(minArea, area);
                    }
                }
            }
            return minArea == Int32.MaxValue ? 0 : minArea;
        }
    }
}
