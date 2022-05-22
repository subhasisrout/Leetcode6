// remember int[,] #dirs pattern
// #DFS

namespace Leetcode6
{
    public class LongestIncreasingPathInMatrixLC329
    {
        public int LongestIncreasingPath(int[][] matrix)
        {
            if (matrix == null) return 0;
            if (matrix.Length == 1 && matrix[0].Length == 1) return 1;
            int m = matrix.Length;
            int n = matrix[0].Length;
            int max = 1;
            int[,] dirs = new int[,] { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 } };
            int[][] cache = new int[m][];
            for (int i = 0; i < m; i++)
                cache[i] = new int[n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int len = DFS(i, j, cache);
                    max = Math.Max(max, len);
                }
            }
            return max;


            int DFS(int x, int y, int[][] cache)
            {
                if (cache[x][y] != 0) return cache[x][y];
                int maxLocal = 1;
                for (int k = 0; k < 4; k++)
                {
                    int newX = x + dirs[k, 0];
                    int newY = y + dirs[k, 1];
                    if (newX < 0 || newY < 0 || newX >= m || newY >= n || matrix[newX][newY] <= matrix[x][y]) continue;
                    int len = 1 + DFS(newX, newY, cache);
                    maxLocal = Math.Max(maxLocal, len);
                }
                cache[x][y] = maxLocal;
                return maxLocal;
            }

        }
    }
}
