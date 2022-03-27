using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class KnapsackProblemAE
    {
        public static List<List<int>> KnapsackProblem(int[,] items, int capacity)
        {
            int[,] knapsackValues = new int[items.GetLength(0) + 1, capacity + 1];
            for (int i = 1; i < items.GetLength(0) + 1; i++) //start from 1st row. 0th row will have all zeroes.
            {
                int currentWeight = items[i - 1, 1]; //"i-1" because we are starting from 1. Extra row (0th) added.
                int currentValue = items[i - 1, 0];
                for (int c = 0; c < capacity + 1; c++) // 'c' for capacity
                {
                    if (currentWeight > c)
                        knapsackValues[i, c] = knapsackValues[i - 1, c];
                    else
                        knapsackValues[i, c] = Math.Max(knapsackValues[i - 1, c], knapsackValues[i - 1, c - currentWeight] + currentValue);
                }
            }
            List<List<int>> output = new List<List<int>>();
            var maxValue = knapsackValues[items.GetLength(0), capacity]; //bottom right of matrix
            output.Add(new List<int>() { maxValue });
            output.Add(GetSequence(knapsackValues, items));
            return output;
        }

        private static List<int> GetSequence(int[,] knapsackValues, int[,] items)
        {
            List<int> sequence = new List<int>();
            int i = knapsackValues.GetLength(0) - 1;
            int c = knapsackValues.GetLength(1) - 1;
            while (i > 0)
            {
                if (knapsackValues[i, c] == knapsackValues[i - 1, c])
                    i--;
                else
                {
                    sequence.Add(i - 1); //"index" of items required.
                    //The sequence of the below lines CANNOT BE REVERSED.
                    c = c - items[i - 1, 1];
                    i = i - 1;
                }
                if (c == 0)
                    break;
            }
            return sequence;
        }
    }
}
