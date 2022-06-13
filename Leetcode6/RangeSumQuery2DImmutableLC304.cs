// 2d version of RangeSumQueryImmutable#LC303
// Inspired from leetcode solution
// Simulate using a 4 * 3 matrix to see the formula of populating dp array.
// to remember populate dp array by adding top + left + element - dp[r-1][c-1] (everything r+1,c+1 reference)
// dp array has row+1 and col+1, so top row and left cols are all zeros.
// to remember the formula of SumRegion, picture the rectanges and use +1's using row2,col2
namespace Leetcode6
{
    public class RangeSumQuery2DImmutableLC304
    {
        public class NumMatrix
        {
            int[][] dp = null;

            public NumMatrix(int[][] matrix)
            {
                int r = matrix.Length;
                int c = matrix[0].Length;
                dp = new int[r + 1][];
                for (int i = 0; i < r + 1; i++)
                    dp[i] = new int[c + 1];

                for (int i = 0; i < r; i++)
                {
                    for (int j = 0; j < c; j++)
                    {
                        dp[i + 1][j + 1] = dp[i][j + 1] + dp[i + 1][j] + matrix[i][j] - dp[i][j];
                    }
                }
            }

            public int SumRegion(int row1, int col1, int row2, int col2)
            {
                return dp[row2 + 1][col2 + 1] - dp[row1][col2 + 1] - dp[row2 + 1][col1] + dp[row1][col1];
            }
        }

    }
}
