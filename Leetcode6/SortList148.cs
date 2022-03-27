using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class SortList148
    {
        public ListNode SortList(ListNode head)
        {
            if (head == null)
                return null;
            if (head.next == null)
                return head;

            ListNode mid = MiddleNode(head);
            ListNode left = SortList(head);
            ListNode right = SortList(mid);
            return MergeSortedList(left, right);

        }
        private ListNode MergeSortedList(ListNode l1, ListNode l2)
        {
            ListNode dummy = new ListNode(-1);
            ListNode head = dummy;
            dummy.next = head;
            while (l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
                {
                    dummy.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    dummy.next = l2;
                    l2 = l2.next;
                }
                dummy = dummy.next;
            }
            // either l1 or l2 or (l1 and l2) are traversed completely
            if (l1 != null)
                dummy.next = l1;
            else
                dummy.next = l2;

            return head.next;
        }

        private ListNode MiddleNode(ListNode head)
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
    }
}
