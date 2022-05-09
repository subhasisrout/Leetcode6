// #Tricky
// Very #intuitive explaination from Neetcode - https://www.youtube.com/watch?v=RF_M9tX4Eag
// Check again if want to revise for picture
// 3 phase implementation.

//2022-05-03 UPDATE - Leetcode solution seems intuitive.
//using regular prev,curr,next for reversal and TAIL, CON for maintaining connections before and after reversal
//always remember after reversal, curr is out-of-the-list/sublist and prev is at the last element of the list/sublist 
//Because we are using dummyNode, no null check needed at con.next=prev

namespace Leetcode
{
    public class ReverseLinkedListIILC92
    {
        public ListNode ReverseBetween(ListNode head, int left, int right)
        {
            ListNode prev = new ListNode(0, head);
            ListNode curr = head;
            ListNode dummy = prev;

            // reach left node
            for (int i = 0; i < left - 1; i++)
            {
                prev = curr;
                curr = curr.next;
            }

            ListNode tail = curr;
            ListNode con = prev;
            for (int i = 0; i < right - left + 1; i++)
            {
                ListNode tmp = curr.next;
                curr.next = prev;
                prev = curr;
                curr = tmp;
            }

            //after reversal, now prev points to nth node

            con.next = prev;
            tail.next = curr;

            return dummy.next;
        }
    }
}
