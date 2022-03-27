using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class BoatsToSavePeopleLC881
    {
        public int NumRescueBoats(int[] people, int limit)
        {
            Array.Sort(people);
            int numBoats = 0;
            int i = 0;
            int j = people.Length - 1;

            while (i <= j)
            {
                if (i==j)
                {
                    numBoats++;
                    break;
                }
                if (people[i] + people[j] <= limit)
                    i++;
                j--;
                numBoats++;
            }
            return numBoats;
        }
    }
}
