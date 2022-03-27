// #REMEMBERPATTERN #MATHS
// #MATRIX #TRANSPOSE (in the inner loop j=i) #REFLECT
// Lot of rotation clockwise/anticlockwise are achievable using tranpose + refect (or other way around)
// Try other combinations
// 90 deg clockwise = tranpose + reflect (with |)
// 90 deg anticlockwise = reflect (with |) + transpose

namespace Leetcode
{
    public class RotateImageLC48
    {
        public void Rotate(int[][] matrix)
        {
            Transpose(matrix);
            ReflectVertically(matrix);
        }
        private void Transpose(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = i; j < matrix[0].Length; j++)
                {
                    //Swap matrix[i,j] with matrix[j,i]
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[j][i];
                    matrix[j][i] = temp;
                }
            }
        }

        private void ReflectVertically(int[][] matrix)
        {
            int colCount = matrix[0].Length;
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length/2; j++)
                {
                    //Swap matrix[i,j] with matrix[i,colCount - 1 - j]
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[i][colCount - 1 - j];
                    matrix[i][colCount - 1 - j] = temp;
                }
            }
        }

    }
}
