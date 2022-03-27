// #QuickSelect #Inspired from #NeetCode
// Just remember.
// 1. Choose "pivot" as the last element. 
// 2. Pick a 'p' pointer which will be the tail of the left hand side.
// 3. Iterate using 'i' from 'l' to 'r' (dont touch 'r'). Swap index i and p and p++ for <= elements
// 4. After loop is over swap p with r.


namespace Leetcode
{
    public class KthLargestElementLC215
    {
        public int FindKthLargest(int[] nums, int k)
        {
            k = nums.Length - k;

            int QuickSelect(int l, int r)
            {
                int pivot = nums[r];
                int p = l; //p pointer is the tail of the left-hand side.

                for (int i = l; i < r; i++)
                { //dont touch r, as we have selected r (the last num) as the pivot
                    if (nums[i] <= pivot)
                    {
                        Swap(nums, i, p);
                        p++;
                    }
                }
                Swap(nums, p, r);

                if (p > k) return QuickSelect(l, p - 1);
                else if (p < k) return QuickSelect(p + 1, r);
                else return nums[p];
            }
            return QuickSelect(0, nums.Length - 1);
        }
        private void Swap(int[] arr, int i1, int i2)
        {
            int tmp = arr[i1];
            arr[i1] = arr[i2];
            arr[i2] = tmp;
        }
    }
}
