// #Tricky
// Very #intuitive explaination from Neetcode - https://www.youtube.com/watch?v=RF_M9tX4Eag
// Check again if want to revise for picture
// 3 phase implementation.


namespace Leetcode
{
    public class ReverseLinkedListIILC92
    {
        public ListNode ReverseBetween(ListNode head, int left, int right)
        {

            //Phase1 - dummy pointer, move curr to left and leftPrev to just before it
            ListNode dummy = new ListNode(0);
            dummy.next = head;
            ListNode leftPrev = dummy; //store a reference to prev of "original left"
            ListNode curr = head;
            for (int i = 0; i < left - 1; i++)
            {
                leftPrev = curr;
                curr = curr.next;
            }

            //Phase2 - reverse the subList (Typical LinkedList reversal)
            ListNode prev = null;
            for (int i = 0; i < right - left + 1; i++)
            {
                ListNode tmpNext = curr.next;
                curr.next = prev;
                prev = curr;
                curr = tmpNext;
            }
            //after the above loop (phase 2), curr will point to right of "original right"

            //Phase3 - update pointers
            leftPrev.next.next = curr;
            leftPrev.next = prev;

            return dummy.next;
        }
    }
}
