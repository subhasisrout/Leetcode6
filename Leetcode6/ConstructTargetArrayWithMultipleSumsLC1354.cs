// #Heap #PriorityQueue #Hard
// Inspired from https://www.youtube.com/watch?v=wTwKzSOthEM with step-by-step non-modulo explanation followed by modulo


namespace Leetcode6
{
    public class ConstructTargetArrayWithMultipleSumsLC1354
    {
        public bool IsPossible(int[] target)
        {
            if (target.Length == 1) return target[0] == 1; //special case

            PriorityQueue<int, int> maxHeap = new PriorityQueue<int, int>(new CustomComparer());
            int total = 0;
            for (int i = 0; i < target.Length; i++)
            {
                total += target[i];
                maxHeap.Enqueue(target[i], target[i]);
            }
            while (maxHeap.Peek() > 1) //if we got 1. meaning all are 1's.
            {
                int max = maxHeap.Dequeue();
                int remain = total - max;

                if (remain == 1) //always true with [100,1]
                    return true;

                int pre = max % remain; //from max - remain

                // pre == max condition needed for [1,1,1,2]
                // max = 2, sum = 5, remain = 3..... so pre becomes 2%3 = 2
                if (pre < 1 || pre == max)
                    return false;

                maxHeap.Enqueue(pre, pre);
                total += pre - max;

            }
            return true;
        }

        class CustomComparer : IComparer<int>
        {

            public int Compare(int p1, int p2)
            {
                return p2.CompareTo(p1);
            }
        }
    }
}
