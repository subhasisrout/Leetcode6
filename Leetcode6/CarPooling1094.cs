namespace Leetcode6

// Inspired from #Neetcode #PriorityQueue #Array.Sort using lambda


{
    public class CarPooling1094
    {
        public bool CarPooling(int[][] trips, int capacity)
        {
            int currPass = 0;
            Array.Sort(trips, (a, b) => a[1].CompareTo(b[1]));

            PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();
            for (int i = 0; i < trips.Length; i++)
            {
                var currTrip = trips[i];

                while (minHeap.Count > 0 && minHeap.TryPeek(out int numPass, out int dest) && currTrip[1] >= dest)
                {
                    minHeap.Dequeue();
                    currPass -= numPass;
                }
                currPass += currTrip[0];
                minHeap.Enqueue(currTrip[0], currTrip[2]);

                if (currPass > capacity)
                    return false;

            }
            return true;
        }
    }
}

