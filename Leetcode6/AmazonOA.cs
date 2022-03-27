using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class AmazonOA
    {
        public long findTotalImbalance(List<int> rank)
        {
            long result = 0;
            IList<IList<int>> allGroups = new List<IList<int>>();
            int k = 2;
            while (k <= rank.Count)
            {
                List<int> curr = null;
                int idx = 0;
                while (idx <= rank.Count - k)
                {
                    curr = new List<int>();
                    for (int i = idx; i < (k+idx); i++)
                    {
                        curr.Add(rank[i]);
                    }
                    allGroups.Add(new List<int>(curr));
                    idx++;
                }
                k++;
            }


            //Dictionary<int, int> rankPosMap = new Dictionary<int, int>();
            //for (int i = 0; i < rank.Count; i++)
            //    rankPosMap.Add(rank[i], i);

            //dfsAndBackTrack(0, rank, new List<int>(), allGroups, rankPosMap);

            foreach (var group in allGroups)
            {
                result += imbalanceHelper(group.ToArray());
            }
            return result;
        }
        private long imbalanceHelper(int[] group)
        {
            long groupImbalance = 0;
            Array.Sort(group);
            for (int i = 1; i < group.Length; i++)
            {
                if (group[i] - group[i - 1] > 1)
                    groupImbalance++;
            }
            return groupImbalance;
        }
        void dfsAndBackTrack(int index, List<int> nums, List<int> current, IList<IList<int>> allGroups, Dictionary<int, int> rankPosMap)
        {
            allGroups.Add(new List<int>(current)); 
            for (int i = index; i < nums.Count; i++) 
            {
                if (current.Count > 0 && rankPosMap[nums[i]] - rankPosMap[current[current.Count - 1]] > 1) continue;
                current.Add(nums[i]);
                dfsAndBackTrack(i + 1, nums, current, allGroups, rankPosMap);
                current.RemoveAt(current.Count - 1);
            }
        }
    }
}
