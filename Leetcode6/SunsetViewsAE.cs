// #Self implementation. My solution is much easier and intuitive than #AlgoExpert #AE

using System.Collections.Generic;

namespace Leetcode
{
    public class SunsetViewsAE
    {
        public List<int> SunsetViews(int[] buildings, string direction)
        {
            List<int> result = new List<int>();
            int currMax = -1;
            if (direction == "WEST")
            {
                for (int i = 0; i < buildings.Length; i++)
                {
                    if (buildings[i] > currMax)
                    {
                        result.Add(i);
                        currMax = buildings[i];
                    }

                }
            }
            else
            {
                for (int i = buildings.Length - 1; i >= 0; i--)
                {
                    if (buildings[i] > currMax)
                    {
                        result.Add(i);
                        currMax = buildings[i];
                    }

                }
                result.Reverse();
            }
            return result;
        }
    }
}
