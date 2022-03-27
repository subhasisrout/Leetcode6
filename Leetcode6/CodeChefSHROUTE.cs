using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class CodeChefSHROUTE
    {
        int useCases = 5;
        Dictionary<int, int> map = new Dictionary<int, int>();

        private void temp()
        {
            for (int z = 0; z < useCases; z++)
            {
                var ignore = Console.ReadLine();
                string pathString = Console.ReadLine();
                int[] path = pathString.Split(' ').Select(int.Parse).ToArray();

                string inputString = Console.ReadLine();
                int[] input = inputString.Split(' ').Select(int.Parse).ToArray();

                StringBuilder result = new StringBuilder();
                for (long i = 0; i < input.Length; i++)
                {
                    if (!map.ContainsKey(input[i]))
                    {
                        var time = GetTime(path, input[i]);
                        map.Add(input[i], time);
                    }
                    result.Append(map[input[i]].ToString() + " ");
                }

                Console.WriteLine(result.ToString().Trim());
            }
        }
        public int GetTime(int[] A, int targetDestination) //targetDestination is 0-based index
        {
            if (targetDestination == 0) return 0;
            int result = Int32.MaxValue;

            //leftPass
            int leftResult = 0;
            int currPos = targetDestination;
            bool desiredTrainFound = false;
            while (currPos >= 0)
            {
                if (A[currPos] == 1)
                {
                    desiredTrainFound = true;
                    break;
                }
                currPos--;
                leftResult++;
            }
            if (!desiredTrainFound)
                leftResult = Int32.MaxValue;

            //rightPass
            int rightResult = 0;
            currPos = targetDestination;
            desiredTrainFound = false;
            while (currPos <= A.Length - 1)
            {
                if (A[currPos] == 2)
                {
                    desiredTrainFound = true;
                    break;
                }
                currPos++;
                rightResult++;
            }
            if (!desiredTrainFound)
                rightResult = Int32.MaxValue;


            result = Math.Min(leftResult, rightResult);
            result = (result == Int32.MaxValue) ? -1 : result;

            return leftResult;
        }
    }
}
