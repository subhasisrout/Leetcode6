namespace Leetcode
{
    // #PriorityQueue #Heap #.NET6
    // #StraightForward use of PriorityQueue
    public class KClosestPointsToOriginLC973
    {
        public int[][] KClosest(int[][] points, int k)
        {
            PriorityQueue<int[], int> queue = new PriorityQueue<int[], int>();
            for (int i = 0; i < points.Length; i++)
            {
                var currPoint = points[i];
                var distanceSquared = currPoint[0] * currPoint[0] + currPoint[1] * currPoint[1];
                queue.Enqueue(currPoint, distanceSquared);
            }

            int[][] result = new int[k][];
            for (int i = 0; i < k; i++)
            {
                result[i] = queue.Dequeue();
            }
            return result;
        }
    }
}
