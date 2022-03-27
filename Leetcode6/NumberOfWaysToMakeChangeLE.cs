// #LC #Leetcode 518 LC518

// #DP #Medium

// Check pic for better understanding and intuition.

namespace Leetcode
{
    public class NumberOfWaysToMakeChangeLE
    {
        public static int NumberOfWaysToMakeChange(int amount, int[] coins)
        {
            int[] dpArray = new int[amount + 1];
            dpArray[0] = 1;

            // Here coins array need NOT be sorted say 25,1,5,10

            for (int j = 0; j < coins.Length; j++) //[1,5,10,25]
            {
                for (int i = 1; i < amount + 1; i++) // [0,1,2,3,4,5,6,7,8,9,10]
                {
                    if (coins[j] <= i)
                    {
                        dpArray[i] = dpArray[i] + dpArray[i - coins[j]];
                    }
                }
            }


            return dpArray[amount];
        }
    }
}
