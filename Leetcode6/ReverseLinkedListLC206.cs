// #RememberPattern
namespace Leetcode
{
    public class ReverseLinkedListLC206
    {
        public ListNode ReverseList(ListNode head)
        {
            if (head == null)
                return null;

            ListNode current = head;
            ListNode next = null;
            ListNode prev = null;
            while (current != null)
            {
                next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }

            head = prev;
            return head;
        }
    }
}
