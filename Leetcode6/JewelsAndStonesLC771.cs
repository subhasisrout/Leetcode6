using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class JewelsAndStonesLC771
    {
        public int NumJewelsInStones(string J, string S)
        {
            HashSet<char> jewels = new HashSet<char>();
            for (int i = 0; i < J.Length; i++)
            {
                jewels.Add(J[i]);
            }
            int count = 0;
            for (int i = 0; i < S.Length; i++)
            {
                if (jewels.Contains(S[i]))
                    count++;
            }
            return count;
        }
    }
}
