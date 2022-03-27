// #Pending. DP solution
// Most intuitive n^2 solution - https://leetcode.com/problems/count-number-of-teams/discuss/555441/JavaC%2B%2B-100-O(N2)-Easy-To-Understand-With-Explanation

using System.Collections.Generic;

namespace Leetcode
{
    public class CountNumberOfTeamsLC1395
    {
        public int NumTeams(int[] rating)
        {
            // i ,j, k            
            int result = 0;
            for (int j = 1; j < rating.Length; j++)
            {
                int lsCount = 0, rbCount = 0;
                int lbCount = 0, rsCount = 0;
                for (int i = 0; i < j; i++)
                {
                    if (rating[j] > rating[i])
                        lsCount++;
                    if (rating[j] < rating[i])
                        lbCount++;
                }

                for (int k = j + 1; k < rating.Length; k++)
                {
                    if (rating[j] > rating[k])
                        rsCount++;
                    if (rating[j] < rating[k])
                        rbCount++;
                }
                result += (lsCount * rbCount) + (lbCount * rsCount);
            }
            return result;
        }
    }
}
