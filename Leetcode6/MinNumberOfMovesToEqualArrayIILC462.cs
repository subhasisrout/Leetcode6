// intuition derived from https://leetcode.com/problems/minimum-moves-to-equal-array-elements-ii/discuss/1217473/C++PythonJava-2-Solutions-(w-and-wo-Median)-Explained-with-Example-implementation
// The middle element after sorting is called MEDIAN.
// Abs(i1-median) + Abs(i2-median)...+Abs(in-median) is the final answer
// from where the below answer can be derived. Check the link above for derivation.

namespace Leetcode6
{
    public class MinNumberOfMovesToEqualArrayIILC462
    {
        public int MinMoves2(int[] nums)
        {
            Array.Sort(nums);
            int i = 0;
            int j = nums.Length - 1;
            int result = 0;
            while (i < j)
            {
                result += nums[j] - nums[i];
                i++;
                j--;
            }
            return result;

        }
    }
}
