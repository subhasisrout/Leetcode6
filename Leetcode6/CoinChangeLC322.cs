using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// #AlgoExpert #AE
// Learn the bottom-up approach. Note dp[] is initialized to amount+1, it fails with +ve Infinity.
// for amount 3 and coin[] {2}, when i=3 - you get 1 + dp[3 - 2] => 1 + dp[1] => 1 + +veInfy (overflow).
// Hence return dp[amount] > amount ? -1 : dp[amount]; and NOT dp[amount] == (amount + 1)

namespace Leetcode
{
    public class CoinChangeLC322
    {
        public int CoinChange2(int[] coins, int amount)
        {
            int retVal = int.MaxValue;
            return CoinChangeHelper(amount, coins, ref retVal);
        }

        private int CoinChangeHelper(int amount, int[] coins, ref int numCoins)
        {
            int minCoins = amount;
            for (int i = 0; i < coins.Length; i++)
            {
                if (amount == coins[i])
                    return 1;
            }

            for (int i = 0; i < coins.Length; i++)
            {
                if (coins[i] <= amount)
                    numCoins = 1 + CoinChangeHelper(amount - coins[i], coins, ref numCoins);
                if (numCoins < minCoins)
                    minCoins = numCoins;
            }
            return minCoins;
        }

        //Below is the bottom-up approach (using dp array). i.e. finding the answer to the subproblem 1-by-1 till we reach the final amount
        public int CoinChange(int[] coins, int amount)
        {
            int[] dp = new int[amount + 1]; //if the amount is 10, we need 11 places (0 to 10).
            for (int i = 0; i < dp.Length; i++) // initialize the array to invalid values. i.e to return amount 5, you need 11 coins.
            {
                dp[i] = amount + 1;
            }
            //subproblem-0
            dp[0] = 0;
            for (int i = 1; i <= amount; i++) //subproblem-1 to subproblem-n
            {
                for (int j = 0; j < coins.Length; j++) // for each coin denomination
                {
                    if (i >= coins[j])
                        dp[i] = Math.Min(dp[i], 1 + dp[i - coins[j]]);
                }
            }


            return dp[amount] > amount ? -1 : dp[amount];
        }
    }
}
