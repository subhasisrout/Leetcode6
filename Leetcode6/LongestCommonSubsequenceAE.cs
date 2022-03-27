using System;
using System.Collections.Generic;
using System.Linq;

// #TODO: Understand. Getting actual LCS string

namespace Leetcode
{
    public class LongestCommonSubsequenceAE
    {
		public static List<char> LongestCommonSubsequence(string str1, string str2)
		{
			int m = str1.Length;
			int n = str2.Length;
			int[,] L = new int[m + 1, n + 1];

			for (int i = 0; i <= m; i++)
			{
				for (int j = 0; j <= n; j++)
				{
					if (i == 0 || j == 0)
						L[i, j] = 0;
					else if (str1[i - 1] == str2[j - 1])
						L[i, j] = L[i - 1, j - 1] + 1;
					else
						L[i, j] = Math.Max(L[i - 1, j], L[i, j - 1]);
				}
			}

			// Following code is used to print LCS 
			int index = L[m, n];

			// Create a character array 
			// to store the lcs string 
			char[] lcs = new char[index];

			// Set the terminating character 
			//lcs[index] = '\0';

			// Start from the right-most-bottom-most corner 
			// and one by one store characters in lcs[] 
			int k = m, l = n;
			while (k > 0 && l > 0)
			{
				if (str1[k - 1] == str2[l - 1])
				{
					lcs[index - 1] = str1[k - 1];

					k--;
					l--;
					index--;
				}
				else if (L[k - 1, l] > L[k, l - 1])
					k--;
				else
					l--;
			}
			return lcs.ToList();
		}
	}
}
