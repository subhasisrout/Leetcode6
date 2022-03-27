using System.Collections.Generic;

// #DFS #Backtrack #Graph
// #RememberPattern
// Observe the difference between this and LC78
// // This is more generic than AE version and can be applied in Permuatation-II as well. Learn this.

// Update 6th March 2022 - Generally speaking this can be done using 2 approach. Approach 1 uses extra space (visited array or hashset). Approach 2 does not that 
// extra space for tracking visited, rather it uses Swapping.
// Intuition of Approach 2 - You pass idx to the BackTrack method and inside the BackTrack method, you use 'i' from idx to n-1. BackTrack is called again
// with (idx + 1). BackTracking is done by Swapping again.

// In approach 1, since you are using extra space - you need not pass idx and always run the loop from 0..(n-1)
// Inspired from Striver channel - Take U forward - https://www.youtube.com/watch?v=YK78FU5Ffjw , https://www.youtube.com/watch?v=f2ic2Rsc9pU

// Looks like for LC47 - you can only use Approach 1 (extra space - Dictionary instead of HashSet). So learn that. Check PermutationsLC47
// If you dont want to use extra space then Sorting is required PLUS if (visited[i] || i > 0 && nums[i] == nums[i-1] && !visited[i-1]) continue;
// Not using extra space is NOT INTUITIVE approach

namespace Leetcode
{
    public class PermutationsLC46
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();
            bool[] visited = new bool[nums.Length];
            PermuteHelper(nums, result, new List<int>(), visited);
            return result;
        }

        //Approach 1
        private void PermuteHelper(int[] nums, IList<IList<int>> result, IList<int> current, bool[] visited)
        {
            if (current.Count == nums.Length)
            {
                result.Add(new List<int>(current));
                return;
            }
            for (int i = 0; i < nums.Length; i++)
            {
                // In Permuations 2 - LC47 and Sorting required.
                // This line become if (visited[i] || i > 0 && nums[i] == nums[i-1] && !visited[i-1]) continue;
                if (visited[i]) continue; 
                visited[i] = true;
                current.Add(nums[i]);
                PermuteHelper(nums, result, current, visited);
                current.RemoveAt(current.Count - 1);
                visited[i] = false;
                // above 5-6 lines are a standard for all backtrackking problems.
            }
        }

        // Approach 2
        /*
        private void DFSSwapAndBacktrack(IList<IList<int>> ans,int idx, int[] nums){
            if (idx == nums.Length){
                ans.Add(new List<int>(nums));
                return;
            }
        
            for (int i = idx; i < nums.Length; i++){
                Swap(i,idx,nums);
                DFSSwapAndBacktrack(ans,idx+1,nums);
                Swap(i,idx,nums);
            }
        
        }
    
        private void Swap(int idx1, int idx2, int[] arr){
            int temp = arr[idx1];
            arr[idx1] = arr[idx2];
            arr[idx2] = temp;
        }*/
    }
}
