using System.Collections.Generic;


// This is a typical DFS.

namespace Leetcode
{
    public class FrogJumpLC403
    {
        public bool CanCross(int[] stones)
        {
            for (int i = 3; i < stones.Length; i++)
            {
                if (stones[i] > stones[i - 1] * 2)
                    return false;
            }

            HashSet<int> stonePositions = new HashSet<int>();
            for (int i = 0; i < stones.Length; i++)
            {
                stonePositions.Add(stones[i]);
            }

            Stack<int> positions = new Stack<int>();
            Stack<int> jumps = new Stack<int>();

            positions.Push(0);
            jumps.Push(0);

            while (positions.Count > 0)
            {
                int currentPos = positions.Pop();
                int currentJump = jumps.Pop();

                for (int i = currentJump - 1; i <= currentJump + 1; i++)
                {
                    if (i <= 0)
                        continue;

                    int nextPosition = currentPos + i;

                    if (nextPosition == stones[stones.Length - 1])
                        return true;
                    else if (stonePositions.Contains(nextPosition))
                    {
                        positions.Push(nextPosition);
                        jumps.Push(i);
                    }
                }
            }
            return false;

        }

    }

}
