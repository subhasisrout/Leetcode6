// #RememberPattern

namespace Leetcode
{
    public class MaxAreaOfIslandLC695
    {
        public int MaxAreaOfIsland(int[][] grid)
        {
            int max = 0;

            int DFS(int i, int j)
            {
                if (i < 0 || j < 0 || i >= grid.Length || j >= grid[0].Length || grid[i][j] == 0)
                    return 0;
                grid[i][j] = 0;
                int result = 1;

                result += DFS(i + 1, j);
                result += DFS(i - 1, j);
                result += DFS(i, j + 1);
                result += DFS(i, j - 1);

                return result;
            } //Advantage of this kind of inner method is - you dont have to pass 'grid'

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        var area = DFS(i, j);
                        max = Math.Max(area, max);
                    }
                }
            }
            return max;

        }
    }
}
