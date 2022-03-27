using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// #Graph
// #AdjList #Adj List
namespace Leetcode
{
    public class IfPathExistsInGraphLC1971
    {
        public bool ValidPath(int n, int[][] edges, int start, int end)
        {
            // Below is the standard graph adj list boilerplate code.
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            for (int i = 0; i < n; i++)
            {
                graph.Add(i, new List<int>());
            }
            for (int i = 0; i < edges.Length; i++)
            {
                var curr = edges[i];
                graph[curr[0]].Add(curr[1]);
                graph[curr[1]].Add(curr[0]);
            }

            return DFS(graph, start, end, new HashSet<int>());
        }
        
        // Standard DFS Below.
        private bool DFS(Dictionary<int, List<int>> graph, int start, int end, HashSet<int> visited)
        {
            if (visited.Contains(start))
                return false;
            if (start == end)
                return true;
            visited.Add(start);
            var neighbours = graph[start];
            foreach (var neighbor in neighbours)
            {
                if (DFS(graph, neighbor, end, visited) == true) // gotcha here - DO NOT RETURN DIRECTLY HERE.
                    return true;
            }
            return false;
        }
    }
}
