using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class RiverSizesAE
    {
        public static List<int> RiverSizes(int[,] matrix)
        {
            List<int> sizes = new List<int>();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        var size = DFS(matrix, i, j);
                        sizes.Add(size);
                    }
                }
            }
            return sizes;
        }

        private static int DFS(int[,] matrix, int i, int j)
        {
            int size = 1;
            if (i < 0 || i >= matrix.GetLength(0) || j < 0 || j >= matrix.GetLength(1) || matrix[i, j] == 0)
                return size;
            else
            {
                matrix[i, j] = 0;
                size += DFS(matrix, i - 1, j);
                size += DFS(matrix, i, j - 1);
                size += DFS(matrix, i + 1, j);
                size += DFS(matrix, i, j + 1);
            }
            return size;
        }
    }
}
