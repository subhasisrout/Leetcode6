// Similar to #Leetcode #LC489

using System.Collections.Generic;

namespace Leetcode
{
    public class ZigzagTraverseAE
    {
        public static List<int> ZigzagTraverse(List<List<int>> array)
        {
            int rows = array.Count;
            int cols = array[0].Count;

            //Special case - IF AND ONLY THE INPUT has a single row
            if (rows == 1)
                return array[0];
            //Special end

            // pointer indexes for traversing
            int i = 0;
            int j = 0;

            List<int> output = new List<int>();            

            output.Add(array[i][j]); //[1]
            i++;
            int currToBeMoved = 1; //-1 for down (DOWNLEFT) and +1 for up (UPRIGHT).


            while (i >= 0 && i < rows && j >= 0 && j < cols)
            {
                output.Add(array[i][j]); //[1,2,3]
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

            return output;
        }
    }
}
