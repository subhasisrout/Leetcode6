using System;

// #SimpleButDeep - Check why this algorithm works.

namespace Leetcode
{
    public class NonConstructibleChangeAE
    {
        public int NonConstructibleChange(int[] coins)
        {
            int currMinChange = 0;
            Array.Sort(coins);
            for (int i = 0; i < coins.Length; i++)
            {
                if (coins[i] > currMinChange + 1)
                    return currMinChange + 1;
                else
                    currMinChange += coins[i];
            }
            return currMinChange + 1;
        }

        
    }
}
