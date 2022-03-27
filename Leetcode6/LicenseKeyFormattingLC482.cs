using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class LicenseKeyFormattingLC482
    {
        public string LicenseKeyFormatting(string S, int K)
        {
            int charOnlyLength = 0;
            for (int i = 0; i < S.Length; i++)
            {
                if (S[i] != '-')
                {
                    charOnlyLength++;
                }
            }
            StringBuilder output = new StringBuilder();
            int remainder = charOnlyLength % K;
            int charInsertCount = 0;
            if (remainder == 0)
            {
                for (int i = 0; i < S.Length; i++)
                {
                    if (S[i] != '-')
                    {
                        output.Append(Char.ToUpper(S[i]));
                        charInsertCount++;
                    }
                    else
                    {
                        continue;
                    }
                    if (charInsertCount != 0 && charInsertCount % K == 0)
                    {
                        output.Append("-");
                    }
                }
            }
            else
            {
                for (int i = 0; i < S.Length; i++)
                {
                    if (S[i] != '-')
                    {
                        output.Append(Char.ToUpper(S[i]));
                        charInsertCount++;
                    }
                    if (charInsertCount == remainder)
                    {
                        output.Append("-");
                    }
                    if (charInsertCount - remainder > 0 && (charInsertCount - remainder) % K == 0)
                    {
                        output.Append("-");
                    }
                }

            }
            if (output.Length >= 1)
                return output.ToString().Substring(0,output.Length-1);
            return output.ToString();
        
        }
    }
}
