using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// #DFS #Graph
namespace Leetcode
{
    public class PartitionEqualSubsetSumLC416
    {
        public bool CanPartition(int[] nums)
        {
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
            }

            if (sum % 2 != 0)
                return false;

            return CanPartitionHelper(nums, 0, 0, sum);
            //return CanPartitionHelperWithMemoization(nums, 0, 0, sum, new Dictionary<string, bool>());
        }


        //Below is an naive version without memoization
        private bool CanPartitionHelper(int[] nums, int index, int total, int sum)
        {
            if (total == sum / 2)
                return true;
            if (index >= nums.Length || total > sum / 2)
                return false;

            //https://www.youtube.com/watch?v=3N47yKRDed0
            //Solution explanation from Kevin Naughton Jr. It really boils down to check all element
            //to total to sum/2. So we either pick a number (added to 'total') or not pick a number ('total' unchanged).
            //Whenever we need to simulate pick or not pick, we can use OR operation.
            return CanPartitionHelper(nums, index + 1, total + nums[index], sum) ||
                CanPartitionHelper(nums, index + 1, total, sum);
        }

        private bool CanPartitionHelperWithMemoization(int[] nums, int index, int total, int sum, Dictionary<string,bool> map)
        {
            string current = index + "-" + total;
            if (map.ContainsKey(current))
                return map[current];
            if (total == sum / 2)
                return true;
            if (index >= nums.Length || total > sum / 2)
                return false;

            bool isPartitionFound = CanPartitionHelperWithMemoization(nums, index + 1, total + nums[index], sum, map) ||
                CanPartitionHelperWithMemoization(nums, index + 1, total, sum, map);
            map[current] = isPartitionFound;
            return isPartitionFound;
        }
    }
}
