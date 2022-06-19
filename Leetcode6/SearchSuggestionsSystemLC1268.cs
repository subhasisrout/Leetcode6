// Two solutions
// 2 pointer approach from #Neetcode
// Trie based solution from https://www.youtube.com/watch?v=PLNDfB0Vg9Y. Note - Used SortedDictionary instead of Dictionary for Trie
// to the lexicographically smaller 'key' (character).

// #List.GetRange Similar is #RemoveRange #Splice

namespace Leetcode6
{
    public class SearchSuggestionsSystemLC1268
    {
        public IList<IList<string>> SuggestedProducts2(string[] products, string searchWord)
        {
            IList<IList<string>> result = new List<IList<string>>();
            Array.Sort(products);
            int l = 0;
            int r = products.Length - 1;
            for (int i = 0; i < searchWord.Length; i++)
            {
                char c = searchWord[i];
                while (l <= r && (products[l].Length <= i || products[l][i] != c))
                    l++;
                while (l <= r && (products[r].Length <= i || products[r][i] != c))
                    r--;

                result.Add(new List<string>());
                var remain = r - l + 1;
                for (int k = 0; k < Math.Min(3, remain); k++)
                    result[result.Count - 1].Add(products[l + k]);
            }
            return result;
        }

        public IList<IList<string>> SuggestedProducts(string[] products, string searchWord)
        {
            IList<IList<string>> result = new List<IList<string>>();
            TrieNode root = BuildTrie(products);
            for (int i = 1; i <= searchWord.Length; i++)
            {
                string prefix = searchWord.Substring(0, i); //made the for-loop 1 based instead of 0 based for this reason
                IList<string> partialResult = GetMax3WordsStartingWith(root, prefix);
                result.Add(partialResult);
            }
            return result;
        }

        //Brain of the second approach
        private IList<string> GetMax3WordsStartingWith(TrieNode root, string prefix)
        {
            TrieNode curr = root;
            List<string> partialResult = new List<string>();
            for (int i = 0; i < prefix.Length; i++)
            {
                char c = prefix[i];
                if (!curr.Children.ContainsKey(c))
                    return partialResult;
                curr = curr.Children[c];
            }
            if (curr.IsWord)
                partialResult.Add(prefix);
            foreach (var child in curr.Children)
            {
                DFS(child, prefix);
                if (partialResult.Count >= 3)
                    return partialResult.GetRange(0, 3);
            }
            return partialResult;

            // The param 'prefix' can be misleading. Characters are added here so as to create the full word.
            void DFS(KeyValuePair<char, TrieNode> root, string prefix)
            {
                if (root.Value.IsWord)
                {
                    partialResult.Add(prefix + root.Key);
                    if (partialResult.Count >= 3)
                        return;
                }
                foreach (var child in root.Value.Children)
                {
                    DFS(child, prefix + root.Key);
                }


            }


        }

        private TrieNode BuildTrie(string[] products)
        {
            TrieNode root = new TrieNode();
            for (int i = 0; i < products.Length; i++)
            {
                string word = products[i];
                Insert(root, word);
            }
            return root;
        }

        private void Insert(TrieNode root, string word)
        {
            TrieNode curr = root;
            for (int i = 0; i < word.Length; i++)
            {
                char c = word[i];
                if (!curr.Children.ContainsKey(c))
                    curr.Children.Add(c, new TrieNode());
                curr = curr.Children[c];
            }
            curr.IsWord = true;
        }

        class TrieNode
        {
            public SortedDictionary<char, TrieNode> Children { get; }
            public bool IsWord { get; set; }
            public TrieNode()
            {
                this.Children = new SortedDictionary<char, TrieNode>();
            }
        }
    }
}
