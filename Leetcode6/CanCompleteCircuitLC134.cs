
// #VERYINTERESTING Inspired from AlgoExpert valid starting city
// Referred Leetcode discussions - https://leetcode.com/problems/gas-station/discuss/42568/Share-some-of-my-ideas./180595
// youtube video - https://www.youtube.com/watch?v=wDgKaNrSOEI

namespace Leetcode
{
    public class CanCompleteCircuitLC134
    {
        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            int tank = 0;
            for (int i = 0; i < gas.Length; i++)
            {
                tank = tank + gas[i] - cost[i];
            }
            if (tank < 0)
                return -1;

            int start = 0;
            tank = 0;
            for (int i = 0; i < gas.Length; i++)
            {
                tank = tank + gas[i] - cost[i];
                if (tank < 0)
                {
                    tank = 0;
                    start = i + 1;
                }
            }
            return start;

        }
    }
}
