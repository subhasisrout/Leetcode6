// Kevin's solution is more concise and clear.
// #AlgoExpert (present there too)

namespace Leetcode
{
    public class MonotonicArrayLC896
    {
        public bool IsMonotonic(int[] A)
        {
            int i = 1;
            int isIncDec = 0;
            while (i < A.Length - 1)
            {
                if (A[i] == A[i - 1])
                {
                    i++;
                    continue;
                }

                if (A[i] > A[i - 1])
                {
                    isIncDec = 1;
                    break;
                }
                if (A[i] < A[i - 1])
                {
                    isIncDec = -1;
                    break;
                }
            }
            i++;
            if (isIncDec == 0)
                return true; //all same elements
            else if (isIncDec == 1) //inc sequence
            {
                while (i < A.Length)
                {
                    if (A[i] < A[i - 1])
                    {
                        return false;
                    }
                    else
                    {
                        i++;
                    }
                }
                return true;
            }
            else //dec sequence
            {
                while (i < A.Length)
                {
                    if (A[i] > A[i - 1])
                    {
                        return false;
                    }
                    else
                    {
                        i++;
                    }
                }
                return true;

            }


        }

        // Below solution (elegant) is written by me
        public bool IsMonotonicAE(int[] array)
        {
            int monotonicIndicator = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (i == 0)
                    continue;

                if (array[i] > array[i - 1])
                {
                    if (monotonicIndicator == -1) return false;
                    monotonicIndicator = 1;
                }
                else if (array[i] < array[i - 1])
                {
                    if (monotonicIndicator == 1) return false;
                    monotonicIndicator = -1;
                }
                // else equal element would result in	
                // monotonicInd 0 as it is initialized to 0;
            }
            return true;
        }
    }

    


}
