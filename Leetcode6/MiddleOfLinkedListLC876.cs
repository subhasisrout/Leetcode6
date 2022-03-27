namespace Leetcode
{
    public class MiddleOfLinkedListLC876
    {
        public ListNode MiddleNode(ListNode head)
        {
            if (head == null || head.next == null)
                return head;

            ListNode prev = null;
            ListNode slow = head;
            ListNode fast = head;

            while (fast != null && fast.next != null)
            {
                prev = slow;
                slow = slow.next;
                fast = fast.next.next;
            }

            prev.next = null; // The use of 'prev' pointer and THIS SPECIFIC LINE is to CUT the list.
            // The above line is used in SortList148
            return slow;
        }

        //came up with below while doing series of linkedlist questions.
        public ListNode MiddleNode2(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            ListNode slow = head;
            ListNode fast = head.next;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            if (fast == null)
                return slow;
            else
                return slow.next;
        }
    }
}
