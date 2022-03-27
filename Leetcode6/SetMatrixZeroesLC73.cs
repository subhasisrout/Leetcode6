// #CleverSolution for O(1) space.
// Taken from leetcode solution
// if first col has any zero, set isFirstColZero
// if first row has any zero, set mat[0][0] to zero


namespace Leetcode
{
    public class SetMatrixZeroesLC73
    {
        public void SetZeroes(int[][] matrix)
        {
            bool isFirstColZero = false;

            //set appropriate variable and update first row/col.
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i][0] == 0)
                    isFirstColZero = true;

                for (int j = 1; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        matrix[i][0] = 0;
                        matrix[0][j] = 0;
                    }
                }
            }

            //iterate skipping the first row and first col. They are taken care below.
            for (int i = 1; i < matrix.Length; i++)
            {
                for (int j = 1; j < matrix[0].Length; j++)
                {
                    if (matrix[0][j] == 0 || matrix[i][0] == 0)
                        matrix[i][j] = 0;
                }
            }

            //iterate first row, if needed.
            if (matrix[0][0] == 0)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    matrix[0][j] = 0;
                }
            }

            //iterate first col, if needed.
            if (isFirstColZero)
            {
                for (int i = 0; i < matrix.Length; i++)
                {
                    matrix[i][0] = 0;
                }
            }

        }
    }
}
