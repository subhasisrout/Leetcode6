using System.Collections.Generic;

// Use the technique explained in AlgoExpert i.e Handling directionUP and directionDOWN.

// FindDiagonalOrderEasy taken from https://leetcode.com/problems/diagonal-traverse/discuss/581868/Easy-Python-NO-DIRECTION-CHECKING
// very intuitive
// #RememberPattern

namespace Leetcode
{
    public class DiagonalTraverseLC498
    {
        public int[] FindDiagonalOrderEasy(int[][] mat)
        {
            Dictionary<int, List<int>> diagonalMap = new Dictionary<int, List<int>>();
            //Below loop is just filling Dictionary
            for (int i = 0; i < mat.Length; i++)
            {
                for (int j = 0; j < mat[i].Length; j++)
                {
                    if (!diagonalMap.ContainsKey(i + j))
                        diagonalMap.Add(i + j, new List<int>() { mat[i][j] });
                    else
                        diagonalMap[i + j].Add(mat[i][j]);
                }
            }

            // Below loop is doing snake pattern using % 2 == 0
            List<int> result = new List<int>();
            foreach (var key in diagonalMap.Keys)
            {
                if (key % 2 == 0)
                {
                    var list = diagonalMap[key];
                    for (int i = list.Count - 1; i >= 0; i--)
                    {
                        result.Add(list[i]);
                    }
                }
                else
                {
                    var list = diagonalMap[key];
                    for (int i = 0; i < list.Count ; i++)
                    {
                        result.Add(list[i]);
                    }
                }
            }

            return result.ToArray();
        }


            public int[] FindDiagonalOrderToughToRemember(int[][] mat)
        {
            int rows = mat.Length;
            int cols = mat[0].Length;
            List<int> output = new List<int>();

            //Special case - IF AND ONLY THE INPUT has a single column
            if (cols == 1)
            {
                for (int k = 0; k < mat.Length; k++)
                {
                    output.Add(mat[k][0]);
                }
                return output.ToArray();
            }
            //Special end

            // pointer indexes for traversing
            int i = 0;
            int j = 0;

            output.Add(mat[i][j]); //[1]
            j++;
            int currToBeMoved = -1; //-1 for down (DOWNLEFT) and +1 for up (UPRIGHT).

            while (i >= 0 && i < rows && j >= 0 && j < cols)
            {
                output.Add(mat[i][j]); //[1,2,3]
                if (currToBeMoved == 1)
                {
                    //Hit right boundary while moving up
                    if (j == cols - 1) // sequence matters. this has to be above else if (i==0). Reason - In top right corner, you want to go down.
                    {
                        i++;
                        currToBeMoved = -1;
                        continue;
                    }
                    //Hit top boundary while moving up
                    else if (i == 0)
                    {
                        j++;
                        currToBeMoved = -1;
                        continue;
                    }
                    i--;
                    j++;
                }
                else // currToBeMoved = -1 i.e down (DOWNLEFT)
                {
                    //Hit bottom boundary while moving down
                    if (i == rows - 1) // sequence matters. this has to be above else if (j==0). Reason - In botton left corner, you want to go right.
                    {
                        j++;
                        currToBeMoved = 1;
                        continue;
                    }
                    //Hit left boundary while moving down
                    else if (j == 0)
                    {
                        i++;
                        currToBeMoved = 1;
                        continue;
                    }
                    i++;
                    j--;
                }
            }

            return output.ToArray();

        }
    }
}
