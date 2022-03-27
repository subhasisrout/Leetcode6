// #Leetcode #LC 19
namespace Leetcode
{
    public class RemoveKthNodeFromEndAE
    {
        public static void RemoveKthNodeFromEnd(LinkedList head, int k)
        {
            LinkedList p1 = head;
            LinkedList p2 = head;
            int i = 0;
            while (i < k)
            {
                if (p1 != null)
                    p1 = p1.Next;
                i++;
            }
            if (p1 == null)
            {
                head.Value = head.Next.Value;
                head.Next = head.Next.Next;
                return;
            }

            while (p1.Next != null)
            {
                p2 = p2.Next;
                p1 = p1.Next;
            }
            Remove(head, p2);
        }
        private static void Remove(LinkedList head, LinkedList p2)
        {
            p2.Next = p2.Next.Next;
        }
    }
    public class LinkedList
    {
        public int Value;
        public LinkedList Next = null;

        public LinkedList(int value)
        {
            this.Value = value;
        }
    }
}
