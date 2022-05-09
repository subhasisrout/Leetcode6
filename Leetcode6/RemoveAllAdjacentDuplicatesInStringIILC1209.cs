// Inspired from Lee 's 2 pointer soln - https://leetcode.com/problems/remove-all-adjacent-duplicates-in-string-ii/discuss/392933/JavaC%2B%2BPython-Two-Pointers-and-Stack-Solution
// Based on EASY PROBLEM LC1047
// Pattern - Because we have look back k characters, we are using count[] and updating count[i] based on count[i-1]

namespace Leetcode6
{
    public class RemoveAllAdjacentDuplicatesInStringIILC1209
    {
        public string RemoveDuplicates(string s, int k)
        {
            int i = 0;
            int j = 0;
            int[] count = new int[s.Length];
            char[] res = s.ToCharArray();
            for (j = 0; j < s.Length; j++, i++)
            {
                res[i] = res[j];
                if (i > 0 && res[i - 1] == res[i])
                {
                    count[i] = count[i - 1] + 1;
                }
                else
                {
                    count[i] = 1;
                }

                if (count[i] == k)
                    i = i - k;
            }
            return new String(res, 0, i);
        }

        //Based on EASY PROBLEM LC1047
        /*
        public string RemoveDuplicates(string s) {
        int i=0;
        int j=0;
        char[] res = s.ToCharArray();
        for (j=0; j<s.Length; i++, j++){
            res[i] = res[j];
            if (i> 0 && res[i-1]==res[i])
                i=i-2;
        }
        return new String(res,0,i);
        }
        */
    }
}
