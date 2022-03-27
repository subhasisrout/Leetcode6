using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class InsertionSortAE
    {
        public static int[] InsertionSort(int[] array)
        {
            // much cleaner solution in AlgoExpert (#AE)
            for (int j = 1; j < array.Length; j++)
            {
                int currentNum = array[j];
                int currentIdx = j;
                int sortedArrIndex = j - 1;
                while (sortedArrIndex >= 0)
                {
                    if (currentNum < array[sortedArrIndex])
                    {
                        Swap(array, currentIdx, sortedArrIndex);
                        sortedArrIndex--;
                        currentIdx--;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return array;
        }

        
        private static void Swap(int[] arr, int index1, int index2)
        {
            int tmp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = tmp;
        }
    }
}
