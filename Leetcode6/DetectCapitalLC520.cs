using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class DetectCapitalLC520
    {
        public bool DetectCapitalUse(string word)
        {
            if (word.Length == 1) return true;
            if (word[0] >= 'A' && word[0] <= 'Z')
            {
                if (word[1] >= 'A' && word[1] <= 'Z')//USA
                {
                    for (int i = 2; i < word.Length; i++)
                    {
                        if (!(word[i] >= 'A' && word[i] <= 'Z'))
                            return false;
                    }
                    return true;
                }
                else//Google
                {
                    for (int i = 2; i < word.Length; i++)
                    {
                        if (!(word[i] >= 'a' && word[i] <= 'z'))
                            return false;
                    }
                    return true;

                }
            }
            else //leetcode
            {
                for (int i = 1; i < word.Length; i++)
                {
                    if (!(word[i] >= 'a' && word[i] <= 'z'))
                        return false;
                }
                return true;
            }

        }
    }
}
