using System.Text;

// #DidItMySelf. Solution different from AE. Need to see AE video explanation.

namespace Leetcode
{
    public class ReverseWordsInStringAE
    {
        //a    test
        //    j   i
        public string ReverseWordsInString(string str)
        {
            StringBuilder result = new StringBuilder();
            int i = str.Length - 1;
            int j = str.Length - 1;
            while (j >= 0)
            {
                while (j >= 0 && str[j] != ' ') //iterate through letters
                {
                    j--;
                }
                result.Append(ConstructWord(str, i, j+1)); // both inclusive
                int spaceCounter = 0;
                while (j >= 0 && str[j] == ' ')//iterate through spaces
                {
                    j--;
                    spaceCounter++;
                }
                result.Append(' ', spaceCounter);
                i = j;
            }
            return result.ToString();
        }

        private string ConstructWord(string str, int end, int start) //both inclusive "abcde" (1,3) => bcd
        {
            return str.Substring(start, end - start + 1);
        }
    }
}
