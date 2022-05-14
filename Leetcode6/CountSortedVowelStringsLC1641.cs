// Inspired from Fraz - https://www.youtube.com/watch?v=gdt7HQF56OI
// #DP

namespace Leetcode6
{
    public class CountSortedVowelStringsLC1641
    {
        public int CountVowelStrings(int n)
        {
            int[] prefixSumArr = new int[5];
            for (int i = 0; i < prefixSumArr.Length; i++)
                prefixSumArr[i] = 1;

            for (int k = 0; k < (n - 1); k++) // n-1 because you have already iterated once above (default 1's)
            {
                for (int i = 3; i >= 0; i--) //for i=4, its always 1. check the video.
                    prefixSumArr[i] += prefixSumArr[i + 1];
            }

            int result = 0;
            for (int i = 0; i < prefixSumArr.Length; i++)
                result += prefixSumArr[i];

            return result;
        }
    }
}
