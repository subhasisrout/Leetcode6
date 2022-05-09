// Inspired from https://www.youtube.com/watch?v=8yhOJDXsvw4 and leetcode solution
// Intution iterate from back/end as its a "backspace" character
// With Backspace do +1, with char do -1 (assuming count > 0).

namespace Leetcode6
{
    public class BackspaceStringCompareLC844_O1Space
    {
        public bool BackspaceCompare(string s, string t)
        {
            int i = s.Length - 1;
            int j = t.Length - 1;
            int skipS = 0;
            int skipT = 0;

            while (i >= 0 || j >= 0)
            {

                while (i >= 0)
                {
                    if (s[i] == '#') { skipS++; i--; }
                    else if (skipS > 0) { skipS--; i--; }
                    else break;
                }

                while (j >= 0)
                {
                    if (t[j] == '#') { skipT++; j--; }
                    else if (skipT > 0) { skipT--; j--; }
                    else break;
                }

                if (i >= 0 && j >= 0 && s[i] != t[j]) //non equal characters
                    return false;

                //Eiether of the string is finished iterating
                if (i >= 0 && j < 0) return false;
                if (j >= 0 && i < 0) return false;


                i--;
                j--;
            }
            return true;

        }
    }
}
