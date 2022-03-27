using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// O(1) explanation is from Nick White. Can be intuitively learned by traversing from right --> emulating backspace --> then compare the last char
// continue decrementing pointer -->

// O(N+M) using stack is much much easier and intuitive. From Kevin.
namespace Leetcode
{
    public class BackspaceStringCompareLC844
    {
        public bool BackspaceCompare(string S, string T)
        {
            int sPointer = S.Length - 1;
            int tPointer = T.Length - 1;

            int sSkips = 0;
            int tSkips = 0;

            while (sPointer >= 0 || tPointer >= 0)
            {
                while (sPointer >= 0)
                {
                    if (S[sPointer] == '#')
                    {
                        sPointer--;
                        sSkips++;
                    }
                    else if (sSkips > 0)
                    {
                        sPointer--;
                        sSkips--;
                    }
                    else
                    {
                        break;
                    }
                }

                while (tPointer >= 0)
                {
                    if (T[tPointer] == '#')
                    {
                        tPointer--;
                        tSkips++;
                    }
                    else if (tSkips > 0)
                    {
                        tPointer--;
                        tSkips--;
                    }
                    else
                    {
                        break;
                    }
                }

                if (sPointer >= 0 && tPointer >= 0 && (S[sPointer] != T[tPointer]))
                    return false;

                if ((sPointer >= 0) != (tPointer >= 0))  //if one of the string is traversed completely (from right) and one is not.
                    return false;

                sPointer--;
                tPointer--;

            }
            return true;
        }
        public bool BackspaceCompare2(string S, string T)
        {
            Stack<char> sStack = new Stack<char>();
            Stack<char> tStack = new Stack<char>();

            for (int i = 0; i < S.Length; i++)
            {
                if (S[i] != '#')
                {
                    sStack.Push(S[i]);
                }
                else
                {
                    if (sStack.Count > 0)
                        sStack.Pop();
                }
            }

            for (int i = 0; i < T.Length; i++)
            {
                if (T[i] != '#')
                {
                    tStack.Push(T[i]);
                }
                else
                {
                    if (tStack.Count > 0)
                        tStack.Pop();
                }
            }

            if (sStack.Count != tStack.Count)
                return false;

            while (sStack.Count > 0)
            {
                if (sStack.Pop() != tStack.Pop())
                    return false;
            }
            return true;
        }


    }
}
