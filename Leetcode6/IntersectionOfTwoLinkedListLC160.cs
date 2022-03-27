
// submitted multiple version in leetcode.
// this one is using O(1) space.
// earlier version was using Hashset to keep track of visited nodes.
// first version was using O(n^2) time. nested loops.
namespace Leetcode
{
    public class IntersectionOfTwoLinkedListLC160
    {
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            if (headA == null || headB == null)
                return null;
            
            int lenA = 0;
            int lenB = 0;
            ListNode ha = headA, hb = headB;
            while (ha != null)
            {
                lenA++;
                ha = ha.next;
            }

            while (hb != null)
            {
                lenB++;
                hb = hb.next;
            }

            int diff = 0;
            if (lenB > lenA)
            {
                diff = lenB - lenA;
                for (int i = 0; i < diff; i++)
                {
                    headB = headB.next;
                }
            }
            else if (lenA > lenB)
            {
                diff = lenA - lenB;
                for (int i = 0; i < diff; i++)
                {
                    headA = headA.next;
                }
            }

            while (headA != null || headB != null)
            {
                if (headA == headB)
                    return headA;

                headA = headA.next;
                headB = headB.next;
            }


            return null;
        }
    }
}
