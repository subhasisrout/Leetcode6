using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// #Similar to LC457. Circular Array Loop
// Important part is this method - GetNewIndexAfterJump

namespace Leetcode
{
    public class HasSingleCycleAE
    {
        public bool HasSingleCycle(int[] nums)
        {
            HashSet<int> seenIndices = new HashSet<int>();
            int currentIndex = 0;
            int startIndex = 0;
            seenIndices.Add(startIndex);
            while (true)
            {
                int currentJump = nums[currentIndex];
                int newIndex = GetNewIndexAfterJump(nums.Length, currentIndex, currentJump);
                if (newIndex == startIndex)
                {
                    if (seenIndices.Count == nums.Length)
                        return true;
                    else
                        return false;
                }
                else if (seenIndices.Contains(newIndex))
                    return false;
                else
                    seenIndices.Add(newIndex);
                currentIndex = newIndex;
            }


        }

        private int GetNewIndexAfterJump(int arrayLength, int currIndex, int jump)
        {
            int newIndex = currIndex + jump;
            if (newIndex < 0)
            {
                newIndex = newIndex * -1;
                newIndex = newIndex % arrayLength;
                if (newIndex != 0)
                    newIndex = arrayLength - newIndex;
                else
                    newIndex = 0;
            }
            else if (newIndex > arrayLength - 1)
                newIndex = newIndex % arrayLength;

            return newIndex;
        }
    }
}
