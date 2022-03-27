// #Check Diagram and #Leetcode #LC142


namespace Leetcode
{
    public class FindLoopInLinkedListAE
    {
        public static LinkedList FindLoop(LinkedList head)
        {
            LinkedList slow = head.next;
            LinkedList fast = head.next.next;
            while (slow != fast)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            fast = head;
            while (slow != fast)
            {
                slow = slow.next;
                fast = fast.next;
            }
            return slow;
        }

        public class LinkedList
        {
            public int value;
            public LinkedList next = null;

            public LinkedList(int value)
            {
                this.value = value;
            }
        }
    }
}
