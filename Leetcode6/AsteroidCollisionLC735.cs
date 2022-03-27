using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class AsteroidCollisionLC735
    {
        public int[] AsteroidCollision(int[] asteroids)
        {
            Stack<int> stack = new Stack<int>();

            int i = 0;
            while (i < asteroids.Length)
            {
                if (asteroids[i] > 0)
                    stack.Push(asteroids[i]);
                else
                {
                    while (stack.Count > 0 && stack.Peek() > 0 && Math.Abs(stack.Peek()) < Math.Abs(asteroids[i]))
                    {
                        stack.Pop();
                    }
                    if (stack.Count > 0 && stack.Peek() > 0 && Math.Abs(stack.Peek()) == Math.Abs(asteroids[i]))
                    {
                        stack.Pop();
                    }
                    else if (stack.Count > 0 && stack.Peek() > 0 && Math.Abs(stack.Peek()) > Math.Abs(asteroids[i]))
                    {
                        //do nothing
                    }
                    else
                    {
                        stack.Push(asteroids[i]);
                    }
                }
                i++;
            }
            int[] output = new int[stack.Count];
            for (int k = stack.Count-1; k >= 0; k--)
            {
                output[k] = stack.Pop();
            }
            return output;
        }
    }
}
