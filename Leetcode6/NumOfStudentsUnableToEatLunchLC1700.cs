using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class NumOfStudentsUnableToEatLunchLC1700
    {
        public int CountStudents(int[] students, int[] sandwiches)
        {
            LinkedList<int> studentList = new LinkedList<int>();
            for (int i = 0; i < students.Length; i++)
            {
                studentList.AddLast(students[i]);
            }

            int swIdx = 0;
            int firstStudentPreference = -1;
            int shuffleCount = 0;
            while (swIdx < sandwiches.Length)
            {
                firstStudentPreference = studentList.First.Value;
                if (firstStudentPreference == sandwiches[swIdx])
                {
                    swIdx++;
                    studentList.RemoveFirst();
                    shuffleCount = 0;
                }
                else
                {
                    studentList.RemoveFirst();
                    studentList.AddLast(firstStudentPreference);
                    shuffleCount++;
                }
                if (shuffleCount == studentList.Count)
                    break;
            }
            return sandwiches.Length - swIdx;
        }
    }
}
