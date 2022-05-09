// #Graph #BFS #Queue #DirectionsArray #BinarySearch #ResultMinPatternInBinarySearch

namespace Leetcode6
{
    public class PathWithMinimumEffortLC1631
    {
        public int MinimumEffortPath(int[][] heights)
        {
            if (heights.Length == 1 && heights[0].Length == 1) return 0;
            int l = 0;
            int r = 1000000;
            int result = 1000000;
            int[][] directions = new int[][]{
            new int[]{1,0},
            new int[]{0,1},
            new int[]{-1,0},
            new int[]{0,-1}
        };
            while (l <= r)
            {
                int mid = (l + r) / 2;
                if (IsValidBFS(mid))
                {
                    result = Math.Min(result, mid);
                    r = mid - 1;
                }
                else
                    l = mid + 1;
            }
            return result;


            bool IsValidBFS(int target)
            {
                Queue<int[]> q = new Queue<int[]>();
                bool[][] seen = new bool[heights.Length][];
                for (int i1 = 0; i1 < heights.Length; i1++)
                {
                    seen[i1] = new bool[heights[0].Length];
                }

                for (int i1 = 0; i1 < heights.Length; i1++)
                {
                    for (int j1 = 0; j1 < heights[0].Length; j1++)
                    {
                        seen[i1][j1] = false;
                    }
                }

                q.Enqueue(new int[] { 0, 0 });
                seen[0][0] = true;
                while (q.Count > 0)
                {
                    var tmp = q.Dequeue();
                    var x = tmp[0];
                    var y = tmp[1];

                    foreach (int[] d in directions)
                    {
                        int nx = x + d[0];
                        int ny = y + d[1];

                        if (nx >= 0 && ny >= 0 && nx < heights.Length && ny < heights[0].Length && !seen[nx][ny] && Math.Abs(heights[x][y] - heights[nx][ny]) <= target)
                        {
                            seen[nx][ny] = true;
                            q.Enqueue(new int[] { nx, ny });
                            if (nx == heights.Length - 1 && ny == heights[0].Length - 1)
                                return true;
                        }
                    }

                }
                return false;
            }
        }
    }
}
