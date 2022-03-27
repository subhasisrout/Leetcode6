using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class PalindromeLinkedListLC234
    {
        ListNode prevToMid = null;
        public bool IsPalindrome(ListNode head)
        {
            if (head == null || head.next == null) return true;

            ListNode origHead = head;
            ListNode mid = GetMid2(head);
            ListNode newHead = Reverse(mid);

            //To your stuff here 
            bool isPalindrome = true;
            while (head != mid || newHead != null)
            {
                if (head.val != newHead.val)
                {
                    isPalindrome = false;
                    break;
                }
                head = head.next;
                newHead = newHead.next;
            }

            //reverse second half once more to bring to original. Adjust pointers
            ListNode origMid = Reverse(mid);
            prevToMid.next = origMid;
            head = origHead;

            return isPalindrome;

        }
        public ListNode GetMid2(ListNode head)
        { //2 because of even nodes, it returns the second one.
            ListNode slow = head;
            ListNode fast = head;
            while (fast != null && fast.next != null)
            {
                prevToMid = slow;
                slow = slow.next;
                fast = fast.next.next;
            }
            return slow;
        }
        public ListNode Reverse(ListNode head)
        {
            ListNode prev = null;
            ListNode curr = head;
            while (curr != null)
            {
                ListNode tmpNext = curr.next;
                curr.next = prev;
                prev = curr;
                curr = tmpNext; //advance
            }
            return prev; //or set head to prev and return head;
        }
    }
}
