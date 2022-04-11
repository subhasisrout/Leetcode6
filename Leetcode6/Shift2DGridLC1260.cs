namespace Leetcode6
{
    // Inspired from #Neetcode - https://www.youtube.com/watch?v=nJYFh4Dl-as
    // Key Here is - Mapping of #2D array to 1D array/Index and back. #Matrix #Grid
    // PosTo1DIdx and IdxTo2DPos does just that.
    // #Easy #Clever #Hard
    public class Shift2DGridLC1260
    {
        public IList<IList<int>> ShiftGrid(int[][] grid, int k)
        {
            int M = grid.Length; //number of rows
            int N = grid[0].Length; //number of cols

            // Inner helper function. Even though its just 1 line. It improves readability. 
            int PosTo1DIdx(int r, int c)
            {
                return (r * N + c);
            }
            IList<int> IdxTo2DPos(int v)
            {
                return new List<int>() { v / N, v % N };
            }

            // #2D array initialization. For each row, you do new int[colCount];
            int[][] result = new int[M][];
            for (int i = 0; i < M; i++)
            {
                result[i] = new int[N];
            }

            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    int idx = PosTo1DIdx(i, j);
                    int newIdx = (idx + k) % (M * N);
                    IList<int> newPos = IdxTo2DPos(newIdx);
                    result[newPos[0]][newPos[1]] = grid[i][j];
                }
            }

            return result;
        }

    }
}
