using System.Collections.Generic;

// The children can be represented as arrays or Hashtable. This code uses HashTable.

// I like this HashMap approach better
// Kind of sunken in the mind. Also its more readable and generic. Neetcode did using HashMap.
// Michael Muinos used arrays.

namespace Leetcode
{
    public class ImplementTrieWithMapLC208
    {
        public class Trie
        {
            private TrieNode root;

            /** Initialize your data structure here. */
            public Trie()
            {
                root = new TrieNode();
            }

            /** Inserts a word into the trie. */
            public void Insert(string word)
            {
                var curr = root;
                for (int i = 0; i < word.Length; i++)
                {
                    if (!curr.Children.ContainsKey(word[i]))
                        curr.Children.Add(word[i], new TrieNode());
                    curr = curr.Children[word[i]];
                }
                curr.IsEndOfWord = true;
            }

            /** Returns if the word is in the trie. */
            public bool Search(string word)
            {
                var curr = root;
                for (int i = 0; i < word.Length; i++)
                {
                    if (!curr.Children.ContainsKey(word[i]))
                        return false;
                    else
                        curr = curr.Children[word[i]];
                }
                return curr.IsEndOfWord;
            }

            /** Returns if there is any word in the trie that starts with the given prefix. */
            public bool StartsWith(string prefix)
            {
                var curr = root;
                for (int i = 0; i < prefix.Length; i++)
                {
                    if (!curr.Children.ContainsKey(prefix[i]))
                        return false;
                    else
                        curr = curr.Children[prefix[i]];
                }
                return true;
            }
        }

        public class TrieNode
        {
            public TrieNode()
            {
                this.Children = new Dictionary<char, TrieNode>();
            }
            public Dictionary<char,TrieNode> Children { get; set; }
            public bool IsEndOfWord { get; set; }
        }
    }
}
