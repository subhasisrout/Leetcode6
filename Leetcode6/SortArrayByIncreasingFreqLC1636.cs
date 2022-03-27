using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// #Remember.NET Right way to use comparer
// Logic is easy, but comparer has to be used.

namespace Leetcode
{
    public class SortArrayByIncreasingFreqLC1636
    {
        public int[] FrequencySort(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return null;

            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (map.ContainsKey(nums[i]))
                    map[nums[i]] = map[nums[i]] + 1;
                else
                    map.Add(nums[i], 1);
            }

            Array.Sort(nums, new NumberComparer(map));

            return nums;
        }
    }
    public class NumberComparer : IComparer<int>
    {
        Dictionary<int, int> map;
        public NumberComparer(Dictionary<int, int> map)
        {
            this.map = map;
        }
        public int Compare(int x, int y)
        {
            if (this.map[x] != this.map[y])
                return this.map[x].CompareTo(this.map[y]);
            else
                return y.CompareTo(x);
        }
    }
}
