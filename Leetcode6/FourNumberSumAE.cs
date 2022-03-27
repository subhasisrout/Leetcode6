using System.Collections.Generic;

// #AE #AlgoExpert #Clever use of extra space
// Look at the video for "an image" of the solution. Look at the inner loops for right and left movement.

namespace Leetcode
{
    public class FourNumberSumAE
    {
        public static List<int[]> FourNumberSum(int[] nums, int targetSum)
        {
            List<int[]> result = new List<int[]>();
            Dictionary<int, List<int[]>> map = new Dictionary<int, List<int[]>>();

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++) // Inner loop 1 for right movement, checking map and adding to result
                {
                    int currentPairSum = nums[i] + nums[j];
                    int diff = targetSum - currentPairSum;
                    if (map.ContainsKey(diff))
                    {
                        var mapValues = map[diff];
                        foreach (var item in mapValues)
                        {
                            result.Add(new int[] { nums[i], nums[j], item[0], item[1] });
                        }
                    }
                    // else do nothing
                }

                for (int k = i - 1; k >= 0; k--) // Inner loop 2 for left movement, and adding to map.
                {
                    int currentSumPair = nums[i] + nums[k];
                    if (map.ContainsKey(currentSumPair))
                        map[currentSumPair].Add(new int[] { nums[i], nums[k] });
                    else
                        map.Add(currentSumPair, new List<int[]>() { new int[] { nums[i], nums[k] } });
                }
            }
            return result;

        }
    }

}
