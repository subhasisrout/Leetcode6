//Same as #LC31
//Used #Stack.ToArray()

namespace Leetcode
{
    public class NextGreaterElementIIILC556
    {
        public int NextGreaterElement(int n)
        {
            int[] nums = NumToDigits(n);


            int first = nums.Length - 1;
            while (first >= 1 && nums[first - 1] >= nums[first])
            {
                first--;
            }
            if (first == 0)
            {
                //Array.Reverse(nums);
                return -1;
            }
            first--;

            int second = nums.Length - 1;
            while (second > first && nums[second] <= nums[first])
            {
                second--;
            }

            //Swap nums[first] and nums[second]
            Swap(nums, first, second);

            //Reverse substring between second and len-1 idx (inclusive)
            /*
            int i1 = first+1;
            int j1 = nums.Length - 1;
            while (i1 < j1){
                Swap(nums,i1,j1);
                i1++;
                j1--;
            }*/
            Array.Reverse(nums, first + 1, nums.Length - 1 - (first + 1) + 1);

            return DigitsToNum(nums);
        }
        private int[] NumToDigits(int n)
        {
            Stack<int> stack = new Stack<int>();
            while (n > 0)
            {
                int rem = n % 10;
                n = n / 10;
                stack.Push(rem);
            }
            return stack.ToArray();
        }
        private static int DigitsToNum(int[] digits)
        {
            double num = 0;
            int k = 0;
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                num += digits[i] * Math.Pow(10, k);
                k++;
            }
            if (num > Int32.MaxValue) return -1;
            return Convert.ToInt32(num);
        }


        private void Swap(int[] nums, int i, int j)
        {
            int tmp = nums[i];
            nums[i] = nums[j];
            nums[j] = tmp;
        }
    }
}
