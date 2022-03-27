using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// #PriorityQueue #Heap #.NET6
// Inspired from #Neetcode https://www.youtube.com/watch?v=8u-H6O_XQKE

namespace Leetcode6
{
    public class LongestHappyStringLC1405
    {
        public string LongestDiverseString(int a, int b, int c)
        {
            PriorityQueue<char, int> queue = new PriorityQueue<char, int>(new PriorityComparer());
            if (a != 0) queue.Enqueue('a', a);
            if (b != 0) queue.Enqueue('b', b);
            if (c != 0) queue.Enqueue('c', c);

            StringBuilder sb = new StringBuilder();

            while (queue.Count > 0)
            {
                queue.TryDequeue(out char maxItemChar, out int maxItemCount);
                if (sb.Length > 1 && sb[sb.Length - 1] == maxItemChar && sb[sb.Length - 2] == maxItemChar)
                {
                    if (queue.Count == 0) break;
                    queue.TryDequeue(out char secondMaxItemChar, out int secondMaxItemCount);
                    sb.Append(secondMaxItemChar);
                    if (secondMaxItemCount - 1 != 0)
                        queue.Enqueue(secondMaxItemChar, secondMaxItemCount - 1);
                }
                else
                {
                    sb.Append(maxItemChar);
                    maxItemCount = maxItemCount - 1;
                }

                //In both cases, do the following
                if (maxItemCount != 0)
                    queue.Enqueue(maxItemChar, maxItemCount);
            }

            return sb.ToString();
        }
        class PriorityComparer : IComparer<int>
        {
            public int Compare(int p1, int p2)
            {
                return p2.CompareTo(p1);
            }
        }
    }
}
