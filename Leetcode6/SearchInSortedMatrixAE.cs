// #MindBlowing #Simple If started from Top-Right (thats the key). #BinarySearch not needed.
// #Running in O(m+n) time
// #Leetcode #LC74 (Similar to leetcode 74) and LC240

namespace Leetcode
{
    public class SearchInSortedMatrixAE
    {
        public static int[] SearchInSortedMatrix(int[,] matrix, int target)
        {
            int row = 0;
            int col = matrix.GetLength(1) - 1;

            while (row >= 0 && row <= matrix.GetLength(0) - 1 && col >= 0 && col <= matrix.GetLength(1) - 1)
            {
                if (matrix[row, col] == target)
                    return new int[] { row, col };
                else if (matrix[row, col] > target)
                    col--;
                else
                    row++;
            }

            return new int[] { -1, -1 };
        }

        
    }
}
