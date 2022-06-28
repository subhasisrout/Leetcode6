// #SlidingWindow #InDisguise #Clever

namespace Leetcode6
{
    public class MaxPointsYouCanObtainFromCardsLC1423
    {
        public int MaxScore(int[] cardPoints, int k)
        {
            int total = cardPoints.Sum();
            int n = cardPoints.Length;
            //create subarray of n-k length and minimize it.
            int sum = 0;
            int l = 0;
            int result = Int32.MaxValue;
            int size = n - k;
            for (int r = 0; r < n; r++)
            {
                sum += cardPoints[r];
                if (r - l + 1 > size)
                {
                    sum -= cardPoints[l];
                    result = Math.Min(result, sum);
                    l++;
                }
                if (r - l + 1 == size)
                {
                    result = Math.Min(result, sum);
                }
            }
            return total - result;
        }

        //Below was my sliding window. Not clean. Nested if-else. Lot of line of code.
        public int MaxScore2(int[] cardPoints, int k)
        {
            int total = cardPoints.Sum();
            int n = cardPoints.Length;
            //create subarray of n-k length and minimize it.
            int windowSum = 0;
            int l = 0;
            int r = 0;
            int result = Int32.MaxValue;
            bool initialWindowFlag = false;
            for (int i = 0; i < n; i++)
            {
                if (r - l + 1 <= n - k)
                {
                    windowSum += cardPoints[i];
                }
                else
                {
                    initialWindowFlag = true;
                    if (initialWindowFlag)
                    {
                        result = Math.Min(result, windowSum);
                        initialWindowFlag = false;
                    }
                    windowSum -= cardPoints[l];
                    windowSum += cardPoints[i];
                    result = Math.Min(result, windowSum);
                    l++;
                }
                r++;
            }
            return total - result;
        }
    }
}
