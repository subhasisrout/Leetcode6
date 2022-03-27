// I came up with Bubble Sort type algorithm with a custom "IsGreaterUsingOrder". It runs on O(n^2) time.

// #AlgoExpert #AE has 3 solution. The first 2 are intuitive and easy too.
// First solution is - "Bucket Sort". #BucketSort
// Second solution is - "2 pass solution". First pass takes care of order[0] and Second pass takes care of order[2].
//                      order[1] is automatically taken care of.


namespace Leetcode
{
    public class ThreeNumberSortAE
    {
        public int[] ThreeNumberSortBucketSort(int[] array, int[] order)
        {
            int[] buckets = new int[order.Length];
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < order.Length; j++)
                {
                    if (array[i] == order[j])
                    {
                        buckets[j]++;
                        break;
                    }
                }

                //if (array[i] == order[0])
                //    buckets[0]++;
                //else if (array[i] == order[1])
                //    buckets[1]++;
                //else
                //    buckets[2]++;
            }

            int k = 0;
            for (int i = 0; i < order.Length; i++)
            {
                int value = order[i];
                int count = buckets[i];
                
                while (count > 0)
                {
                    array[k] = value;
                    k++;
                    count--;
                }
            }

            return array;
        }
        public int[] ThreeNumberSortTwoPass(int[] array, int[] order)
        {
            int firstIndex = 0;
            int lastIndex = array.Length - 1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == order[0]) // firstvalue is order[0]
                {
                    Swap(array, i, firstIndex);
                    firstIndex++;
                }
            }

            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (array[i] == order[2]) // thirdvalue is order[2]
                {
                    Swap(array, i, lastIndex);
                    lastIndex--;
                }
            }

            return array;
        }
        public int[] ThreeNumberSortOwnSolution(int[] array, int[] order)
        {
            bool isSwapped = true;
            int lastIndex = array.Length - 1;
            while (isSwapped == true)
            {
                isSwapped = false;
                for (int i = 0; i < lastIndex; i++)
                {                    
                    if (IsGreaterUsingOrder(array, order, i, i + 1))    //if (array[i] > array[i + 1])
                    {
                        isSwapped = true;
                        Swap(array, i, i + 1);
                    }
                }
                lastIndex--; //This line is not needed, but present there as a SMALL OPTIMIZATION.

                // Once the loop finishes for the first time, the largest element is bubbled up to the last position (i.e in its correct position)
                // When the loop finishes for the second time, the largest and second largest element are bubbled up to the last and second last position (i.e in its correct position)
                // Thats why we reduce lastIndex.
            }
            return array;
        }
        private static void Swap(int[] arr, int index1, int index2)
        {
            if (index1 == index2) return;
            int tmp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = tmp;
        }

        private static bool IsGreaterUsingOrder(int[] array, int[] order, int iIndex, int jIndex) // i is in left and j is in right in "input array"
        {
            if (order[0] == array[iIndex])
                return false;
            else if (order[2] == array[iIndex])
                return true;
            else if (order[1] == array[iIndex] && order[0] == array[jIndex])
                return true;
            else
                return false;
        }
    }
}
