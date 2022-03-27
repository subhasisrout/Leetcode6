// Use the following sequence
// 1. RemoveNode (update all node bindings). Take care of Head/Tail.
// 2. RemoveNodeWithValues uses RemoveNode. Take care of "next" pointer as "Remove" updates all 4 bindings.
// 3. InsertAfter and InsertBefore (uses 1)
// 4. SetHead and SetTail (uses 3)
// 5. InsertAtPosition (uses 3 and 4).


namespace Leetcode
{
    public class DoublyLinkedList
    {
        public Node Head;
        public Node Tail;

        public void SetHead(Node node)
        {
            if (Head == null)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                InsertBefore(Head, node);
            }

        }

        public void SetTail(Node node)
        {
            if (Tail == null)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                InsertAfter(Tail, node);
            }

        }

        public void InsertBefore(Node node, Node nodeToInsert)
        {
            if (nodeToInsert == Head && nodeToInsert == Tail) return; // validation - we cannot insert head or tail. we can only set it.
            Remove(nodeToInsert); // This clears all the bindings regardless of whether its a node inside the list or a standalone node.

            nodeToInsert.Prev = node.Prev; // Outgoing1
            nodeToInsert.Next = node;      // Outgoing2

            if (node.Prev == null)         //Edge case (HEAD) 
                Head = nodeToInsert;
            else
                node.Prev.Next = nodeToInsert; //Incoming1

            node.Prev = nodeToInsert; //Incoming2
        }

        public void InsertAfter(Node node, Node nodeToInsert)
        {
            if (nodeToInsert == Head && nodeToInsert == Tail) return; // validation - we cannot insert head or tail. we can only set it.
            Remove(nodeToInsert); // This clears all the bindings regardless of whether its a node inside the list or a standalone node.

            nodeToInsert.Next = node.Next; // Outgoing1
            nodeToInsert.Prev = node;      // Outgoing2

            if (node.Next == null)         //Edge case (TAIL) 
                Tail = nodeToInsert;
            else
                node.Next.Prev = nodeToInsert; //Incoming1

            node.Next = nodeToInsert; //Incoming2
        }

        public void InsertAtPosition(int position, Node nodeToInsert)
        {
            if (position == 1)
            {
                SetHead(nodeToInsert);
            }
            else
            {
                int i = 1;
                Node current = Head;
                while (i != position)
                {
                    current = current.Next;
                    i++;
                }

                if (current != null)
                    InsertBefore(current, nodeToInsert);
                else
                    SetTail(nodeToInsert);
            }

        }

        public void RemoveNodesWithValue(int value)
        {
            Node current = Head;
            while (current != null)
            {
                Node next = current.Next;
                if (current.Value == value)
                {
                    Remove(current);
                }
                current = next;
            }
        }

        public void Remove(Node node)
        {
            if (node == Head) Head = Head.Next;
            if (node == Tail) Tail = Tail.Prev;

            // Below 4 lines remove the "node" bindings (2 incoming and 2 outgoing pointers)
            if (node.Prev != null) node.Prev.Next = node.Next;
            if (node.Next != null) node.Next.Prev = node.Prev;
            node.Next = null;
            node.Prev = null;
        }

        public bool ContainsNodeWithValue(int value)
        {
            Node current = Head;
            while (current != null)
            {
                if (current.Value == value)
                    return true;
                current = current.Next;
            }
            return false;
        }
    }

    // Do not edit the class below.
    public class Node
    {
        public int Value;
        public Node Prev;
        public Node Next;

        public Node(int value)
        {
            this.Value = value;
        }
    }
}
