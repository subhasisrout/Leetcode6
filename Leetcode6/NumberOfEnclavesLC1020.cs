
// #Similar to RemoveIslandsAE #DFS

namespace Leetcode
{
    public class NumberOfEnclavesLC1020
    {
        int count = 0;
        public int NumEnclaves(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if ((i == 0 || i == matrix.Length - 1 || j == 0 || j == matrix[i].Length - 1) && (matrix[i][j] == 1))
                    {
                        DFSShoreIslands(matrix, i, j);
                    }
                }
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (i == 0 || i == matrix.Length - 1 || j == 0 || j == matrix[i].Length - 1 || matrix[i][j] != 1)
                    {
                        continue;
                    }
                    else
                    {
                        DFSInternalIslands(matrix, i, j);
                    }
                }
            }

            return count;
        }

        private void DFSShoreIslands(int[][] matrix, int i, int j)
        {
            if (i < 0 || i >= matrix.Length || j < 0 || j >= matrix[i].Length || matrix[i][j] == 2 || matrix[i][j] == 0)
                return;
            matrix[i][j] = 2;
            DFSShoreIslands(matrix, i + 1, j);
            DFSShoreIslands(matrix, i - 1, j);
            DFSShoreIslands(matrix, i, j + 1);
            DFSShoreIslands(matrix, i, j - 1);
        }

        private void DFSInternalIslands(int[][] matrix, int i, int j)
        {
            if (i < 0 || i >= matrix.Length || j < 0 || j >= matrix[i].Length || matrix[i][j] == 2 || matrix[i][j] == 0)
                return;
            matrix[i][j] = 2;
            count++;
            DFSInternalIslands(matrix, i + 1, j);
            DFSInternalIslands(matrix, i - 1, j);
            DFSInternalIslands(matrix, i, j + 1);
            DFSInternalIslands(matrix, i, j - 1);
        }
    }
}
