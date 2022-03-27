using System.Collections.Generic;
using System.Linq;

// Similar to KthLargestElementLC215 EXCEPT > or < is on the basis of map count. So declared global.
// Remember #QuickSelect QuickSelectHelper from AlgoExpert #AE as its more intuitive.

namespace Leetcode
{
    public class TopKFrequentElementsLC347
    {
        Dictionary<int, int> map;
        public int[] TopKFrequent(int[] nums, int k)
        {
            map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (map.ContainsKey(nums[i]))
                    map[nums[i]] = map[nums[i]] + 1;
                else
                    map.Add(nums[i], 1);
            }

            int n = map.Count;
            int[] arr = new int[n];
            int idx = 0;
            foreach (KeyValuePair<int, int> entry in map)
            {
                arr[idx++] = entry.Key;
            }

            return QuickSelect(arr, k); //on the basis of map(count)
        }

        private int[] QuickSelect(int[] arr, int k)
        {
            QuickSelectHelper(arr, k, 0, arr.Length - 1);
            return arr.Skip(arr.Length - k).ToArray();
        }

        private void QuickSelectHelper(int[] arr, int k, int start, int end) //same as normal QuickSelectHelper EXCEPT on the basis of map(count)
        {
            if (start >= end)
                return;
            int pivot = start;
            int left = start + 1;
            int right = end;

            while (left <= right)
            {
                if (map[arr[left]] > map[arr[pivot]] && map[arr[right]] <= map[arr[pivot]])
                    Swap(arr, left, right);
                else if (map[arr[left]] <= map[arr[pivot]])
                    left++;
                else if (map[arr[right]] >= map[arr[pivot]])
                    right--;
            }
            Swap(arr, pivot, right);

            if (right == arr.Length - k) //because 'right' is the new pivot now (after swap above)
                return;
            else if (arr.Length - k < right)
                QuickSelectHelper(arr, k, start, right - 1);
            else
                QuickSelectHelper(arr, k, right + 1, end);
        }

        private void Swap(int[] arr, int index1, int index2)
        {
            int tmp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = tmp;
        }
    }
}
