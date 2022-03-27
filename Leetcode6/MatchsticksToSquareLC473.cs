using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class MatchsticksToSquareLC473
    {
        int edgeLength = 0;
        int[] edgeArr = new int[4];
        public bool Makesquare(int[] matchsticks)
        {
            int sum = 0;
            for (int i = 0; i < matchsticks.Length; i++)
            {
                sum += matchsticks[i];
            }

            if (sum % 4 != 0) // quick exit check 1
                return false;
            if (matchsticks.Length < 4) // quick exit check 2
                return false;

            edgeLength = sum / 4;

            Array.Sort(matchsticks);
            Array.Reverse(matchsticks);

            for (int i = 0; i < matchsticks.Length; i++)
            {
                if (matchsticks[i] > edgeLength) // quick exit check 3
                    return false;
            }

            edgeArr = new int[4];

            return CanMakeSquareBackTrack(matchsticks, 0);

        }

        private bool CanMakeSquareBackTrack(int[] matchsticks, int currIdx)
        {
            if (currIdx == matchsticks.Length) //gone through all matchsticks
                return true;

            for (int i = 0; i < edgeArr.Length; i++)
            {
                if (edgeArr[i] + matchsticks[currIdx] <= edgeLength)
                {
                    edgeArr[i] += matchsticks[currIdx];
                    if (CanMakeSquareBackTrack(matchsticks, currIdx + 1) == true)
                        return true;
                    edgeArr[i] -= matchsticks[currIdx];
                }
            }
            return false; // gone through all four edges.
        }
    }
}
