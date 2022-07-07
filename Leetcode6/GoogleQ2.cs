namespace Leetcode6
{
    public class GoogleQ2
    {
        TrieNode root = new TrieNode();
        HashSet<TrieNode> seen = new HashSet<TrieNode>();
        public void CreateTrieFromListOfFiles(IList<string> files)
        {
            foreach (var file in files)
            {
                AddFilePathToTrie(file);
            }

            DFSPrint(root, 0);
        }

        private void DFSPrint(TrieNode root, int level)
        {
            if (root != null && !seen.Contains(root))
            {
                foreach (var item in root.Children)
                {
                    Console.WriteLine(item.Key.PadLeft(item.Key.Length + (level * 4)));
                    seen.Add(root);
                    DFSPrint(item.Value, level + 1);

                }
            }
        }

        private void AddFilePathToTrie(string file)
        {
            string[] folders = file.Split('/');
            var curr = root;
            for (int i = 0; i < folders.Length; i++)
            {
                if (!curr.Children.ContainsKey(folders[i]))
                    curr.Children.Add(folders[i], new TrieNode());
                curr = curr.Children[folders[i]];
            }
            curr.IsEndOfPath = true;
        }



        class TrieNode
        {
            public TrieNode()
            {
                this.Children = new Dictionary<string, TrieNode>();
            }
            public Dictionary<string, TrieNode> Children { get; set; }
            public bool IsEndOfPath { get; set; }
        }
    }
}
