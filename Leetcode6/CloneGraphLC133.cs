namespace Leetcode3
{
    // #Graph . Maintain a Dictionary of <old,new>. Thats the logic.
    public class CloneGraphLC133
    {

        // #DFS by #Neetcode. Very intuitively explained. Short and Sweet.
        public Node CloneGraph2(Node node)
        {
            if (node == null) return null;
            Dictionary<Node, Node> map = new Dictionary<Node, Node>();

            Node DFS(Node node)
            {
                if (map.ContainsKey(node))
                    return map[node];
                Node copy = new Node(node.val);
                map.Add(node, copy);
                foreach (var nei in node.neighbors)
                {
                    copy.neighbors.Add(DFS(nei));
                }
                return copy;
            }
            return DFS(node);
        }

        // #BFS
        public Node CloneGraph(Node node)
        {
            if (node == null)
                return null;
            Node nodeCopy = new Node();
            nodeCopy.val = node.val;
            Dictionary<Node, Node> map = new Dictionary<Node, Node>();
            map.Add(node, nodeCopy);

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(node);

            while (queue.Count != 0)
            {
                var queueItem = queue.Dequeue();
                var neighbours = queueItem.neighbors;
                foreach (var neighbor in neighbours)
                {
                    if (!map.ContainsKey(neighbor))
                    {
                        Node tmp = new Node();
                        tmp.val = neighbor.val;
                        map.Add(neighbor, tmp);
                        queue.Enqueue(neighbor);
                    }
                    map[queueItem].neighbors.Add(map[neighbor]);
                }
            }
            return map[node];
        }


    }


    public class Node
    {
        public int val;
        public IList<Node> neighbors;

        public Node()
        {
            val = 0;
            neighbors = new List<Node>();
        }

        public Node(int _val)
        {
            val = _val;
            neighbors = new List<Node>();
        }

        public Node(int _val, List<Node> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }
}

