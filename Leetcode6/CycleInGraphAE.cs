// Look at #AlgoExpert #AE for detail explaination
// tree-edge, back-edge, cross-edge, forward-edge


namespace Leetcode
{
    public class CycleInGraphAE
    {
        public bool CycleInGraph(int[][] edges)
        {
            int numOfVertices = edges.Length;
            bool[] visited = new bool[numOfVertices]; 
            bool[] currentlyInStack = new bool[numOfVertices]; // Here "stack" is the recursion stack.

            // this loop is needed mainly for the disjoint nodes (forest)
            // otherwise because of DFS nature. calling IsCycleFound on one node will lead to another and so on. Only the disjoint ones will be left.
            for (int node = 0; node < numOfVertices; node++) 
            {
                if (visited[node])
                    continue;

                
                var cycleFound = IsCycleFound(edges, node, visited, currentlyInStack);
                if (cycleFound)
                    return true;                
            }
            return false;
        }

        private bool IsCycleFound(int[][] edges, int node, bool[] visited, bool[] currentlyInStack)
        {
            visited[node] = true;
            currentlyInStack[node] = true;

            int[] neighbours = edges[node];
            bool cycleFound = false;
            for (int i = 0; i < neighbours.Length; i++)
            {
                int currentNeighbour = neighbours[i];
                if (visited[currentNeighbour] == false) // if not visited, go and visit by doing recursion
                {
                    cycleFound = IsCycleFound(edges, currentNeighbour, visited, currentlyInStack);
                }
                if (cycleFound)
                    return true;
                else if (currentlyInStack[currentNeighbour] == true)
                    return true;
            }
            currentlyInStack[node] = false;
            return false;
        }
    }
}
