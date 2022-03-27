using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class BubbleSortAE
    {
        public static int[] BubbleSort(int[] array)
        {
            bool isSwapped = true;
            int lastIndex = array.Length - 1;
            while (isSwapped == true)
            {
                isSwapped = false;
                for (int i = 0; i < lastIndex; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        isSwapped = true;
                        Swap(array, i, i + 1);
                    }
                }
                lastIndex--; //Works even if you remove this line. But this is an optimization.
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
