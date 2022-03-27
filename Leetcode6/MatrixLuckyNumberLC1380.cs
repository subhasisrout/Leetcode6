using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    // #Matrix - Traverse columnwise too.
    public class MatrixLuckyNumberLC1380
    {
        public IList<int> LuckyNumbers(int[][] matrix)
        {
            List<int> result = new List<int>();
            HashSet<int> minSet = new HashSet<int>();
            HashSet<int> maxSet = new HashSet<int>();

            //Below nested loop is for parsing rowwise (all columns of specific row, then move to next row)
            //normally all nested loop use this pattern
            for (int i = 0; i < matrix.Length; i++)
            {
                int minVal = int.MaxValue;
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    minVal = Math.Min(minVal, matrix[i][j]);
                }
                minSet.Add(minVal);
            }

            //Below nested loop is for parsing colwise vertically
            for (int j = 0; j < matrix[0].Length; j++)
            {
                int maxVal = int.MinValue;
                for (int i = 0; i < matrix.Length; i++)
                {
                    maxVal = Math.Max(maxVal, matrix[i][j]);
                }
                maxSet.Add(maxVal);
            }

            foreach (var item in maxSet)
            {
                if (minSet.Contains(item))
                    result.Add(item);
            }

            return result;
        }
    }
}
