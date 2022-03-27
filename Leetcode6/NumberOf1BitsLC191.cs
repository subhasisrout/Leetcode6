// Also called the HammingWeight
// #Bitwise


namespace Leetcode
{
    public class NumberOf1BitsLC191
    {
        public int HammingWeight(uint n)  // int: –2147483648 to 2147483647 ----- uint: 0 to 4294967295
        {
            int count = 0;
            while (n != 0) // This is optimized as we are not looping 32 times in all cases unlike the below implementation
            {
                count++;
                n = n & (n - 1);
            }
            return count;
        }
        public int HammingWeight2(uint n) //lets say n = 5. meaning 00000000000000000000000000000101
        {
            int mask = 1; // meaning 00000000000000000000000000000001
            int count = 0;
            for (int i = 0; i < 32; i++)
            {
                if ((n & mask) != 0)
                    count++;
                mask <<= 1; // meaning left shift the 1 in line 21 (.....000000001)
            }
            return count;
        }
    }
}
