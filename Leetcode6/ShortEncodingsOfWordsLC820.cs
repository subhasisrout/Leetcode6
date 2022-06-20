// 2 solutions
// 1- Generate all possible suffixes and remove from the set of "words"
// 2- #Trie based - add reverse words to the trie i.e. 'e'-'m'-'i'-'t', <me> will be skipped, 'l'-'l'-'e'-'b'
// Once the trie is built, there are multiple ways to find the height(len) of the leaf node. Do that adding + 1 for hash(#)

// Using Trie also - there are multiple ways - One updates the height of the node. One keeps a track of ChildrenCount (Leetcode solution)

// It seems most of the trie based solution can also be done by brute-forcing all combination of prefixes.

namespace Leetcode6
{
    public class ShortEncodingsOfWordsLC820
    {
        public int MinimumLengthEncoding2(string[] words)
        {
            int result = 0;
            HashSet<string> set = new HashSet<string>(words.ToList());
            //at this point, set will have ["time","me","bell"]
            //we will remove "ime","me", "e", "ell", "ll","l" from the set.
            //all of them will be a no-op, except for removal of "me". so set will have "time" and "bell"
            foreach (var word in words)
            {

                for (int i = 1; i < word.Length; i++)
                {
                    set.Remove(word.Substring(i));
                }
            }
            foreach (var setWord in set)
            {
                result += setWord.Length + 1;
            }
            return result;
        }
        public int MinimumLengthEncoding(string[] words)
        {
            TrieNode root = new TrieNode();
            int count = 0;
            foreach (var word in words)
            {
                TrieNode curr = root;
                for (int i = word.Length - 1; i >= 0; i--)
                {
                    char c = word[i];
                    if (curr.Children[c - 'a'] == null)
                        curr.Children[c - 'a'] = new TrieNode();
                    int prevHeight = curr.Height; //store the height before navigating down to children
                    curr = curr.Children[c - 'a'];
                    curr.Height = prevHeight + 1;
                }
            }

            BFS(root);
            return count;

            void BFS(TrieNode root)
            {
                Queue<TrieNode> queue = new Queue<TrieNode>();
                queue.Enqueue(root);
                while (queue.Count > 0)
                {
                    var node = queue.Dequeue();
                    int numOfChildren = 0;
                    foreach (var child in node.Children)
                    {
                        if (child == null) continue;
                        numOfChildren++;
                        queue.Enqueue(child);
                    }
                    if (numOfChildren == 0)
                        count += node.Height + 1;
                }

            }

            void DFS(TrieNode root)
            {
                if (root == null) return;
                if (IsTrieNodeLeaf(root))
                    count += root.Height + 1;
                foreach (var child in root.Children)
                {
                    DFS(child);
                }
            }
            bool IsTrieNodeLeaf(TrieNode node)
            {
                foreach (var child in node.Children)
                {
                    if (child != null)
                        return false;
                }
                return true;
            }
        }

        public int MinimumLengthEncoding3(string[] words)
        {
            TrieNode2 root = new TrieNode2();
            int count = 0;
            Dictionary<TrieNode2, int> map = new Dictionary<TrieNode2, int>();
            for (int k = 0; k < words.Length; k++)
            {
                string word = words[k];
                TrieNode2 curr = root;
                for (int i = word.Length - 1; i >= 0; i--)
                {
                    char c = word[i];
                    curr = curr.GetChildChar(c);
                }
                if (!map.ContainsKey(curr))
                    map.Add(curr, k); //used in line 117 to get the actual word for its length.
            }

            foreach (var kvp in map)
            {
                TrieNode2 node = kvp.Key;
                int idx = kvp.Value;
                if (node.Count == 0) //if no children i.e. leaf node
                    count += words[idx].Length + 1;
            }
            return count;
        }

        class TrieNode
        {
            public TrieNode[] Children;
            public int Height;

            public TrieNode()
            {
                this.Children = new TrieNode[26];
                Height = 0;
            }
        }

        class TrieNode2
        {
            public TrieNode2[] Children;
            public int Count; //stores number of children. For leaf nodes, this would be 0.

            public TrieNode2()
            {
                this.Children = new TrieNode2[26];
                Count = 0;
            }

            public TrieNode2 GetChildChar(char c) //for leaf nodes, Count would be 0.
            {
                if (this.Children[c - 'a'] == null)
                {
                    this.Children[c - 'a'] = new TrieNode2();
                    this.Count++;
                }
                return this.Children[c - 'a'];
            }

        }
    }
}
