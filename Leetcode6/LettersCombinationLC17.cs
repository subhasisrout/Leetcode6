using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    // Looks like this is a standard backtracking problem.
    // This is like a cartesian product
    // This video is helpful (https://www.youtube.com/watch?v=h6FmiyYDjmk). Try to run each iteration to intuitively understand.

    // #AlgoExpert #AE More intuitive solution (without Add/Remove) in AlgoExpert.
    // Update 19-Dec-2021. 
    // #BackTrack - No index is passed, #StringBuilder length is used.
    public class LettersCombinationLC17
    {
        public IList<string> LetterCombinations(string digits)
        {
            List<string> result = new List<string>();

            if (digits == null || digits.Length == 0)
                return result;

            Dictionary<Char, Char[]> characterMap = new Dictionary<char, char[]>();

            characterMap.Add('0', new char[] { });
            characterMap.Add('1', new char[] { });
            characterMap.Add('2', new char[] { 'a', 'b', 'c' });
            characterMap.Add('3', new char[] { 'd', 'e', 'f' });
            characterMap.Add('4', new char[] { 'g', 'h', 'i' });
            characterMap.Add('5', new char[] { 'j', 'k', 'l' });
            characterMap.Add('6', new char[] { 'm', 'n', 'o' });
            characterMap.Add('7', new char[] { 'p', 'q', 'r', 's' });
            characterMap.Add('8', new char[] { 't', 'u', 'v' });
            characterMap.Add('9', new char[] { 'w', 'x', 'y', 'z' });

            CombinationGeneratorUtil(digits, characterMap, new StringBuilder(), result);

            return result;
        }

        private void CombinationGeneratorUtil(string digits, Dictionary<char, char[]> characterMap, StringBuilder sb, List<string> result)
        {
            if (digits.Length == sb.Length)
            {
                result.Add(sb.ToString());
                return;
            }

            char[] charArr = characterMap[digits[sb.Length]];
            for (int i = 0; i < charArr.Length; i++)
            {
                sb.Append(charArr[i]);
                CombinationGeneratorUtil(digits, characterMap, sb, result);
                sb.Remove(sb.Length - 1, 1);
            }
        }

        //Below solution is from AlgoExpert
        public List<string> PhoneNumberMnemonics(string phoneNumber)
        {
            List<string> result = new List<string>();
            Dictionary<char, char[]> map = new Dictionary<char, char[]>();
            map.Add('1', new char[] { '1' });
            map.Add('0', new char[] { '0' });
            map.Add('2', new char[] { 'a', 'b', 'c' });
            map.Add('3', new char[] { 'd', 'e', 'f' });
            map.Add('4', new char[] { 'g', 'h', 'i' });
            map.Add('5', new char[] { 'j', 'k', 'l' });
            map.Add('6', new char[] { 'm', 'n', 'o' });
            map.Add('7', new char[] { 'p', 'q', 'r', 's' });
            map.Add('8', new char[] { 't', 'u', 'v' });
            map.Add('9', new char[] { 'w', 'x', 'y', 'z' });

            char[] current = new char[phoneNumber.Length];
            DFS(phoneNumber, current, 0, map, result);
            return result;
        }

        private void DFS(string phoneNumber, char[] current, int currentIndex, Dictionary<char, char[]> map, List<string> result)
        {
            if (currentIndex == phoneNumber.Length)
            {
                result.Add(new string(current));
                return;
            }
            else
            {
                char[] letters = map[phoneNumber[currentIndex]];
                for (int j = 0; j < letters.Length; j++)
                {
                    current[currentIndex] = letters[j];
                    DFS(phoneNumber, current, currentIndex + 1, map, result);
                }
            }
        }

    }
}
