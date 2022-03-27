// #Greedy

namespace Leetcode
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class LargestNumberLC179
    {
        public string LargestNumber(int[] nums)
        {
            if (nums == null || nums.Length == 0) return "";
            string[] strNums = new string[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                strNums[i] = Convert.ToString(nums[i]);
            }

            Array.Sort(strNums, new StringComparer());

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < strNums.Length; i++)
                sb.Append(strNums[i]);

            // After sorting, if the first num (biggest num) is 0, then it means all the nums are 0.
            // 00000000000
            if (strNums[0] == "0") return "0";
            
            return sb.ToString();

        }

    }

    public class StringComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            string order1 = x + y;
            string order2 = y + x;
            return order2.CompareTo(order1);
        }
    }
}

