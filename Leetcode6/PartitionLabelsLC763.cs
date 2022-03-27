using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class PartitionLabelsLC763
    {
        public IList<int> PartitionLabels(string S)
        {
            List<int> result = new List<int>();
            if (string.IsNullOrEmpty(S))
                return result;
            int[] lastIndices = new int[26];
            char[] arrChar = S.ToCharArray();
            for (int i = 0; i < arrChar.Length; i++)
            {
                lastIndices[arrChar[i] - 'a'] = i;
            }

            int start = 0;           
            while (start < S.Length)
            {
                int end = lastIndices[arrChar[start] - 'a'];
                int intermediateLengthCounter = start;
                
                while (intermediateLengthCounter != end)
                {
                    end = Math.Max(lastIndices[arrChar[intermediateLengthCounter] - 'a'], end);
                    intermediateLengthCounter++;
                }
                result.Add(end - start + 1);
                start = end + 1;
            }
            
            return result;
        }
    }
}
