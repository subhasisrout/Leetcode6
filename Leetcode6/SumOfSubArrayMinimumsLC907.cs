using System;

// #Helper method creation helps


namespace Leetcode
{
    public class SumOfSubArrayMinimumsLC907
    {
        public int SumSubarrayMins(int[] arr)
        {
            int result = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int j = i;
                while (j < arr.Length)
                {
                    if (j == i)
                        result += arr[i];
                    else
                    {
                        //find the minValue from arr[i] to arr[j] inclusive
                        result += FindMinValue(arr, i, j);
                    }
                    j++;
                }
            }
            return result;
        }

        private int FindMinValue(int[] arr, int i, int j)
        {
            int minValue = arr[i];
            int k = i + 1;
            while (k <= j)
            {
                minValue = Math.Min(minValue, arr[k]);
                k++;
            }
            Console.WriteLine($"For {i} - {j}, the minValue is {minValue}");
            return minValue;
        }
    }
}
