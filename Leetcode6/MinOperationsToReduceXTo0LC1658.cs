// #variation of #prefixsum #clever
namespace Leetcode6
{
    public class MinOperationsToReduceXTo0LC1658
    {
        public int MinOperations(int[] nums, int x)
        {
            int target = -1 * x;
            for (int i = 0; i < nums.Length; i++)
                target += nums[i];
            if (target == 0) return nums.Length; //this is an edge case

            Dictionary<int, int> map = new Dictionary<int, int>(); //prefixSum map (sum:index)
            map.Add(0, -1);
            int res = -1;
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                if (map.ContainsKey(sum - target))
                {
                    res = Math.Max(res, i - map[sum - target]);
                }
                map.Add(sum, i);
            }
            return res == -1 ? -1 : nums.Length - res;

        }
    }
}

