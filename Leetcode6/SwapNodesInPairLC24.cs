// Mind blowing solution in one of the discussion comment. https://leetcode.com/problems/swap-nodes-in-pairs/discuss/11046/My-simple-JAVA-solution-for-share/186959

// Solved with LC1721, LC24, LC147

namespace Leetcode
{
    public class SwapNodesInPairLC24
    {
        public ListNode SwapPairs(ListNode head)
        {
            ListNode dummy = new ListNode(0);
            dummy.next = head;
            ListNode point = dummy;
            while (point.next != null && point.next.next != null)
            {
                ListNode swap1 = point.next;
                ListNode swap2 = point.next.next;
                point.next = swap2;
                swap1.next = swap2.next;
                swap2.next = swap1;
                point = swap1;
            }
            return dummy.next;
        }
    }
}
