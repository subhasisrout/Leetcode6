using System.Collections.Generic;
// #AE
namespace Leetcode
{
    public class SpiralMatrixLC54
    {
        public IList<int> SpiralOrder(int[][] matrix)
        {
            IList<int> result = new List<int>();
            int sr = 0;
            int er = matrix.Length - 1;
            int sc = 0;
            int ec = matrix[0].Length - 1;
            while (er >= sr && ec >= sc)
            {
                // top row
                for (int i = sc; i <= ec; i++)
                    result.Add(matrix[sr][i]);

                //right col
                for (int i = sr + 1; i <= er; i++)
                    result.Add(matrix[i][ec]);

                //bottom row
                for (int i = ec - 1; i >= sc; i--)
                {
                    if (sr == er) break; // edge case to prevent double counting when the inner rectangle has a single row. Note - It would be counted in "top row"
                    result.Add(matrix[er][i]);
                }

                //left col
                for (int i = er - 1; i >= sr + 1; i--)
                {
                    if (sc == ec) break; // edge case to prevent double counting when the inner rectangle has a single col. Note - It would be counted in "right col"
                    result.Add(matrix[i][sc]);
                }

                //smaller rectange
                sr++;
                er--;
                sc++;
                ec--;
            }
            return result;
        }
    
    }
}
