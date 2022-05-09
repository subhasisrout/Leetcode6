// #Inspired from #AlgoExpert #AE SubArraySort
// #UPDATE 2022-05-03. Added solution using monotonic stack and 4 forloops method.

namespace Leetcode
{
    public class ShortestUnsortedContinuousSubarrayLC581
    {
        public int FindUnsortedSubarray(int[] nums)
        {
            if (nums.Length == 1) return 0;
            int maxNumOutOfPlace = Int32.MinValue;
            int minNumOutOfPlace = Int32.MaxValue;
            bool isOutOfOrderFound = false;

            for (int i = 0; i < nums.Length; i++)
            {
                bool isNumOfPlace = false;
                if (i == 0) // first element
                {
                    if (nums[1] < nums[0])
                        isNumOfPlace = true;
                }
                else if (i == nums.Length - 1) //last element
                {
                    if (nums[nums.Length - 1] < nums[nums.Length - 2])
                        isNumOfPlace = true;
                }
                else if (!((nums[i - 1] <= nums[i]) && (nums[i] <= nums[i + 1]))) //rest of the elements
                {
                    isNumOfPlace = true;
                }


                if (isNumOfPlace)
                {
                    isOutOfOrderFound = true;
                    maxNumOutOfPlace = Math.Max(maxNumOutOfPlace, nums[i]);
                    minNumOutOfPlace = Math.Min(minNumOutOfPlace, nums[i]);
                }
            }
            if (isOutOfOrderFound == false)
                return 0;
            else
            {
                int[] result = new int[2];
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] <= minNumOutOfPlace)
                    {
                        continue;
                    }
                    else
                    {
                        result[0] = i;
                        break;
                    }
                }
                for (int i = nums.Length - 1; i >= 0; i--)
                {
                    if (nums[i] >= maxNumOutOfPlace)
                    {
                        continue;
                    }
                    else
                    {
                        result[1] = i;
                        break;
                    }
                }
                return result[1] - result[0] + 1;
            }
        }

        //O(n) TIME and O(1) SPACE
        //4 for loops to find MIN, MAX and correct POSITIONS of MIN,MAX for the unsorted part
        public int FindUnsortedSubarray2(int[] nums)
        {
            int min = Int32.MaxValue;
            int max = Int32.MinValue;
            //Get min and max of the unsorted part
            bool flag = false;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] < nums[i - 1])
                    flag = true;
                if (flag)
                    min = Math.Min(min, nums[i]);
            }
            flag = false;
            for (int i = nums.Length - 2; i >= 0; i--)
            {
                if (nums[i] > nums[i + 1])
                    flag = true;
                if (flag)
                    max = Math.Max(max, nums[i]);
            }

            //Get the correct pos of min and max
            int l, r = 0;
            for (l = 0; l < nums.Length; l++)
            {
                if (min < nums[l])
                    break;
            }
            for (r = nums.Length - 1; r >= 0; r--)
            {
                if (max > nums[r])
                    break;
            }

            //if the array is already sorted, l will reach end and r will reach in the start, so r-l will be negative
            return r - l < 0 ? 0 : r - l + 1;

        }

        //O(n) TIME and SPACE
        //#MonotonicStack #Stack
        public int FindUnsortedSubarray3(int[] nums)
        {
            Stack<int> stack = new Stack<int>();
            int l = nums.Length; //invalid values for l and r
            int r = -1;//invalid values for l and r
            for (int i = 0; i < nums.Length; i++)
            {
                while (stack.Count > 0 && nums[stack.Peek()] > nums[i])
                    l = Math.Min(l, stack.Pop());
                stack.Push(i);
            }

            stack.Clear();
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && nums[stack.Peek()] < nums[i])
                    r = Math.Max(r, stack.Pop());
                stack.Push(i);
            }
            // if the array is sorted, r and l will never be updated. r-l will be -1-10 (-11)
            return r - l < 0 ? 0 : r - l + 1;

        }
    }
}
