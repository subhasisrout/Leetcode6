using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// referred nick white video - https://www.youtube.com/watch?v=gfFn-OXxcgU
// RememberPattern
// another pattern is to use the dummy/pre head in the beginning.
namespace Leetcode
{
    public class RemoveElementsFromLinkedListLC203
    {
        public ListNode RemoveElements(ListNode head, int val)
        {
            if (head == null)
                return null;

            while (head != null && head.val == val)
                head = head.next;

            ListNode current = head;
            while (current != null && current.next != null)
            {
                if (current.next.val == val)
                {
                    current.next = current.next.next;
                }
                else
                {
                    current = current.next;
                }
            }
            return head;
        }
        public ListNode RemoveElements2(ListNode head, int val)
        {
            if (head == null)
                return null;

            ListNode pre = new ListNode(int.MinValue);
            ListNode current = pre;
            pre.next = head;

            while (current.next != null)
            {
                if (current.next.val == val)
                {
                    current.next = current.next.next;
                }
                else
                    current = current.next;
            }

            return pre.next;
        }
    }
}
