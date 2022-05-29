namespace Leetcode6
// #Array #Equality #SequenceEqual #SlidingWindow
// #Self Written Solution

{
    public class FindAllAnagramsInStringLC438
    {
        public IList<int> FindAnagrams(string s, string p)
        {
            List<int> result = new List<int>();
            int[] pArr = new int[26];
            for (int i = 0; i < p.Length; i++)
                pArr[p[i] - 'a'] += 1;

            int[] sArr = new int[26];

            for (int i = 0; i < s.Length - (p.Length - 1); i++)
            {
                if (i == 0)
                {
                    for (int k = 0; k < p.Length; k++)
                    {
                        char c = s[i + k];
                        sArr[c - 'a'] += 1; //#dotnetchar (char-'a' is an integer)
                    }
                }
                else
                { //sliding window logic. add 1 from end and remove 1 from beginning
                    char toBeRemoved = s[i - 1];
                    char toBeAdded = s[i + p.Length - 1];
                    sArr[toBeRemoved - 'a'] -= 1;
                    sArr[toBeAdded - 'a'] += 1;
                }

                //if sArr == pArr
                if (pArr.SequenceEqual(sArr))
                    result.Add(i);
            }
            return result;

        }
    }
}
