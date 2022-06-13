// #DP Inspired from #Neetcode https://www.youtube.com/watch?v=OM1MTokvxs4
namespace Leetcode6
{
    public class TriangleLC120
    {
        public int MinimumTotal(IList<IList<int>> triangle)
        {
            int n = triangle.Count;
            //The same 1d array is overwritten and one last element in the right is discarded everytime.
            //For visualization, check Neetcode
            int[] dp = new int[n + 1];

            for (int i = n - 1; i >= 0; i--)
            {
                for (int j = 0; j < triangle[i].Count; j++)
                {
                    dp[j] = Math.Min(dp[j], dp[j + 1]) + triangle[i][j];
                }
            }
            return dp[0];
        }
    }
}
