// Inspired from #Neetcode https://www.youtube.com/watch?v=4RACzI5-du8
// #Blind75 #PalindromeOddEven

namespace Leetcode6
{
    public class PalindromicSubstringsLC647
    {
        public int CountSubstrings(string s)
        {
            int result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                CheckPalindrome(s, i, i); //Check #Neetcode video for explaination of odd/even
                CheckPalindrome(s, i, i + 1); //Check #Neetcode video for explaination of odd/even
            }
            return result;
            void CheckPalindrome(string s, int l, int r)
            {
                while (l >= 0 && r < s.Length && s[l] == s[r])
                {
                    result++;
                    l--;
                    r++;
                }
            }
        }
    }
}
