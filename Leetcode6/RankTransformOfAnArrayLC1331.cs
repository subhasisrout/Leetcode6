using System;
using System.Collections.Generic;

// #RememberPattern
// #Array copy/clone

namespace Leetcode
{
    public class RankTransformOfAnArrayLC1331
    {
        public int[] ArrayRankTransform(int[] arr)
        {
            int[] sortedArr = (int[])arr.Clone();
            Array.Sort(sortedArr);

            Dictionary<int, int> rank = new Dictionary<int, int>();
            for (int i = 0; i < sortedArr.Length; i++)
            {
                if (!rank.ContainsKey(sortedArr[i]))
                {
                    rank.Add(sortedArr[i], rank.Count + 1);
                }
            }

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rank[arr[i]];
            }
            return arr;
        }
    }
}
