using System.Collections.Generic;

// #NESTEDMETHOD
// Intuitive. Inspired from #Neetcode. https://www.youtube.com/watch?v=qhBVWf0YafA 
// unlike SORTING + if (visited[i] || i > 0 && nums[i] == nums[i-1] && !visited[i-1]) continue;]


namespace Leetcode
{
    public class PermutationsLC47
    {
        public IList<IList<int>> PermuteUnique(int[] nums)
        {
            IList<IList<int>> ans = new List<IList<int>>();
            IList<int> curr = new List<int>();
            Dictionary<int, int> counts = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (counts.ContainsKey(nums[i]))
                    counts[nums[i]] += 1;
                else
                    counts.Add(nums[i], 1);
            }

            //NestedMethod
            void dfsBackTrack()
            {
                if (curr.Count == nums.Length)
                {
                    ans.Add(new List<int>(curr));
                    return;
                }

                foreach (var kvpair in counts)
                {
                    if (kvpair.Value > 0)
                    {
                        curr.Add(kvpair.Key);
                        counts[kvpair.Key] -= 1;

                        dfsBackTrack();

                        counts[kvpair.Key] += 1;
                        curr.RemoveAt(curr.Count - 1);
                    }
                }
            }

            dfsBackTrack();
            return ans;

        }
    }
}
