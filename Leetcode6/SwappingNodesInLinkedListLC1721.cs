// #SelfWritten
// #dummyHead #SentinelNode
// use p1,n1,p2,n2 for prevnode1,node1,prevnode2,node2 and just adjust pointers in 5 lines.
// get kth node from #LinkedList end in one iteration

namespace Leetcode
{
    public class SwappingNodesInLinkedListLC1721
    {
        public ListNode SwapNodes(ListNode head, int k)
        {
            ListNode dummy = new ListNode(0, head);
            int i = 1;
            ListNode n1 = head;
            ListNode p1 = dummy;
            while (i < k)
            {
                n1 = n1.next;
                p1 = p1.next;
                i++;
            }


            ListNode n2 = head;
            ListNode p2 = dummy;
            ListNode tmp = n1;

            while (tmp.next != null) //capture kth node from end in ONE iteration
            {
                tmp = tmp.next;
                n2 = n2.next;
                p2 = p2.next;
            }

            // 5 lines to adjust pointers. very intuitive with p1,n1,p2,n2
            p1.next = n2;
            p2.next = n1;
            tmp = n2.next;
            n2.next = n1.next;
            n1.next = tmp;

            return dummy.next;
        }
    }
}
