using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class LastStoneWeightLC1046
    {
        public int LastStoneWeight(int[] stones)
        {
            Leetcode2.MaxHeap maxHeap = new Leetcode2.MaxHeap(stones.ToList());
            while (maxHeap.Size() > 2)
            {
                int largestWeight = maxHeap.Remove();
                int secondLargestWeight = maxHeap.Remove();
                if (largestWeight != secondLargestWeight)
                    maxHeap.Insert(largestWeight - secondLargestWeight);
            }
            if (maxHeap.Size() == 1)
                return maxHeap.Remove();
            else // exactly 2 items
            {
                return maxHeap.Remove() - maxHeap.Remove();
            }

            
        }
        public int LastStoneWeightSort(int[] stones)
        {
            Array.Sort(stones);
            int i = stones.Length - 1;
            while (i != 0)
            {
                int diff = stones[i] - stones[i - 1];
                if (diff == 0)
                {
                    i = i - 2;
                    if (i == -1) //special case when array looks like [2,2]
                        return 0;
                }
                else
                {
                    i = i - 1;
                    stones[i - 1] = diff;
                }
            }
            return stones[i];
        }
    }
}
