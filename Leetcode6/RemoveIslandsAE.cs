using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Similar to #NumberOfEnclavesLC1020 #DFS
// #AE is using Iterative approach. For this kind of matrix DFS problem, recursion is intuitive (#Sinking the blocks).

namespace Leetcode
{
    public class RemoveIslandsAE
    {
        public int[][] RemoveIslands(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    // if you are on the shore with '1', do the DFS and sink (update to 2) all the surrounding cells
                    if ((i == 0 || i == matrix.Length - 1 || j == 0 || j == matrix[i].Length - 1) && (matrix[i][j] == 1))
                    {
                        DFS(matrix, i, j);
                    }
                }
            }

            //remove the islands of our interest (i.e. non shore ones, as they are updated to 2 by above DFS)
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 1)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }

            //update back all the shore islands back to 1 (as they should not be changed)
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 2)
                    {
                        matrix[i][j] = 1;
                    }
                }
            }
            return matrix;
        }

        private void DFS(int[][] matrix, int i, int j)
        {
            if (i < 0 || i >= matrix.Length || j < 0 || j >= matrix[i].Length || matrix[i][j] == 2 || matrix[i][j] == 0)
                return;
            matrix[i][j] = 2;
            DFS(matrix, i + 1, j);
            DFS(matrix, i - 1, j);
            DFS(matrix, i, j + 1);
            DFS(matrix, i, j - 1);
        }
    }
}
