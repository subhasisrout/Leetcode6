namespace Leetcode6
{
    public class IsGraphBipartiteLC785
    {
        public bool IsBipartite(int[][] graph)
        {
            //coloring vertices method 0 (uncolored), 1(blue), -1(red)
            int[] colors = new int[graph.Length];
            for (int i = 0; i < graph.Length; i++)
            {
                if (colors[i] == 0 && !ValidDFS(i, 1))
                    return false;
            }
            return true;

            bool ValidDFS(int currNode, int expectedColor)
            {
                //base condition
                if (colors[currNode] != 0)
                    return colors[currNode] == expectedColor;

                colors[currNode] = expectedColor;
                foreach (var nei in graph[currNode])
                {
                    if (!ValidDFS(nei, -1 * expectedColor))
                        return false;
                }
                return true;
            }
        }
    }
}
