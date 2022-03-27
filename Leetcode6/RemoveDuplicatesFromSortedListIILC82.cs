using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// #dummyNode - Here dummyNode (aka sentinel node) pattern is very useful as the head itself can change in 1->1->1->2->3


namespace Leetcode
{
    public class RemoveDuplicatesFromSortedListIILC82
    {
        public ListNode DeleteDuplicates(ListNode head)
        {
            ListNode dummy = new ListNode(-1);
            dummy.next = head;
            ListNode previous = dummy;

            while (head != null) // since we have captured head in pre.next, we are free to change head
            { 
                if (head.next != null && head.val == head.next.val) //improve readability with if
                {
                    while (head.next != null && head.val == head.next.val) //note this while condition is exact same as above if condition.
                    {
                        head = head.next;
                    }
                    
                    //bypass the duplicate sublist
                    previous.next = head.next;
                }
                else
                {
                    previous = previous.next;
                }

                //advance
                head = head.next;
            }

            return dummy.next; //dummyNode pattern
        }
    }
}
