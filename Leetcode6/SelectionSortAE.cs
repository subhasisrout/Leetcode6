using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class SelectionSortAE
    {
        public static int[] SelectionSort(int[] array)
        {
            int i = 0;
            while (i < array.Length - 1)
            {
                int minIndex = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }
                Swap(array, i, minIndex);
                i++;
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
