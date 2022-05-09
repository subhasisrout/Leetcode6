// #Graph #DFS
namespace Leetcode6
{
    public class EvaluateDivisionLC399
    {
        public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
        {
            //Build Graph
            Dictionary<string, List<Node>> g = new Dictionary<string, List<Node>>();
            for (int i = 0; i < values.Length; i++)
            {
                string start = equations[i][0];
                string end = equations[i][1];
                if (!g.ContainsKey(start))
                    g.Add(start, new List<Node>());
                if (!g.ContainsKey(end))
                    g.Add(end, new List<Node>());
                g[start].Add(new Node(end, values[i]));
                g[end].Add(new Node(start, (1 / values[i])));
            }

            double[] result = new double[queries.Count];
            for (int i = 0; i < queries.Count; i++)
            {
                result[i] = DFS(queries[i][0], queries[i][1], new HashSet<string>());
            }

            double DFS(string start, string end, HashSet<string> visited)
            {
                if (!g.ContainsKey(start) || !g.ContainsKey(end))
                    return -1.0;
                if (start == end)
                    return 1.0;
                visited.Add(start);
                List<Node> neiNodeList = g[start];
                foreach (var neiNode in neiNodeList)
                {
                    if (!visited.Contains(neiNode.Key))
                    {
                        double ans = DFS(neiNode.Key, end, visited);
                        if (ans != -1.0)
                            return ans * neiNode.Weight;
                    }
                }
                return -1.0;
            }

            return result;
        }

        class Node
        {
            public string Key { get; set; }
            public double Weight { get; set; }

            public Node(string k, double w)
            {
                this.Key = k;
                this.Weight = w;
            }
        }
    }
}
