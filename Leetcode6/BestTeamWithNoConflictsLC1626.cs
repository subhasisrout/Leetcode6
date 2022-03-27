using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// #LIS . Note this is longest increasing subsequence SUM. There is another variant which is longest increasing subsequence (length).
// #LC300

// #Sorting using lambda.

namespace Leetcode
{
    public class BestTeamWithNoConflictsLC1626
    {
        public int BestTeamScore(int[] scores, int[] ages)
        {
            List<Candidate> candidates = new List<Candidate>();
            int n = scores.Length;
            for (int i = 0; i < n; i++)
                candidates.Add(new Candidate(ages[i], scores[i]));

            candidates.Sort((a, b) => a.Age == b.Age ? a.Score.CompareTo(b.Score) : a.Age.CompareTo(b.Age));

            //now setup is ready for LIS-maxSum. Now do passes from left to right on "candidates" list
            //candidates on the left are guaranteed to be younger or same age--- one part of the condition satisified.
            //If we make sure, its LIS (longest increasing subsequence), then--- then other part of the condition will also be satisfied.
            int[] sums = new int[n];
            for (int i = 0; i < n; i++)
                sums[i] = candidates[i].Score;
            int maxSum = 0;

            for (int i = 0; i < n; i++)
            {
                int currNum = candidates[i].Score;
                for (int j = 0; j < i; j++)
                {
                    int otherNum = candidates[j].Score;
                    if (otherNum <= currNum && sums[j] + currNum >= sums[i])
                    {
                        sums[i] = sums[j] + currNum;
                    }
                }
                if (sums[i] > maxSum)
                    maxSum = sums[i];
            }
            return maxSum;
        }

        public class Candidate
        {
            public int Age;
            public int Score;
            public Candidate(int age, int score)
            {
                this.Age = age;
                this.Score = score;
            }
        }
    }
}
