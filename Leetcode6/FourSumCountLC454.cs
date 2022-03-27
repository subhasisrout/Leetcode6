using System.Collections.Generic;

// #Clever #Different from 3Sum 4Sum.
// #Inspired from https://leetcode.com/problems/4sum-ii/discuss/93920/Clean-java-solution-O(n2)
/* Explaination https://leetcode.com/problems/4sum-ii/discuss/93917/Easy-2-lines-O(N2)-Python/319700
 * We add up a and b and store the result-frequency pair into AB.
E.g.
AB[5] = 2 means a+b=5 appears 2 times in the a+b scenario.
Then we are looking for how many times does c+d = -5 appear so that it could be paired with AB[5] and form a 0.
That's why we then look for AB[-c-d] (or AB[-(c+d)] )
 */


namespace Leetcode
{
    public class FourSumCountLC454
    {
        public int FourSumCount(int[] nums1, int[] nums2, int[] nums3, int[] nums4)
        {
            int result = 0;
            Dictionary<int, int> nums1nums2Freq = new Dictionary<int, int>();
            for (int i = 0; i < nums1.Length; i++)
            {
                for (int j = 0; j < nums2.Length; j++)
                {
                    int sum = nums1[i] + nums2[j];
                    if (nums1nums2Freq.ContainsKey(sum))
                        nums1nums2Freq[sum] = nums1nums2Freq[sum] + 1;
                    else
                        nums1nums2Freq.Add(sum, 1);
                }
            }

            for (int i = 0; i < nums3.Length; i++)
            {
                for (int j = 0; j < nums4.Length; j++)
                {
                    int sum = nums3[i] + nums4[j];
                    if (nums1nums2Freq.ContainsKey(sum * -1))
                        result = result + nums1nums2Freq[sum * -1];
                }
            }



            return result;
        }
    }
}
