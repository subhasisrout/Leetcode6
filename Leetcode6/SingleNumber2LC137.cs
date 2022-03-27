using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Excellent solution with intuition at https://leetcode.com/problems/single-number-ii/discuss/43294/Challenge-me-thx/176039 (comment thread copied)

/*
 * IF the set "ones" does not have A[i]
       Add A[i] to the set "ones" if and only if its not there in set "twos"
   ELSE
       Remove it from the set "ones"
*/

// Similar is for "twos"

namespace Leetcode
{
    public class SingleNumber2LC137
    {
        public int SingleNumber(int[] nums)
        {
            int ones = 0;
            int twos = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                ones = (nums[i] ^ ones) & ~twos;
                twos = (nums[i] ^ twos) & ~ones;
            }
            return ones;
        }
    }
}
