// #Self written. #Helper methods making it more readable.
// #Leetcode #LC34
// Another self written single helper method.

namespace Leetcode
{
    public class SearchForRangeBinSearchAE
    {
        public int[] SearchRange(int[] nums, int target)
        {
            int l = 0;
            int r = nums.Length - 1;
            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                if (target > nums[mid])
                    l = mid + 1;
                else if (target < nums[mid])
                    r = mid - 1;
                else
                {
                    int resultLeft = FindLeftMostTargetPos(nums, target, mid);
                    int resultRight = FindRightMostTargetPos(nums, target, mid);
                    return new int[] {resultLeft, resultRight };
                }
            }
            return new int[] {-1,-1};
        }

        private int FindRightMostTargetPos(int[] array, int target, int left)
        {
            if (left == array.Length - 1)
                return array.Length - 1;

            int l = left;
            int r = array.Length - 1;

            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                if (target < array[mid])
                    r = mid - 1;
                else
                {
                    if (mid == array.Length - 1)
                        return array.Length - 1;
                    else if (array[mid + 1] != target)
                        return mid;
                    else
                        l = mid + 1;
                }
            }
            return -1;
        }

        private int FindLeftMostTargetPos(int[] array, int target, int right)
        {
            if (right == 0)
                return 0;
            
            int l = 0;
            int r = right;

            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                if (target > array[mid])
                    l = mid + 1;
                else
                {
                    if (mid == 0)
                        return 0;
                    else if (array[mid - 1] != target)
                        return mid;
                    else
                        r = mid - 1;
                }
            }
            return -1;
        }

        // Leetcode 34 Self written solution

        public int[] SearchRange2(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0) return new int[] { -1, -1 };
            int startingPos = BinSearch(nums, target, 0, nums.Length - 1, true);
            int endingPos = BinSearch(nums, target, 0, nums.Length - 1, false);
            return new int[] { startingPos, endingPos };
        }

        private int BinSearch(int[] nums, int target, int start, int end, bool goLeft)
        {
            while (end >= start)
            {
                int mid = start + (end - start) / 2;
                if (target > nums[mid])
                {
                    start = mid + 1;
                }
                else if (target < nums[mid])
                {
                    end = mid - 1;
                }
                else
                { //target == mid.. search towards left.
                    if (goLeft)
                    {
                        if (mid - 1 >= 0 && nums[mid - 1] == target)
                        {
                            end = mid - 1;
                        }
                        else
                        {
                            return mid;
                        }
                    }
                    else
                    { // search towards right.
                        if (mid + 1 < nums.Length && nums[mid + 1] == target)
                        {
                            start = mid + 1;
                        }
                        else
                        {
                            return mid;
                        }
                    }
                }
            }
            return -1;
        }

    }
}
