// Inspired from #Needcode https://www.youtube.com/watch?v=1UOPsfP85V4

namespace Leetcode6
{
    public class ReverseNodesInKGroupLC25
    {
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            ListNode dummy = new ListNode(0, head);
            ListNode groupPrev = dummy;
            ListNode groupNext = null;

            while (true)
            {
                var kth = GetKth(groupPrev.next, k);
                if (kth == null)
                    break;
                groupNext = kth.next; //Only purpose to capture this is to use in Line 23 (navigating curr)

                //group reverse logic - START (not prev is set to NULL otherwise the link will after after the first group
                var prev = kth.next;
                var curr = groupPrev.next;
                while (curr != groupNext)
                {
                    var tmp1 = curr.next;
                    curr.next = prev;
                    prev = curr;
                    curr = tmp1;
                }
                //group reverse logic - END
                //The above part is like a normal reverse linkedlist.
                //Remember after reverse() is called, the positions of prev,curr,next --- last node of LL, out of LL, out out of LL
                //The original start node, which after reverse would point to NULL (will break the LL), hence Line 21

                //The below 3 lines are forwarding the groupPrev. They are MOST TOUGH.
                //Originally groupPrev.next was point to 1(start). Store it in tmp.
                //we want groupPrev.next point to 3. Hence Line 40. Remember after local Reverse(), prev points to the lastNode.
                //set groupPrev after reverse() to 1, which was stored in tmp.
                var tmp = groupPrev.next;
                groupPrev.next = prev;
                groupPrev = tmp;
            }

            return dummy.next;

            ListNode GetKth(ListNode curr, int k)
            {
                while (curr != null && k > 1)
                {
                    curr = curr.next;
                    k--;
                }
                return curr;
            }
        }
    }
}
