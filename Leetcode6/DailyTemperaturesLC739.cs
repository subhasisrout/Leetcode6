using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// #Stack #MonotonicStack
// Inspired from Neetcode - https://www.youtube.com/watch?v=cTBiBSnjO3c

namespace Leetcode
{
    public class DailyTemperaturesLC739
    {
        public int[] DailyTemperatures(int[] temperatures)
        {
            Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>(); //idx,temp
            int[] result = new int[temperatures.Length];
            for (int i = 0; i < temperatures.Length; i++)
            {
                while (stack.Count > 0 && temperatures[i] > stack.Peek().Item2)
                {
                    var poppedVal = stack.Pop();
                    result[poppedVal.Item1] = (i - poppedVal.Item1);
                }
                stack.Push(new Tuple<int, int>(i, temperatures[i]));
            }
            return result; // default values will have 0, which is what we want.
        }
    }
}
