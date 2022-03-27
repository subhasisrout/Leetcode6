using System;

// #RememberPattern

namespace Leetcode
{
    public class MaximizeExpressionAE
    {
        public int MaximizeExpression(int[] array)
        {
            if (array.Length < 4) return 0;

            int[] maxOfA = new int[array.Length];
            maxOfA[0] = array[0];
            for (int i = 1; i < maxOfA.Length; i++)
            {
                maxOfA[i] = Math.Max(array[i], maxOfA[i - 1]);
            }

            int[] maxOfAMinusB = new int[array.Length];
            for (int i = 0; i < 1; i++)
            {
                maxOfAMinusB[i] = Int32.MinValue;
            }
            for (int i = 1; i < maxOfAMinusB.Length; i++)
            {
                maxOfAMinusB[i] = Math.Max(maxOfA[i - 1] - array[i], maxOfAMinusB[i - 1]);
            }


            int[] maxOfAMinusBPlusC = new int[array.Length];
            for (int i = 0; i < 2; i++)
            {
                maxOfAMinusBPlusC[i] = Int32.MinValue;
            }
            for (int i = 2; i < maxOfAMinusBPlusC.Length; i++)
            {
                maxOfAMinusBPlusC[i] = Math.Max(maxOfAMinusB[i - 1] + array[i], maxOfAMinusBPlusC[i - 1]);
            }

            int[] maxOfAMinusBPlusCMinusD = new int[array.Length];
            for (int i = 0; i < 3; i++)
            {
                maxOfAMinusBPlusCMinusD[i] = Int32.MinValue;
            }
            for (int i = 3; i < maxOfAMinusBPlusCMinusD.Length; i++)
            {
                maxOfAMinusBPlusCMinusD[i] = Math.Max(maxOfAMinusBPlusC[i - 1] - array[i], maxOfAMinusBPlusCMinusD[i - 1]);
            }

            return maxOfAMinusBPlusCMinusD[maxOfAMinusBPlusCMinusD.Length - 1];

        }
    }
}
