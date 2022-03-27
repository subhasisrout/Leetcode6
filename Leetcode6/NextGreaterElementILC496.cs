using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class NextGreaterElementILC496
    {
        public int[] NextGreaterElement(int[] nums1, int[] nums2)
        {
            var map = NextGreaterElementOnRight(nums2);
            int[] result = new int[nums1.Length];
            for (int i = 0; i < nums1.Length; i++)
            {
                result[i] = map[nums1[i]];
            }
            return result;
        }
        private Dictionary<int,int> NextGreaterElementOnRight(int[] nums)
        {
            Stack<int> stack = new Stack<int>();
            Dictionary<int, int> result = new Dictionary<int, int>();
            if (nums == null || nums.Length == 0)
                return result;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && stack.Peek() <= nums[i])
                    stack.Pop();

                if (stack.Count == 0)
                    result.Add(nums[i], -1);
                else
                    result.Add(nums[i], stack.Peek());

                stack.Push(nums[i]);
            }
            return result;
        }

    }
}
