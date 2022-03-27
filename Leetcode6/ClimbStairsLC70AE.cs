// #Similar to LC70
// #Instead of 2, this is dynamic.
using System.Collections.Generic;

namespace Leetcode
{
    public class ClimbStairsLC70AE
    {
        public int StaircaseTraversal(int height, int maxSteps)
        {
            int[] dpArray = new int[height + 1]; //5 --- 0,1,2,3,4,5
            dpArray[0] = 1;
            dpArray[1] = 1;
            for (int i = 2; i < height + 1; i++)
            {
                //dpArray[i] = dpArray[i - 1] + dpArray[i - 2];
                int k = 1;
                while (k <= maxSteps && (i-k)>=0)
                {
                    dpArray[i] += dpArray[i - k];
                    k++;
                }

            }
            return dpArray[height];
        }

        private int ClimbStairsUtil(int height, int maxSteps, Dictionary<int, int> memo)
        {
            if (memo.ContainsKey(height))
                return memo[height];

            int n = maxSteps;
            int sum = 0;
            while (n >= 0)
            {
                sum += ClimbStairsUtil(height, maxSteps, memo);
                n--;
            }

            memo.Add(height, sum);
            return sum;
        }
    }
}
