using System;
using System.Linq;

// #Leetcode #LC 198 House Robber. Different terminology but exactly same algorithm and dynamic programming principles.

namespace Leetcode
{
    public class MaxSubsetSumNoAdjacentAE
    {
        public static int MaxSubsetSumNoAdjacent(int[] array)
        {
            if (array == null || array.Length == 0) return 0;
            if (array.Length <= 2) return array.Max();

            int[] dpArr = new int[array.Length];
            dpArr[0] = array[0];
            dpArr[1] = Math.Max(array[0], array[1]);

            for (int i = 2; i < array.Length; i++)
            {
                dpArr[i] = Math.Max(dpArr[i - 1], array[i] + dpArr[i - 2]);
            }
            return dpArr[array.Length - 1];
        }
    }
}
