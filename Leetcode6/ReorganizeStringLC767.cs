using PriorityQueueFromCodeProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode
{
    public class ReorganizeStringLC767
    {
        public string ReorganizeString(string S)
        {
            char[] arr = S.ToCharArray();
            Dictionary<char, int> counts = new Dictionary<char, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (!counts.ContainsKey(arr[i]))
                    counts.Add(arr[i], 1);
                else
                    counts[arr[i]] = counts[arr[i]] + 1;
            }
            CountsComparer countsComparer = new CountsComparer(counts);
            List<KeyValuePair<char,char>> data = new List<KeyValuePair<char, char>>();
            foreach (var item in counts)
            {
                data.Add(new KeyValuePair<char, char>(item.Key, item.Key));
            }
            PriorityQueueFromCodeProject.PriorityQueue<char, char> maxHeap = new PriorityQueueFromCodeProject.PriorityQueue<char, char>(data,countsComparer);

            StringBuilder result = new StringBuilder();
            while (maxHeap.Count > 1)
            {
                char current = maxHeap.DequeueValue();
                char next = maxHeap.DequeueValue();
                result.Append(current);
                result.Append(next);

                counts[current] = counts[current] - 1;
                counts[next] = counts[next] - 1;

                if (counts[current] > 0)
                    maxHeap.Enqueue(current, current);

                if (counts[next] > 0)
                    maxHeap.Enqueue(next, next);
            }

            if (!maxHeap.IsEmpty)
            {
                char last = maxHeap.DequeueValue();
                if (counts[last] > 1)
                    return "";
                result.Append(last);
            }
            
            return result.ToString();
        }

        public class CountsComparer : IComparer<char>
        {
            Dictionary<char, int> counts;
            public CountsComparer(Dictionary<char, int> counts)
            {
                this.counts = counts;
            }
            public int Compare(char x, char y)
            {
                return counts[y] - counts[x];
            }
        }

    }
   
}
