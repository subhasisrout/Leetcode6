// #LinkedList #LL

namespace Leetcode
{
    public class OddEvenLinkedListLC328
    {

        // LeetCode solution. Less lines of code. 
        // Based on the fact that - first Even or Even.Next will become NULL before odd.
        public ListNode OddEvenList(ListNode head)
        {
            if (head == null) return head;
            ListNode odd = head;
            ListNode even = head.next;
            ListNode orignalEven = even;
            
            while (even != null && even.next != null)
            {
                odd.next = even.next;
                odd = odd.next; //move fwd

                even.next = odd.next;
                even = even.next; //move fwd
            }
            odd.next = orignalEven;
            return head;
        }

        // Self written solution. Lot of lines of code.
        public ListNode OddEvenList2(ListNode head)
        {
            if (head == null || head.next == null || head.next.next == null)
                return head;

            ListNode odd = head;
            ListNode prevOdd = odd;
            ListNode even = head.next;
            ListNode firstEven = even;
            bool isOdd = true;
            while (odd != null && even != null)
            {
                prevOdd = odd;
                if (isOdd)
                {
                    odd.next = even.next;
                    odd = even.next;
                    isOdd = false; //now even
                }
                else
                {
                    even.next = odd.next;
                    even = odd.next;
                    isOdd = true; //now odd
                }
            }
            if (odd != null) odd.next = firstEven;
            else prevOdd.next = firstEven;

            return head;
        }
    }
}
