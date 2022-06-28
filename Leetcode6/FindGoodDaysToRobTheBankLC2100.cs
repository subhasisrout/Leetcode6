// #DP #PrefixSum
namespace Leetcode6
{
    public class FindGoodDaysToRobTheBankLC2100
    {
        public IList<int> GoodDaysToRobBank(int[] security, int time)
        {
            int n = security.Length;
            IList<int> result = new List<int>();

            int[] rightToLeft = new int[n];
            int[] leftToRight = new int[n];

            //how manys days before this day, is the security continously decreasing or same.
            for (int i = 1; i < n; i++)
            {
                if (security[i] <= security[i - 1])
                {
                    leftToRight[i] = leftToRight[i - 1] + 1;
                }
            }

            //how manys days after this day, is the security continously decreasing or same.
            for (int i = n - 2; i >= 0; i--)
            {
                if (security[i] <= security[i + 1])
                {
                    rightToLeft[i] = rightToLeft[i + 1] + 1;
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (leftToRight[i] >= time && rightToLeft[i] >= time)
                    result.Add(i);
            }

            return result;
        }
    }
}
