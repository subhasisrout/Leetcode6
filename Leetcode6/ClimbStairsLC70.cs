// Bottom up - building the dpArray is more intuitive
// Similar to LC746. Except the "recurrence relation" is slightly more complex
/*
public int MinCostClimbingStairs(int[] cost)
{
    int[] dpArr = new int[cost.Length + 1];
    dpArr[0] = 0;
    dpArr[1] = 0;
    for (int i = 2; i <= cost.Length; i++) // Note here <=
    {
        dpArr[i] = Math.Min(dpArr[i - 1] + cost[i - 1], dpArr[i - 2] + cost[i - 2]);
    }
    return dpArr[cost.Length]; //Note here cost.Length (not cost.Length - 1)
}
*/


namespace Leetcode
{
    public class ClimbStairsLC70
    {
        public int ClimbStairsTopDown(int n)
        {
            int count = 0;
            if (n == 0)
                return count;

            int sum = 0;
            ClimbStairsUtil(n,ref count, sum);
            return count;

        }

        private void ClimbStairsUtil(int n,ref int count, int sum)
        {
            if (sum == n)
            {
                count++;
                return;
            }

            if (sum > n)
                return;

            ClimbStairsUtil(n, ref count, sum + 1);
            ClimbStairsUtil(n, ref count, sum + 2);
        }

        //MOREINTUITIVE
        public int ClimbStairs(int n)
        {
            int[] dp = new int[n + 1];
            dp[0] = 1;
            dp[1] = 2;
            for (int i = 2; i < n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2]; // This is called the "recurrence relation".
            }
            return dp[n - 1];
        }
    }
}
