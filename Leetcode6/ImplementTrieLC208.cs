// Tries are tree data structures
// Tries are also called Prefix trees, because they are used to find prefixes (startsWith)
// But Tries can also be used to find Suffixes. The implementation will differ then. AlgoExpert has a question on Suffix trees
// The children can be represented as arrays or Hashtable. This code uses Array.
// For a given node, the possible number of children is the charset of the input. Assumming all lowercase letters only, each node can have 26 children.
// Referred - https://www.youtube.com/watch?v=giiaIofn31A (Michael Muinos) 
// Leetcode 208

// Added ImplementTrieWithMapLC208 where children are maintained using HashMap. I like this HashMap approach better
// Kind of sunken in the mind. Also its more readable and generic. Neetcode did using HashMap.
// Michael Muinos used arrays.

namespace Leetcode
{
    public class Trie
    {
        private TrieNode root;

        public Trie()
        {
            root = new TrieNode('\0');
        }

        public void Insert(string word)
        {
            TrieNode currTrieNode = root;
            for (int i = 0; i < word.Length; i++)
            {
                char currInputChar = word[i];
                if (currTrieNode.Children[currInputChar - 'a'] == null) currTrieNode.Children[currInputChar - 'a'] = new TrieNode(currInputChar);
                currTrieNode = currTrieNode.Children[currInputChar - 'a'];
            }
            currTrieNode.IsWord = true;
        }
        public bool Search(string word)
        {
            TrieNode node = GetNode(word);
            return node != null && node.IsWord == true;
        }

        public bool StartsWith(string prefix)
        {
            return GetNode(prefix) != null;
        }

        //Helper method just to return the node for a given string
        //can return NULL, Node with IsWord (if its end), Node without IsWord (if its in the middle)
        private TrieNode GetNode(string word)
        {
            TrieNode currTrieNode = root;
            for (int i = 0; i < word.Length; i++)
            {
                char currInputChar = word[i];
                if (currTrieNode.Children[currInputChar - 'a'] == null)
                    return null;
                currTrieNode = currTrieNode.Children[currInputChar - 'a'];
            }
            return currTrieNode;
        }

    }
    public class TrieNode
    {
        public char Char { get; set; }
        public bool IsWord { get; set; }
        public TrieNode[] Children { get; set; }

        public TrieNode(char c)
        {
            this.Char = c;
            this.IsWord = false;
            this.Children = new TrieNode[26]; //for a-z. We will be only storing lowercase letters
        }
    }
}
