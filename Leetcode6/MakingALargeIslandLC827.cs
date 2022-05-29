// #matrix #dirs #dfs

namespace Leetcode6
{
    public class MakingALargeIslandLC827
    {
        public int LargestIsland(int[][] grid)
        {
            int n = grid.Length;
            int max = Int32.MinValue;
            int index = 2;
            int[,] dirs = new int[,] { { 1, 0 }, { 0, 1 }, { -1, 0 }, { 0, -1 } };
            bool[,] visitedDfs = new bool[n, n];
            Dictionary<int, int> sizeMap = new Dictionary<int, int>();
            HashSet<int> seenIsland = new HashSet<int>();
            int size = 0;
            //Below for-loop along with DFS will make multiple islands of index 2,3,4,5 etc and its corresponding size
            //Why starting from 2 ? to distinguish from 0's and 1's already used in the matrix.
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        size = 0;
                        DFS(i, j);
                        sizeMap.Add(index, size);
                        index++;
                    }
                }
            }

            //Go through water (0) and check neigbouring islands
            for (int x = 0; x < n; x++)
            {
                for (int y = 0; y < n; y++)
                {
                    if (grid[x][y] == 0)
                    {
                        int combinedIslandSize = 1; // the current cell having 0 will have the area 1.
                        seenIsland = new HashSet<int>(); //used for situation like [1,1][1,0]--> you can visit neighbours by going left and going top from 0. Hence used set.
                        for (int k = 0; k < 4; k++)
                        {
                            int newX = x + dirs[k, 0];
                            int newY = y + dirs[k, 1];
                            if (newX >= 0 && newY >= 0 && newX < n && newY < n && grid[newX][newY] != 0 && !seenIsland.Contains(grid[newX][newY]))
                            {
                                int neiIslandIndex = grid[newX][newY];
                                seenIsland.Add(neiIslandIndex);
                                int neiIslandSize = sizeMap[neiIslandIndex];
                                combinedIslandSize += neiIslandSize;
                            }
                        }
                        max = Math.Max(max, combinedIslandSize);
                    }
                }
            }
            return (max == Int32.MinValue) ? (n * n) : max;

            void DFS(int x, int y)
            {
                visitedDfs[x, y] = true;
                grid[x][y] = index;
                size++;
                for (int k = 0; k < 4; k++)
                {
                    int newX = x + dirs[k, 0];
                    int newY = y + dirs[k, 1];

                    if (newX >= 0 && newY >= 0 && newX < n && newY < n && grid[newX][newY] == 1 && !visitedDfs[newX, newY])
                    {
                        visitedDfs[newX, newY] = true;
                        grid[newX][newY] = index;
                        DFS(newX, newY);
                    }

                }
            }
        }
    }
}
