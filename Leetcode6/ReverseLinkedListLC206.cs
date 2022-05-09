// #RememberPattern
// using regular prev,curr,next for reversal.
// always remember after reversal, curr is out-of-the-list/sublist and prev is at the last element of the list/sublist 

namespace Leetcode
{
    public class ReverseLinkedListLC206
    {
        public ListNode ReverseList(ListNode head)
        {
            if (head == null)
                return null;

            ListNode curr = head;
            ListNode next = null;
            ListNode prev = null;
            while (curr != null)
            {
                next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }

            head = prev;
            return head;
        }
    }
}
