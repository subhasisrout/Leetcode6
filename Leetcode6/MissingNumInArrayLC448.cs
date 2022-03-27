using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Yet another approach is cyclic sort. This approach be used in variety of places. Examples
// LC268, LC448, LC287, LC442, LC645, LC41
// Idea taken from https://www.youtube.com/watch?v=JfinxytTYFQ



namespace Leetcode
{
    public class MissingNumInArrayLC448
    {
        //4, 3, 2, 7, 8, 2, 3, 1
        //currentnum = 4
        //4,3,2,-7,8,2,3,1
        //currentnum = 3
        //4,3,-2,-7,8,2,3,1
        //currentnum = 8
        //4,3,-2,-7,8,2,3,-1
        //currentnum = 2
        //4,-3,-2,-7,8,2,3,-1
        //currentnum = 3

        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            List<int> results = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int currentNum = Math.Abs(nums[i]);
                if (currentNum > 0)
                    nums[currentNum - 1] = Math.Abs(nums[currentNum - 1]) * -1;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                    results.Add(i + 1);
            }

            return results;
        }


        public IList<int> FindDisappearedNumbers2(int[] nums)
        {
            IList<int> result = new List<int>();

            //do cyclic sort
            int i = 0;
            while (i < nums.Length)
            {
                if (nums[nums[i] - 1] != nums[i])
                {
                    Swap(nums, i, nums[i] - 1);
                }
                else
                {
                    i++;
                }
            }

            //arr is now cyclic sorted
            for (int k = 0; k < nums.Length; k++)
            {
                if (k != nums[k] - 1)
                    result.Add(k + 1);
            }

            return result;
        }
        private void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
