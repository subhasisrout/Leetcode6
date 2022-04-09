namespace Leetcode

// #Tuple List<Tuple> passed to #PriorityQueue

{
    public class LastStoneWeightLC1046
    {
        public int LastStoneWeight(int[] stones)
        {
            //Create List<Tuple>, which is passed to the first arg of PriorityQueue
            List<(int, int)> list = new List<(int, int)>();
            for (int i = 0; i < stones.Length; i++)
                list.Add((stones[i], stones[i]));

            PriorityQueue<int, int> maxHeap = new PriorityQueue<int, int>(list, new PriorityComparer());
            while (maxHeap.Count >= 2)
            {
                var s1 = maxHeap.Dequeue();
                var s2 = maxHeap.Dequeue();
                if (s1 != s2)
                    maxHeap.Enqueue(Math.Abs(s1 - s2), Math.Abs(s1 - s2));
            }

            // if you have reached here, it means heap has 1 or 0 elements.
            if (maxHeap.Count == 1)
                return maxHeap.Dequeue();
            return 0;

        }
        class PriorityComparer : IComparer<int>
        {
            public int Compare(int p1, int p2)
            {
                return p2.CompareTo(p1);
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
