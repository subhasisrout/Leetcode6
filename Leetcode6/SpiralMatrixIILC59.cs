// Inspired from Leetcode solution approach 1
// #VImp concept of #Layer used in the solution description
// #Spiral #Matrix

namespace Leetcode6
{
    public class SpiralMatrixIILC59
    {
        public int[][] GenerateMatrix(int n)
        {
            int[][] result = new int[n][];
            for (int i = 0; i < n; i++)
                result[i] = new int[n];

            int layers = (n + 1) / 2;
            int count = 1;
            for (int layer = 0; layer < layers; layer++)
            {

                //direction --->. row is same, col increasing
                for (int c = layer; c < n - layer; c++)
                {
                    result[layer][c] = count++;
                }

                //direction downwards on the right. col is same, row increasing
                for (int r = layer + 1; r < n - layer; r++)
                {
                    result[r][n - layer - 1] = count++;
                }

                //direction <------. row is same, col decreasing
                for (int c = n - layer - 2; c >= layer; c--)
                {
                    result[n - layer - 1][c] = count++;
                }

                //direction upwards on the left. col is same, row decreasing
                for (int r = n - layer - 2; r >= (layer + 1); r--)
                {
                    result[r][layer] = count++;
                }

            }
            return result;
        }
    }
}
