//  #Trie #Hard #Google #Clever
// #StringReverse
// 2 Approches - WordFilter2 uses HashMap and generates all possible combinations of prefix and suffix separated by #

// PrefixAndSuffixSearchLC745
namespace Leetcode6
{
    public class WordFilter2
    {
        Dictionary<string, int> map = new Dictionary<string, int>();
        public WordFilter2(string[] words)
        {
            for (int i = words.Length - 1; i >= 0; i--)
            {
                for (int u = 0; u <= words[i].Length; u++)
                {
                    for (int v = 0; v <= words[i].Length; v++)
                    {
                        string key = words[i].Substring(0, u) + "#" + words[i].Substring(v);
                        if (!map.ContainsKey(key))
                            map.Add(key, i);
                    }
                }
            }
        }

        public int F(string prefix, string suffix)
        {
            if (map.ContainsKey(prefix + "#" + suffix))
                return map[prefix + "#" + suffix];
            return -1;
        }
    }
    public class WordFilter
    {
        Trie prefixTrie = null;
        Trie suffixTrie = null;

        public WordFilter(string[] words)
        {
            prefixTrie = new Trie();
            suffixTrie = new Trie();

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                char[] chArr = word.ToCharArray();
                Array.Reverse(chArr);
                string reversedWord = new string(chArr);

                prefixTrie.Insert(word, i);
                suffixTrie.Insert(reversedWord, i);
            }

        }

        public int F(string prefix, string suffix)
        {
            var prefixIdx = prefixTrie.StartsWith(prefix);

            char[] chArr = suffix.ToCharArray();
            Array.Reverse(chArr);
            string reversedSuffix = new string(chArr);

            var suffixIdx = suffixTrie.StartsWith(reversedSuffix);

            int i = prefixIdx.Count - 1;
            int j = suffixIdx.Count - 1;
            while (i >= 0 && j >= 0)
            {
                if (prefixIdx[i] == suffixIdx[j])
                    return prefixIdx[i];
                else if (prefixIdx[i] > suffixIdx[j])
                    i--;
                else
                    j--;
            }
            return -1;
        }
        class Trie
        {
            private Dictionary<char, Trie> Children { get; }
            private List<int> Indices { get; }

            public Trie()
            {
                this.Children = new Dictionary<char, Trie>();
                this.Indices = new List<int>();
            }

            public void Insert(string word, int index)
            {
                Trie curr = this;
                for (int i = 0; i < word.Length; i++)
                {
                    if (!curr.Children.ContainsKey(word[i]))
                        curr.Children.Add(word[i], new Trie());
                    curr = curr.Children[word[i]];
                    curr.Indices.Add(i);
                }
            }

            public List<int> StartsWith(string prefix)
            {
                Trie curr = this;
                for (int i = 0; i < prefix.Length; i++)
                {
                    if (!curr.Children.ContainsKey(prefix[i]))
                        return new List<int>();
                    else
                        curr = curr.Children[prefix[i]];
                }
                return curr.Indices;
            }
        }
    }



}
