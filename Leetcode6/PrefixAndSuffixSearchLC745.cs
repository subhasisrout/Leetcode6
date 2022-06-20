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
        TrieNode root = null;
        public WordFilter(string[] words)
        {
            root = new TrieNode();

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                string newWord = word + "{" + word;

                //apple{apple, pple{apple, ple{apple, le{apple, e{apple
                for (int j = 0; j < word.Length; j++) //j will be from 0 to 4.
                {
                    TrieNode curr = root;
                    for (int k = j; k < newWord.Length; k++)// 0 to 10, 1 to 10, 2 to 10....so on
                    {
                        char c = newWord[k];
                        if (curr.Children[c - 'a'] == null)
                            curr.Children[c - 'a'] = new TrieNode();
                        curr = curr.Children[c - 'a'];
                        curr.MaxIndex = i;
                    }
                }
            }

        }

        public int F(string prefix, string suffix)
        {
            string searchWord = suffix + "{" + prefix;
            TrieNode curr = root;
            for (int i = 0; i < searchWord.Length; i++)
            {
                char c = searchWord[i];
                if (curr.Children[c - 'a'] == null)
                    return -1;
                curr = curr.Children[c - 'a'];
            }
            return curr.MaxIndex;
        }

        class TrieNode
        {
            public int MaxIndex;
            public TrieNode[] Children;

            public TrieNode()
            {
                this.Children = new TrieNode[27];
            }
        }
    }



}
