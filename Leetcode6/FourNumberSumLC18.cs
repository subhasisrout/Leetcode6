using System;
using System.Collections.Generic;

// #Slightly different from the #AlgoExpert #AE question
// Here the number is not distinct
// This solution runs in O(n^3) time unlike AE's one. This solution does not take extra space
// and builds upon 2Sum problem. Refer GoodTecher solution for more information.
// For 2Sum problem, this solution uses sorting + 2pointer approach.

namespace Leetcode
{
    public class FourNumberSumLC18
    {
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            Array.Sort(nums);
            IList<IList<int>> result = new List<IList<int>>();

            for (int i = 0; i < nums.Length - 3; i++) // leave the last three nums.
            {
                if (i != 0 && nums[i - 1] == nums[i])
                    continue;

                for (int j = i + 1; j < nums.Length - 2; j++)
                {
                    if (j != i + 1 && nums[j - 1] == nums[j]) // note j != i+1. Start of this inner loop.
                        continue;

                    int left = j + 1;
                    int right = nums.Length - 1;

                    while (left < right)
                    {
                        int sum = nums[i] + nums[j] + nums[left] + nums[right];
                        if (sum < target)
                        {
                            left++;
                        }
                        else if (sum > target)
                        {
                            right--;
                        }
                        else
                        {
                            result.Add(new List<int>() { nums[i], nums[j], nums[left], nums[right] });
                            left++;
                            right--;

                            while (left < right && nums[left] == nums[left - 1]) //keep moving if you get duplicates
                            {
                                left++;
                            }

                            while (left < right && nums[right] == nums[right + 1]) //keep moving if you get duplicates
                            {
                                right--;
                            }
                        }
                    }
                }
            }

            return result;
        }
    }
}


