using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// #RememberPattern
// Read the comments for better understanding
// Attaching picture.

namespace Leetcode.LRUCache
{
    public class LRUCacheLeetCode146
    {
        Node head = new Node();
        Node tail = new Node();
        Dictionary<int,Node> nodeMap;
        int cacheCapacity;

        public LRUCacheLeetCode146(int capacity)
        {
            this.cacheCapacity = capacity;
            nodeMap = new Dictionary<int, Node>(cacheCapacity);
            head.next = tail;
            tail.prev = head;
        }

        public void Print()//this method is only needed for validation or testing
        {
            Node temp = head.next;
            while (temp != tail)
            {
                Console.WriteLine(temp.val);
                temp = temp.next;
            }
        }

        public int Get(int key)
        {
            Node node;
            nodeMap.TryGetValue(key, out node);
            if (node != null)
            {
                RemoveFromDoublyLinkedList(node);
                AddToDoublyLinkedList(node);
                return node.val;
            }
            else
                return -1;

        }

        public void Put(int key, int value)
        {
            Node node;
            nodeMap.TryGetValue(key, out node);
            if (node != null)
            {
                node.val = value;
                RemoveFromDoublyLinkedList(node);//remove is changing pointers. So its O(1) operation
                AddToDoublyLinkedList(node);//since we always add to head, its O(1) operation.
            }
            else
            {
                if (nodeMap.Count == cacheCapacity)
                {
                    nodeMap.Remove(tail.prev.key);
                    RemoveFromDoublyLinkedList(tail.prev);
                }

                Node newNode = new Node();
                newNode.key = key;
                newNode.val = value;
                nodeMap.Add(key, newNode);
                AddToDoublyLinkedList(newNode);
                
            }



        }
        
        //We will add to the front of cache(head) and remove from tail
        //This implementation is such that "head" and "tail" are dummy nodes
        //which can never be null and do not contain any values.
        public void AddToDoublyLinkedList(Node node)
        {
            Node headNext = head.next;
            
            node.prev = head;
            node.next = headNext;

            head.next = node;
            headNext.prev = node;
        }

        public void RemoveFromDoublyLinkedList(Node node)
        {
            Node prev_node = node.prev;
            Node next_node = node.next;

            prev_node.next = next_node;
            next_node.prev = prev_node;

        }
    }

    public class Node
    {
        public int key { get; set; }
        public int val { get; set; }
        public Node next { get; set; }
        public Node prev { get; set; }

    }
}
