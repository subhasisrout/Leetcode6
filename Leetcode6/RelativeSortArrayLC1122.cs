using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class RelativeSortArrayLC1122
    {
        public int[] RelativeSortArray(int[] arr1, int[] arr2)
        {
            if (arr1 == null || arr1.Length == 0)
                return arr1;


            if (arr2 == null || arr2.Length == 0)
            {
                Array.Sort(arr1);
                return arr1;
            }

            int[] result = new int[arr1.Length];
            int[] buckets = new int[arr2.Length];
            List<int> notFoundNums = new List<int>();
            for (int i = 0; i < arr1.Length; i++)
            {
                bool numFound = false;
                for (int j = 0; j < arr2.Length; j++)
                {
                    if (arr1[i] == arr2[j])
                    {
                        numFound = true;
                        buckets[j]++;
                        break;
                    }
                }
                if (numFound == false)
                    notFoundNums.Add(arr1[i]);
            }

            int k = 0;
            for (int i = 0; i < arr2.Length; i++)
            {
                int value = arr2[i];
                int count = buckets[i];

                while (count > 0)
                {
                    arr1[k] = value;
                    k++;
                    count--;
                }
            }

            if (notFoundNums.Count > 0)
            {
                notFoundNums.Sort();
                foreach (var item in notFoundNums)
                {
                    arr1[k] = item;
                    k++;
                }
            }

            return arr1;
        }
    }
}
