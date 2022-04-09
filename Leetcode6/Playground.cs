namespace Leetcode
{
    public class Playground
    {
        public void Play()
        {
            List<KeyValuePair<char, int>> list = new List<KeyValuePair<char, int>>();
            list.Add(new KeyValuePair<char, int>('a', 1));
        }

        TrieNode trieNode = new TrieNode();

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
}
