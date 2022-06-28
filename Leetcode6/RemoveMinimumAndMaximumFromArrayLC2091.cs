namespace Leetcode6
{
    public class RemoveMinimumAndMaximumFromArrayLC2091
    {
        public int MinimumDeletions(int[] nums)
        {
            int n = nums.Length;
            int minIdx = 0;
            int maxIdx = 0;
            for (int i = 0; i < n; i++)
            {
                if (nums[i] < nums[minIdx])
                    minIdx = i;
                if (nums[i] > nums[maxIdx])
                    maxIdx = i;
            }
            int firstDiff = Math.Max(maxIdx, minIdx) + 1; //case1: when both are in left half
            int lastDiff = n - Math.Min(maxIdx, minIdx);  //case2: when both are in right half
            int midDiff = n - Math.Max(maxIdx, minIdx) + Math.Min(maxIdx, minIdx) + 1; //case3: when they are in opposite directions of mid Point.

            return Math.Min(Math.Min(firstDiff, lastDiff), midDiff);

        }
    }
}
