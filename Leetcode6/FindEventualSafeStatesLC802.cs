namespace Leetcode6

// Inspired from #NeetCode #Graph #DFS https://www.youtube.com/watch?v=Re_v0j0CRsg
{
    public class FindEventualSafeStatesLC802
    {
        public IList<int> EventualSafeNodes(int[][] graph)
        {
            Dictionary<int, bool> safe = new Dictionary<int, bool>();
            IList<int> result = new List<int>();


            bool DFS(int i)
            {
                if (safe.ContainsKey(i)) //base case
                    return safe[i];
                safe[i] = false; // Assume 'not safe' initially. Prevents cycle.
                var nei = graph[i];
                for (int k = 0; k < nei.Length; k++)
                {
                    if (DFS(nei[k]) == false)
                    {
                        safe[i] = false; // Add to map and return
                        return false;
                    }
                }
                safe[i] = true; //'safe' otherwise it would have returned in the for loop. Add to map and return
                return true;
            }

            for (int i = 0; i < graph.Length; i++)
            {
                if (DFS(i))
                    result.Add(i);
            }
            return result;

        }
    }
}
