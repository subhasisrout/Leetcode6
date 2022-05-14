// Inspired by #Neetcode #SimpleExplanation https://www.youtube.com/watch?v=EaphyqKU4PQ
// #Graph #dijkstra

namespace Leetcode6
{
    public class NetworkDelayTimeLC743
    {
        public int NetworkDelayTime(int[][] times, int n, int k)
        {
            Dictionary<int, List<(int, int)>> graph = new Dictionary<int, List<(int, int)>>();
            for (int i = 0; i < times.Length; i++)
            {
                var path = times[i];
                if (!graph.ContainsKey(path[0]))
                    graph.Add(path[0], new List<(int, int)>());
                graph[path[0]].Add((path[1], path[2]));
            }

            int t = 0;
            HashSet<int> visited = new HashSet<int>();
            PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();
            minHeap.Enqueue(k, 0);

            while (minHeap.Count > 0)
            {
                minHeap.TryDequeue(out int node, out int time);
                if (visited.Contains(node))
                    continue;
                t = Math.Max(t, time);

                visited.Add(node);
                if (!graph.ContainsKey(node))
                    continue;
                var neiList = graph[node];
                foreach (var nei in neiList)
                {
                    if (!(visited.Contains(nei.Item1)))
                        minHeap.Enqueue(nei.Item1, time + nei.Item2);
                }
            }
            if (visited.Count == n)
                return t;
            return -1;
        }

    }
}
