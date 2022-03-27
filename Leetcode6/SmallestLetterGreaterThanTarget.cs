using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Easy but #tricky because of wraparound.
// Look at the #CleanLessLines method.
namespace Leetcode
{
    public class SmallestLetterGreaterThanTarget
    {
        public char NextGreatestLetter(char[] letters, char target)
        {
            int targetNum = (int)target;
            //return BinSearch(letters, targetNum, 0, letters.Length - 1);
            return BinSearchCleanAndLessLines(letters, targetNum, 0, letters.Length - 1);

        }
        private char BinSearch(char[] letters, int targetNum, int start, int end)
        {
            int mid = start + (end - start) / 2;
            while (start <= end)
            {
                mid = start + (end - start) / 2;
                if ((int)letters[mid] == targetNum)
                {

                    if (mid + 1 < letters.Length && letters[mid + 1] != targetNum) return letters[mid + 1];
                    else if (mid + 1 < letters.Length && letters[mid + 1] == targetNum) start = mid + 1;
                    else return letters[(mid + 1) % letters.Length];
                }
                else if ((int)letters[mid] > targetNum)
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }
            if ((int)letters[mid] > targetNum) return letters[mid];
            return letters[(mid + 1) % letters.Length];
        }

        // Below is cleaner/ less lines
        private char BinSearchCleanAndLessLines(char[] letters, int targetNum, int start, int end)
        {
            while (start <= end)
            {
                int mid = start + (end - start) / 2;
                if (letters[mid] <= targetNum)
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }
            return letters[start % letters.Length];
        }
    }
}
