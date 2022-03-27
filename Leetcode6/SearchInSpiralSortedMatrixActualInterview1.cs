using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class SearchInSpiralSortedMatrixActualInterview1
    {
        public int[] SearchNum(int[,] matrix, int num)
        {
            /*
            1   2   3   4   5   6  
            16  17  18  19  20  7
            15  24  23  22  21  8
            14  13  12  11  10  9
            */

            // The trick is start from top left (outer rectangle), and go diagonal (bottom right) till n/2 + 1 rows.
            // Why ? Because of spiral nature, the circle ends and the diagnal is the next bigger value.
            // If you got a bigger value in the bottom-right diagonal, just do a 2*(m+n) search in the outer rectangle.

            return null;
        }
    }
}
