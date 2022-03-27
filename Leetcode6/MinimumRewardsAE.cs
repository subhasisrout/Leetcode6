using System;
using System.Linq;

// #AE #AlgoExpert #Hard #Tricky. Formula to be used - rewards[i] = Math.Max(rewards[i], 1 + rewards[i + 1]);
// #LC #Leetcode 135 (hard) LC135
// #RememberPattern

namespace Leetcode
{
    public class MinimumRewardsAE
    {
        public static int MinRewards(int[] scores)
        {
            int[] rewards = new int[scores.Length];
            for (int i = 0; i < rewards.Length; i++)
            {
                rewards[i] = 1;
            }
            for (int i = 1; i < scores.Length; i++) //left to right sweep
            {
                if (scores[i] > scores[i - 1])
                    rewards[i] = rewards[i - 1] + 1;
            }
            for (int i = scores.Length - 2; i >= 0; i--)// right to left sweep with the FORMULA
            {
                if (scores[i] > scores[i + 1])
                    rewards[i] = Math.Max(rewards[i], 1 + rewards[i + 1]);
            }
            return rewards.Sum();
        }
    }
}
