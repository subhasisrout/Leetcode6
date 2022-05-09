// #UnionFind #Union #Find #Graph (UnionFind datastructure allows 2 operations - Union and Find
// #It basically is used to group a bunch of elements (using some condition) and each group has a parent or representative
// Used #Zip function
// Inspired from https://www.youtube.com/watch?v=1Ga44vFth8k

namespace Leetcode6
{
    public class SmallestStringWithSwapsLC1202
    {
        public string SmallestStringWithSwaps(string s, IList<IList<int>> pairs)
        {
            int[] p = new int[s.Length]; //each char is its parent (index is used)
            for (int k = 0; k < s.Length; k++)
                p[k] = k;

            int Find(int i)
            {
                if (i != p[i])
                    p[i] = Find(p[i]);
                return p[i];
            }

            void Union(int x, int y)
            {
                int px = Find(x);
                int py = Find(y);
                if (px != py)
                {
                    p[py] = px;
                }

            }

            foreach (var pair in pairs)
                Union(pair[0], pair[1]);//0-->0,3 and 1-->1,2. p now is [0,1,1,0]

            Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
            for (int i = 0; i < p.Length; i++)
            {
                if (!map.ContainsKey(Find(p[i])))
                    map.Add(Find(p[i]), new List<int>());

                map[Find(p[i])].Add(i); //key is the PARENT/REPRESENTATIVE
            }

            char[] result = new char[s.Length];
            foreach (var kv in map)
            {
                var idxList = kv.Value;
                List<char> charList = new List<char>();
                foreach (var item in idxList)
                    charList.Add(s[item]);
                charList.Sort();

                var zipped = idxList.Zip(charList); //Creates a Tuple of 2 List #Zip
                foreach (var item in zipped)
                    result[item.First] = item.Second;
            }

            return new string(result.ToArray());

        }
    }
}
