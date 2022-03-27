using System.Collections.Generic;

// #Note since its #recursion, there is an "internal recursion stack" involved 
// instead of extra space that you see in iterative approach.


namespace Leetcode
{
    public class SortStackRecursiveAE
    {
        public List<int> SortStack(List<int> stack)
        {
            Sort(stack);
            return stack;
        }

        private void Sort(List<int> stack)
        {
            if (stack.Count == 0)
                return;

            int top = stack[stack.Count - 1];
            stack.RemoveAt(stack.Count - 1);
            Sort(stack);
            InsertAtCorrectPosition(stack, top);

        }
        private void InsertAtCorrectPosition(List<int> stack, int num)
        {
            if (stack.Count == 0 || stack[stack.Count - 1] <= num)
                stack.Add(num);
            else
            {
                int top = stack[stack.Count - 1];
                stack.RemoveAt(stack.Count - 1);
                InsertAtCorrectPosition(stack, num);
                stack.Add(top);
            }
        }
    }
}
