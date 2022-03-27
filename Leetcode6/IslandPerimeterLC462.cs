// Very easy and intuitive solution from Micheal Muinos https://www.youtube.com/watch?v=fFQVHjNUwyU

using System;

namespace Leetcode
{
    public class IslandPerimeterLC462
    {
        public int IslandPerimeter(int[][] grid)
        {
            int result = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 1)
                        result += CalculatePerimeter(grid, i, j);
                }
            }
            return result;
        }

        private int CalculatePerimeter(int[][] grid, int i, int j)
        {
            int localPerimeter = 0;
            if (j - 1 < 0 || grid[i][j - 1] == 0) localPerimeter++;
            if (j + 1 >= grid[0].Length || grid[i][j + 1] == 0) localPerimeter++;
            if (i - 1 < 0 || grid[i-1][j] == 0) localPerimeter++;
            if (i + 1 >= grid.Length || grid[i+1][j] == 0) localPerimeter++;
            return localPerimeter;
        }
    }
}
