namespace Leetcode6
{
    public class ShortestBridgeLC934
    {
        public int ShortestBridge(int[][] grid)
        {
            int n = grid.Length;
            Queue<int[]> q = new Queue<int[]>(); //for BFS
            int[,] dirs = new int[,] { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 } };
            bool secondIslandCreated = false;
            bool[][] visited = new bool[n][];
            for (int i = 0; i < n; i++)
            {
                visited[i] = new bool[n];
            }
            for (int i = 0; i < n; i++)
            {
                if (secondIslandCreated) break;
                for (int j = 0; j < n; j++)
                {
                    if (secondIslandCreated) break;
                    if (grid[i][j] == 1 && !secondIslandCreated)
                    {
                        secondIslandCreated = true;
                        DFS(i, j); //Mark a island as islands of 2 (to distinguish).
                        break;
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        q.Enqueue(new int[] { i, j });
                    }
                }
            }

            return BFS();

            int BFS()
            {
                int result = 0;
                while (q.Count > 0)
                {
                    int size = q.Count;
                    while (size > 0)
                    {
                        int[] cell = q.Dequeue();
                        int x = cell[0];
                        int y = cell[1];
                        for (int idx = 0; idx < 4; idx++)
                        {
                            int newX = x + dirs[idx, 0];
                            int newY = y + dirs[idx, 1];
                            if (newX >= 0 && newY >= 0 && newX < n && newY < n && !visited[newX][newY])
                            {
                                if (grid[newX][newY] == 2)
                                    return result;
                                q.Enqueue(new int[] { newX, newY });
                                visited[newX][newY] = true;
                            }
                        }
                        size--;
                    }
                    result++;
                }
                return -1; //will never reach here (for compilation purpose)
            }

            void DFS(int x, int y)
            {
                grid[x][y] = 2; //Create island of 2
                for (int i = 0; i < 4; i++)
                {
                    int newX = x + dirs[i, 0];
                    int newY = y + dirs[i, 1];
                    if (newX >= 0 && newY >= 0 && newX < n && newY < n && grid[newX][newY] == 1)
                        DFS(newX, newY);
                }
            }
        }
    }
}
