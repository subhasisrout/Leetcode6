namespace Leetcode
{
    public class KClosestPointsToOriginLC973
    {
        public int[][] KClosest(int[][] points, int K)
        {
            //Dictionary<int, int[]> dict = new Dictionary<int, int[]>();
            int distanceSquared = 0;
            int[] point = new int[2];
            PriorityQueueFromCodeProject.PriorityQueue<int, int[]> minHeap = new PriorityQueueFromCodeProject.PriorityQueue<int, int[]>(point.Length, new IntComparer());
            for (int i = 0; i < points.Length; i++)
            {
                distanceSquared = 0;
                point = new int[2];
                for (int j = 0; j < points[i].Length; j++)
                {
                    distanceSquared += (points[i][j] * points[i][j]);
                    point[j] = points[i][j];

                }
                //dict.Add(distanceSquared, point);
                minHeap.Enqueue(distanceSquared, point);
            }
            int[][] returnVal = new int[K][];
            for (int i = 0; i < K; i++)
            {
                returnVal[i] = minHeap.DequeueValue();
            }
            return returnVal;
        }
    }

    internal class IntComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return x - y;
        }
    }
}
