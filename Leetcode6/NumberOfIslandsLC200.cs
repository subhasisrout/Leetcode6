// #DFS #Graph
namespace Leetcode
{
    public class NumberOfIslandsLC200
    {
        public int NumIslands(char[][] grid)
        {
            int result = 0;

            void DFSSink(int i, int j) //Advantage of this kind of inner method is - you dont have to pass 'grid'
            {
                if (i < 0 || j < 0 || i >= grid.Length || j >= grid[0].Length || grid[i][j] == '0')
                    return;
                grid[i][j] = '0';

                DFSSink(i + 1, j);
                DFSSink(i - 1, j);
                DFSSink(i, j + 1);
                DFSSink(i, j - 1);
            }

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == '1')
                    {
                        DFSSink(i, j);
                        result++;
                    }
                }
            }
            return result;
        }
    }
}
