using System;

// #Leetcode #LC 97

namespace Leetcode
{
    public class InterweavingStringsAE
    {
        public static bool Interweavingstrings(string s1, string s2, string s3)
        {
            // prelims check
            if (s3.Length != s1.Length + s2.Length)
                return false;

            int[,] cache = new int[s1.Length + 1, s2.Length + 1]; //0 not evaluated, -1 false, 1 true
            return AreInterwoven(s1, s2, s3, 0, 0, cache) == 1;
        }

        private static int AreInterwoven(string one, string two, string three, int i, int j, int[,] cache)
        {
            if (cache[i, j] != 0)
                return cache[i, j];

            int k = i + j;
            if (k == three.Length)
                return 1;

            if (i < one.Length && one[i] == three[k])
            {
                cache[i,j] = AreInterwoven(one, two, three, i + 1, j, cache);
                if (cache[i, j] == 1)
                    return 1; //else you cannot return -1 (false). you need to check for 'j'(string two), which is done below.
            }

            if (j < two.Length && two[j] == three[k])
            {
                cache[i, j] = AreInterwoven(one, two, three, i, j + 1, cache);
                return cache[i, j];
            }

            cache[i, j] = -1;
            return -1;

        }
    }
}
