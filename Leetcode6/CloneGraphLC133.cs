using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode3
{
    public class CloneGraphLC133
    {
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
        public List<Node> neighbors;
    }
}

