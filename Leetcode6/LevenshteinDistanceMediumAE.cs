using System;

// #AE

namespace Leetcode
{
    public class LevenshteinDistanceMediumAE
    {
        public int LevenshteinDistance(string word1, string word2)
        {
            int[,] dpArray = new int[word1.Length + 1, word2.Length + 1];

            // initialization block
            //  0 1 2 3 4
            //  1
            //  2
            for (int i = 0; i < word1.Length + 1; i++)
            {
                dpArray[i, 0] = i;
            }
            for (int j = 0; j < word2.Length + 1; j++)
            {
                dpArray[0, j] = j;
            }

            for (int i = 1; i < word1.Length + 1; i++)
            {
                for (int j = 1; j < word2.Length + 1; j++)
                {
                    if (word1[i - 1] == word2[j - 1])
                    {
                        dpArray[i, j] = dpArray[i - 1, j - 1];
                    }
                    else
                    {
                        dpArray[i, j] = 1 + Math.Min(dpArray[i - 1, j - 1], Math.Min(dpArray[i - 1, j], dpArray[i, j - 1]));
                    }

                }
            }
            return dpArray[word1.Length, word2.Length];
        }
    }
}
