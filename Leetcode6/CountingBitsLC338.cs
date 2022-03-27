// #Bitwise
// Similar to NumberOf1BitsLC191 (HammingWeight)
// If we apply the above function for each number in a loop. It will be nLogn.
// Below is like DP - optimized and uses past result.

// Formula below : Number of 1 bits in any 32 bit integer is -
// Number of 1 bits in that number (excluding the LSB) + the last digit (if 1)
// recurrence[i/2] + (IsLastDigitOne)
// recurrence[i >> 1] + (i & 1)
// Good explanation at - https://leetcode.com/problems/counting-bits/discuss/270693/Intermediate-processsolution-for-the-most-voted-solution-i.e.-no-simplificationtrick-hidden


namespace Leetcode
{
    public class CountingBitsLC338
    {
        public int[] CountBits(int n)
        {
            int[] rec = new int[n + 1];
            for (int i = 1; i <= n; i++)
            {
              //rec[6] = rec[3] + (lastDigit)
                rec[i] = rec[i >> 1] + (i & 1);
            }
            return rec;
        }
    }
}
