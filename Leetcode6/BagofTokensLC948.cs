using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class BagofTokensLC948
    {
        public int BagOfTokensScore(int[] tokens, int P)
        {
            Array.Sort(tokens);
            int toSell = 0;
            int toBuy = tokens.Length - 1;
            int output = 0;
            int maxOutput = 0; //forgot to use this concept in the first attempt. only used one variable output.

            while (toSell <= toBuy)
            {
                if (tokens[toSell] <= P)
                {
                    P = P - tokens[toSell];
                    toSell++;
                    output++;
                    maxOutput = Math.Max(maxOutput, output); //forgot to use this concept in the first attempt
                }
                else if (output > 0)
                {
                    P = P + tokens[toBuy];
                    output--;
                    toBuy--;
                }
                else
                {
                    return maxOutput;
                }
            }

            return maxOutput;
        }
    }
}
