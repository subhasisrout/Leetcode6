// #InsertionSort #Visual representation in Leetcode question
// #Reverse LinkedList type pattern
// #dummyHead #SentinelNode

namespace Leetcode
{
    public class InsertionSortListLC147
    {
        public ListNode InsertionSortList(ListNode head)
        {
            ListNode dummy = new ListNode(0, head);
            ListNode prev = head;
            ListNode curr = head.next;
            while (curr != null)
            {
                if (curr.val >= prev.val)
                {
                    prev = curr;
                    curr = curr.next;
                    continue;
                }
                else
                {
                    ListNode tmp = dummy;
                    while (curr.val > tmp.next.val)
                        tmp = tmp.next;

                    //reverse linkedlist type pattern
                    prev.next = curr.next;
                    curr.next = tmp.next;
                    tmp.next = curr;
                    curr = prev.next;
                }
            }
            return dummy.next;
        }
    }
}
