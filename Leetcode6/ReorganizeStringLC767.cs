using System.Text;

// #PriorityQueue #Heap #.NET6
// Inspired from #Kevin Naughton Jr

namespace Leetcode
{
    public class ReorganizeStringLC767
    {
        public string ReorganizeString(string s)
        {
            Dictionary<char, int> charFreq = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (charFreq.ContainsKey(s[i]))
                    charFreq[s[i]] = charFreq[s[i]] + 1;
                else
                    charFreq.Add(s[i], 1);
            }

            PriorityQueue<char, int> queue = new PriorityQueue<char, int>(new PriorityComparer()); //Custom comparer for MAXHEAP. Default is MINHEAP.
            foreach (var item in charFreq)
                queue.Enqueue(item.Key, item.Value);

            StringBuilder sb = new StringBuilder();
            while (queue.Count > 1) //so long you have 2 distinct chars
            {
                queue.TryDequeue(out char curr, out int currCount);
                queue.TryDequeue(out char next, out int nextCount);
                sb.Append(curr);
                sb.Append(next);
                if (currCount - 1 != 0)
                    queue.Enqueue(curr, currCount - 1);
                if (nextCount - 1 != 0)
                    queue.Enqueue(next, nextCount - 1);
            }
            if (queue.Count == 1)
            {
                queue.TryDequeue(out char last, out int lastCount);
                if (lastCount > 1)
                    return "";
                sb.Append(last);
            }
            return sb.ToString();
        }
        public class PriorityComparer : IComparer<int>
        {
            public int Compare(int p1, int p2)
            {
                return p2.CompareTo(p1);
            }
        }
    }

}
