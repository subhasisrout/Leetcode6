using System;
using System.Collections.Generic;

// Inspired from #Neetcode https://www.youtube.com/watch?v=evUFsOb_iLY

namespace Leetcode
{
    public class PushDominoesLC838
    {
        public string PushDominoes(string dominoes)
        {
            char[] arr = dominoes.ToCharArray();
            Queue<Tuple<char, int>> q = new Queue<Tuple<char, int>>();
            for (int i = 0; i < dominoes.Length; i++)
            {
                if (dominoes[i] != '.')
                    q.Enqueue(Tuple.Create(dominoes[i], i));
            }

            //Simulate moving from LEFT to RIGHT. Either ways is fine.
            while (q.Count > 0)
            {
                var currTuple = q.Dequeue();
                char curr = currTuple.Item1;
                int idx = currTuple.Item2;

                if (curr == 'L')
                {
                    if (idx > 0 && arr[idx - 1] == '.')
                    {
                        arr[idx - 1] = 'L';
                        q.Enqueue(Tuple.Create('L', idx - 1));
                    }
                }
                else
                {
                    if (idx + 1 < dominoes.Length && arr[idx + 1] == '.')
                    {
                        if (idx + 2 < dominoes.Length && arr[idx + 2] == 'L')
                        {
                            q.Dequeue(); //Dequeuing 'L' in advance in R.L scenario (cancelling each other)  
                        }
                        else
                        {
                            arr[idx + 1] = 'R';
                            q.Enqueue(Tuple.Create('R', idx + 1));
                        }
                    }
                }
            }

            return new String(arr);
        }
    }
}
