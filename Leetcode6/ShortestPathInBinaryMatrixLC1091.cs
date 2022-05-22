// Note this only possible because of #LevelOrderTraversal plain #BFS wont work
// imagine arcs of increasing size from top-right.. and with each increased arc dist++. Note the cells have 1 in the arc
// nothing will be enqueued and you will come out of the outer while loop, returning -1

// remember int[,] #dirs pattern

namespace Leetcode6
{
    public class ShortestPathInBinaryMatrixLC1091
    {
        public int ShortestPathBinaryMatrix(int[][] grid)
        {
            int n = grid.Length;
            if (grid[0][0] == 1 || grid[n - 1][n - 1] == 1) return -1;

            Queue<int[]> q = new Queue<int[]>();
            q.Enqueue(new int[] { 0, 0 });

            int[,] dirs = new int[,] { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 }, { 1, 1 }, { -1, -1 }, { 1, -1 }, { -1, 1 } };
            int dist = 0;

            while (q.Count > 0)
            {
                int size = q.Count;
                while (size > 0)
                {
                    var popped = q.Dequeue();
                    int X = popped[0];
                    int Y = popped[1];
                    if (X == n - 1 && Y == n - 1)
                        return dist + 1;
                    int newX = -1;
                    int newY = -1;
                    for (int i = 0; i < 8; i++)
                    {
                        newX = X + dirs[i, 0];
                        newY = Y + dirs[i, 1];



                        if (newX >= 0 && newX < n && newY >= 0 && newY < n && grid[newX][newY] == 0)
                        {
                            grid[newX][newY] = -1; //Sink it or use a visited bool arr;
                            q.Enqueue(new int[] { newX, newY });
                        }
                    }
                    size--;
                }//end of level parseing. so after that you can increase dist by 1.
                dist++;
            }
            return -1;

        }
    }
}
