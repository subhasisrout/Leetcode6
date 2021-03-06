// #SlidingWindow pattern
// #RememberPattern
// #LC1695 (same/similar)

namespace Leetcode
{
    public class LongestSubstringWithoutRepeatingCharsLC3
    {
        // Below pattern is easy and intuitive
        public int LengthOfLongestSubstring(string s)
        {
            int l = 0, r = 0, maxLen = 0;
            HashSet<char> set = new HashSet<char>();
            while (r < s.Length)
            {
                if (!set.Contains(s[r]))
                {
                    set.Add(s[r]);
                    maxLen = Math.Max(maxLen, set.Count);
                    r++;
                }
                else
                {
                    set.Remove(s[l]);
                    l++;
                }

            }
            return maxLen;
        }

        // Below was originally written by me (ugly code)
        //public int LengthOfLongestSubstring2(string s)
        //{
        //    if (s == null || s.Length == 0)
        //        return 0;
        //    if (s.Length == 1)
        //        return 1;
        //    int i = 0;
        //    int j = 0;
        //    int result = 0;
        //    HashSet<char> set = new HashSet<char>();
        //    while (i < s.Length)
        //    {
        //        set.Add(s[i]);
        //        j = i + 1;
        //        while (j < s.Length)
        //        {
        //            if (!set.Contains(s[j]))
        //            {
        //                set.Add(s[j]);
        //                result = Math.Max(result, j - i + 1);
        //            }
        //            else
        //            {
        //                result = Math.Max(result, set.Count);
        //                set.Clear();
        //                break;
        //            }
        //            j++;
        //        }
        //        if (j == s.Length - 1)
        //            break;
        //        i++;
        //        Console.WriteLine($"{result}");
        //    }
        //    return result;
        //}


        public class MaximumErasureValueLC1695
        {
            public int MaximumUniqueSubarray(int[] nums)
            {
                int l = 0;
                int r = 0;
                int result = 0;
                int runningSum = 0;
                HashSet<int> set = new HashSet<int>();
                while (r < nums.Length)
                {
                    if (!set.Contains(nums[r])) //This if block updates r++ and the result
                    {
                        set.Add(nums[r]);
                        runningSum += nums[r];
                        result = Math.Max(result, runningSum);
                        r++;
                    }
                    else //This blocks removes nums[l], so during next iteration it is added by nums[r]
                    {
                        set.Remove(nums[l]);
                        runningSum -= nums[l];
                        l++;
                    }
                }

                return result;
            }
        }
    }
}
