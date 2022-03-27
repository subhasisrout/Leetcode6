// #Leetcode 62 #LC62

// There is also a clever math formula in #AlgoExpert #AE which would result in Constant space utilisation
// and less time complexity.
// factorial (width - 1 + (height - 1) / fact(width - 1) * fact(height-1)

namespace Leetcode
{
    public class NumberOfWaysToTraverseGraphAE
    {
        public int NumberOfWaysToTraverseGraph(int width, int height)
        {
            int[,] grid = new int[width + 1, height + 1];

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (i == 0 || j == 0)
                        grid[i, j] = 1;
                    else
                        grid[i, j] = grid[i - 1, j] + grid[i, j - 1];
                }
            }
            return grid[width, height];
        }


    }
}
