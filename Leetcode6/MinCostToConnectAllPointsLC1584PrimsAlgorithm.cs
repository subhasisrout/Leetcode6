
// #Point is represented by its index. [0...N-1]
// #Prim #MinimumSpanningTree #MST
// Easy explaination by #NeetCode at https://www.youtube.com/watch?v=f7JOBJIC-NA

namespace Leetcode6
{
    public class MinCostToConnectAllPointsLC1584PrimsAlgorithm
    {
        public int MinCostConnectPoints(int[][] points)
        {
            // Creation of adjList. pointIdx -> List of (cost, pointIdx)
            Dictionary<int, List<PointCost>> adjList = new Dictionary<int, List<PointCost>>();
            for (int i = 0; i < points.Length; i++)
                adjList.Add(i, new List<PointCost>());
            for (int i = 0; i < points.Length; i++)
            {
                for (int j = i + 1; j < points.Length; j++)
                {
                    var dist = Math.Abs(points[i][0] - points[j][0]) + Math.Abs(points[i][1] - points[j][1]);
                    adjList[i].Add(new PointCost() { PointIdx = j, Cost = dist });
                    adjList[j].Add(new PointCost() { PointIdx = i, Cost = dist }); //bi-directional
                }
            }

            //Prim's Algorithm for MST (Minimum spanning tree)
            int cost = 0;
            HashSet<int> visited = new HashSet<int>();
            PriorityQueue<int, int> priorityQueue = new PriorityQueue<int, int>();
            priorityQueue.Enqueue(0, 0);
            while (visited.Count != points.Length)
            {
                priorityQueue.TryDequeue(out int minCostPointIdx, out int minCost);
                if (visited.Contains(minCostPointIdx))
                    continue;
                cost += minCost;
                visited.Add(minCostPointIdx);

                var neiList = adjList[minCostPointIdx];
                foreach (var nei in neiList)
                {
                    if (!visited.Contains(nei.PointIdx))
                        priorityQueue.Enqueue(nei.PointIdx, nei.Cost);
                }
            }


            return cost;

        }

        class PointCost
        {
            public int Cost { get; set; }
            public int PointIdx { get; set; }

        }
    }
}
