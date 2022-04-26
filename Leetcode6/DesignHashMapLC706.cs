// #LinkedList #DummyNode #SentinelNode #GetHashCode

namespace Leetcode6
{
    public class DesignHashMapLC706
    {
        public class MyHashMap
        {

            LLNode[] map = null;
            public MyHashMap()
            {
                map = new LLNode[1000]; //Total number of keys is 10^6. LoadFactor = 1000000/1000
            }

            public void Put(int key, int value)
            {
                int hash = key.GetHashCode() % 1000; //Getting hashKey for the HashTable
                if (map[hash] == null)
                {
                    map[hash] = new LLNode(key, value); //chaining
                    return;
                }

                var curr = map[hash];
                while (curr != null)
                {
                    if (curr.Key == key)
                    {
                        curr.Val = value;
                        return;
                    }
                    else
                    {
                        if (curr.Next == null) //if its last node, break out. Addition of node is done after loop ends.
                            break;
                        else
                            curr = curr.Next;
                    }
                }
                curr.Next = new LLNode(key, value);
            }

            public int Get(int key)
            {
                int hash = key.GetHashCode() % 1000;
                if (map[hash] == null)
                {
                    return -1;
                }

                var curr = map[hash];
                while (curr != null)
                {
                    if (curr.Key == key)
                    {
                        return curr.Val;
                    }
                    else
                    {
                        curr = curr.Next;
                    }
                }
                return -1;
            }

            public void Remove(int key)
            {
                int hash = key.GetHashCode() % 1000;
                if (map[hash] == null)
                {
                    return;
                }

                var current = map[hash];
                var dummy = new LLNode(-1, -1);
                dummy.Next = current;

                var curr = dummy; //curr is nothing for iterator
                while (curr != null && curr.Next != null)
                {
                    if (curr.Next.Key == key) //Note we are starting curr (iter) from 1 behind and checking curr.Next.Key
                    {
                        curr.Next = curr.Next.Next;
                        break;
                    }
                    curr = curr.Next;
                }
                map[hash] = dummy.Next;
            }
        }

        public class LLNode
        {
            public int Key { get; set; }
            public int Val { get; set; }
            public LLNode Next { get; set; }

            public LLNode(int key, int val)
            {
                this.Key = key;
                this.Val = val;
                this.Next = null;
            }

        }
    }
}
