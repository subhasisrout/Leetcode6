// #Trie

namespace Leetcode6
{
    // Inspired from #Neetcode https://www.youtube.com/watch?v=BTf05gs_8iU
    public class WordDictionaryLC211
    {
        TrieNode root;
        public WordDictionaryLC211()
        {
            root = new TrieNode();
        }

        public void AddWord(string word)
        {
            TrieNode curr = root;
            for (int i = 0; i < word.Length; i++)
            {
                if (!curr.Children.ContainsKey(word[i]))
                {
                    curr.Children.Add(word[i], new TrieNode());
                }
                curr = curr.Children[word[i]];
            }
            curr.IsEnd = true;
        }

        public bool Search(string word)
        {
            bool DFS(int j, TrieNode trieNode) //DFS with recursion value and iteration
            {
                var curr = trieNode;

                for (int i = j; i < word.Length; i++)
                {
                    char ch = word[i];
                    if (ch == '.') //recursion track
                    {
                        var children = curr.Children;
                        foreach (var child in children) //backtracking
                        {
                            if (DFS(i + 1, child.Value)) //recursion returing value. . will match anyone, so check i+1.
                                return true;
                        }
                        return false;
                    }
                    else //iteration track
                    {
                        if (!curr.Children.ContainsKey(ch))
                            return false;
                        curr = curr.Children[ch];
                    }
                }
                return curr.IsEnd; //VALUE returned here.
            }
            return DFS(0, root);
        }

        class TrieNode
        {
            public TrieNode()
            {
                this.Children = new Dictionary<char, TrieNode>();
            }
            public Dictionary<char, TrieNode> Children { get; private set; }
            public bool IsEnd { get; set; }
        }
    }

    /**
     * Your WordDictionary object will be instantiated and called as such:
     * WordDictionary obj = new WordDictionary();
     * obj.AddWord(word);
     * bool param_2 = obj.Search(word);
     */
}
