using System;
using System.Collections.Generic;

// #AlgoExpert #AE #Tricky
// Note this can also be done using a MinHeap. Assuming there is already an implementation of MinHeap/PriorityQueue, 
// the minheap solution (in AlgoExpert) is lesser line of code.

namespace Leetcode
{
    public class LaptopRentalsAE
    {
        public int LaptopRentals(List<List<int>> times)
        {
            int[] incomingGuestsSorted = new int[times.Count];
            int[] outgoingGuestsSorted = new int[times.Count];
            for (int i = 0; i < times.Count; i++)
            {
                incomingGuestsSorted[i] = times[i][0];
                outgoingGuestsSorted[i] = times[i][1];
            }

            int chairCount = 0;
            Array.Sort(incomingGuestsSorted);
            Array.Sort(outgoingGuestsSorted);
            int idxIncoming = 0;
            int idxOutGoing = 0;



            while (idxIncoming < incomingGuestsSorted.Length)
            {
                if (outgoingGuestsSorted[idxOutGoing] > incomingGuestsSorted[idxIncoming])
                {
                    chairCount++;
                    idxIncoming++;
                }
                else if (outgoingGuestsSorted[idxOutGoing] <= incomingGuestsSorted[idxIncoming])
                {
                    idxOutGoing++;
                    idxIncoming++;
                }
            }



            return chairCount;
        }
    }
}
