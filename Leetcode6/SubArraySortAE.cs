using System;

// #Leetcode #LC 581

namespace Leetcode
{
    public class SubArraySortAE
    {
        public static int[] SubarraySort(int[] nums)
        {
            int maxNumOutOfPlace = Int32.MinValue;
            int minNumOutOfPlace = Int32.MaxValue;
            bool isOutOfOrderFound = false;

            for (int i = 0; i < nums.Length; i++)
            {
                bool isNumOfPlace = false;
                if (i == 0) // first element
                {
                    if (nums[1] < nums[0])
                        isNumOfPlace = true;
                }
                else if (i == nums.Length - 1) //last element
                {
                    if (nums[nums.Length - 1] < nums[nums.Length - 2])
                        isNumOfPlace = true;
                }
                else if (!((nums[i - 1] <= nums[i]) && (nums[i] <= nums[i + 1]))) //rest of the elements
                {
                    isNumOfPlace = true;
                }


                if (isNumOfPlace)
                {
                    isOutOfOrderFound = true;
                    maxNumOutOfPlace = Math.Max(maxNumOutOfPlace, nums[i]);
                    minNumOutOfPlace = Math.Min(minNumOutOfPlace, nums[i]);
                }
            }
            if (isOutOfOrderFound == false)
                return new int[] { -1, -1 };
            else
            {
                int[] result = new int[2];
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] <= minNumOutOfPlace)
                    {
                        continue;
                    }
                    else
                    {
                        result[0] = i;
                        break;
                    }
                }
                for (int i = nums.Length - 1; i >= 0; i--)
                {
                    if (nums[i] >= maxNumOutOfPlace)
                    {
                        continue;
                    }
                    else
                    {
                        result[1] = i;
                        break;
                    }
                }
                return result;
            }


        }
    }
}
