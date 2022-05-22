namespace Leetcode6
{
    public class CriticalConnectionsInANetworkLC1192
    {
        //O(n) Tarjan's algorithm
        //Inspired from TechDose - https://www.youtube.com/watch?v=Rhxs4k6DyMM&t=0s
        public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections)
        {
            //Make graph (AdjList) - Start
            Dictionary<int, IList<int>> graph = new Dictionary<int, IList<int>>();
            for (int i = 0; i < n; i++)
                graph[i] = new List<int>();
            foreach (var conn in connections)
            {
                graph[conn[0]].Add(conn[1]);
                graph[conn[1]].Add(conn[0]);
            }
            //Make graph (AdjList) - End

            int[] disc = new int[n];
            int[] low = new int[n];
            int[] parent = new int[n];
            int time = 0;
            for (int i = 0; i < n; i++)
            {
                disc[i] = -1;
                low[i] = -1;
                parent[i] = -1;
            }
            IList<IList<int>> result = new List<IList<int>>();
            for (int i = 0; i < n; i++)
            {
                if (disc[i] == -1)
                {
                    DFS(i);
                }
            }

            void DFS(int u)
            {
                disc[u] = time;
                low[u] = time;
                time++;

                foreach (int v in graph[u])
                {
                    if (disc[v] == -1)
                    {
                        parent[v] = u;
                        DFS(v);
                        low[u] = Math.Min(low[u], low[v]);

                        if (low[v] > disc[u])
                            result.Add(new List<int>() { u, v });
                    }
                    else if (v != parent[u])
                    {
                        low[u] = Math.Min(low[u], disc[v]);
                    }

                }
            }
            return result;
        }


        //O(n^2) TC
        //Based - Remove 1 edge at a time and see if the graph is disconnected.
        //Inspired from - https://www.youtube.com/watch?v=RYaakWv5m6o
        public IList<IList<int>> CriticalConnections2(int n, IList<IList<int>> connections)
        {
            IList<IList<int>> result = new List<IList<int>>();
            Dictionary<int, IList<int>> graph = new Dictionary<int, IList<int>>();
            HashSet<int> visited = null;
            for (int i = 0; i < n; i++)
                graph[i] = new List<int>();

            foreach (var conn in connections)
            {
                graph[conn[0]].Add(conn[1]);
                graph[conn[1]].Add(conn[0]);
            }

            foreach (var conn in connections)
            {
                //remove conn
                graph[conn[0]].Remove(conn[1]);
                graph[conn[1]].Remove(conn[0]);
                visited = new HashSet<int>();
                DFS(0);
                Console.WriteLine($"for Conn {conn[0]}-{conn[1]}, visited count is {visited.Count}");
                if (visited.Count < n)
                    result.Add(conn);
                //add conn
                graph[conn[0]].Add(conn[1]);
                graph[conn[1]].Remove(conn[0]);

            }
            return result;


            void DFS(int node)
            {
                visited.Add(node);
                foreach (var nei in graph[node])
                {
                    if (!visited.Contains(nei))
                    {
                        visited.Add(nei);
                        DFS(nei);
                    }
                }
            }
        }
    }
}
