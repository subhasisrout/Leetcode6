using PriorityQueueFromCodeProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class MinCostToConnectSticksLC1167Premium
    {
        public int ConnectSticks(int[] sticks)
        {
            int cost = 0;

            PriorityQueueFromCodeProject.PriorityQueue<int, int> minHeap = new PriorityQueueFromCodeProject.PriorityQueue<int, int>(sticks.Length, new SticksLengthComparer());
            for (int i = 0; i < sticks.Length; i++)
            {
                minHeap.Enqueue(sticks[i], sticks[i]);
            }

            while (minHeap.Count >=2)
            {
                int sum = minHeap.DequeueValue() + minHeap.DequeueValue();
                cost += sum;
                minHeap.Enqueue(sum, sum);
            }


            return cost;
        }

    }
    public class SticksLengthComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return x - y;
        }
    }
}
