using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class DFSInArrayGeneral
    {
        public List<List<int>> Subsets(int[] nums)
        {
            List<List<int>> list = new List<List<int>>();
            DFSHelper(list, new List<int>(), nums, 0);
            return list;
        }

        private void DFSHelper(List<List<int>> list,
                            List<int> tempList,
                            int[] nums,
                            int startIndex
                           )
        {
            list.Add(new List<int>(tempList));
            for (int i = startIndex; i < nums.Length; i++)
            {
                tempList.Add(nums[i]);
                DFSHelper(list, tempList, nums, i + 1);
                tempList.RemoveAt(tempList.Count - 1);
            }
        }
        public List<List<char>> SubsetsChar(char[] chars)
        {
            List<List<char>> list = new List<List<char>>();
            DFSHelperChar(list, new List<char>(), chars, 0);
            return list;
        }

        private void DFSHelperChar(List<List<char>> list,
                            List<char> tempList,
                            char[] nums,
                            int startIndex
                           )
        {
            list.Add(new List<char>(tempList));
            for (int i = startIndex; i < nums.Length; i++)
            {
                tempList.Add(nums[i]);
                DFSHelperChar(list, tempList, nums, i + 1);
                tempList.RemoveAt(tempList.Count - 1);
            }
        }
    }
}
