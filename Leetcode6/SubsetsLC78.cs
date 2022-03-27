using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// This is a dfs PLUS backtrackking problem. For visuals, use SubsetsLC78.jpg
// Use DFS plus backtrackking, whenever the problem is like - "possible number of", "all exhaustive list of"
// On the contrary, if the problem is maximum/minimum #'s of, its "greedy"
// #DFS #Backtrack #Graph
// #RememberPattern

// #AE #AlgoExpert (Goes by the name of "Powerset"). Very intuitive iterative solution.

namespace Leetcode
{
    public class SubsetsLC78
    {
        IList<IList<int>> retval = new List<IList<int>>();
        public IList<IList<int>> Subsets(int[] nums)
        {
            dfsAndBackTrack(0, nums, new List<int>());
            return retval;
        }
        void dfsAndBackTrack(int index, int[] nums, List<int> current)
        {
            retval.Add(new List<int>(current)); //new List() is for making DEEPCOPY, as current reference keep on changing.
            for (int i = index; i < nums.Length; i++) // This corresponds to the 3 main branches in the visual [1 -- 2 -- 3]
            {
                //There is one extra check here in Subsets 2 if (i > index && nums[i] == nums[i-1]) continue;
                current.Add(nums[i]);
                dfsAndBackTrack(i + 1, nums, current);
                current.RemoveAt(current.Count - 1);
            }
        }

        // #VERYINTUITIVE BUT DONT REMEMBER THIS AS THIS CANNOT BE USED WITH DUPLICATES
        public List<List<int>> Powerset(List<int> array)
        {
            List<List<int>> result = new List<List<int>>();
            result.Add(new List<int>());

            for (int i = 0; i < array.Count; i++)
            {
                int currentCount = result.Count; //Only loop through existing number of elements in "result" and "add" the currentNum to it.
                for (int j = 0; j < currentCount; j++)
                {
                    var currentEntry = new List<int>(result[j]);
                    currentEntry.Add(array[i]);
                    result.Add(currentEntry);
                }
            }
            return result;
        }
    }
}
