namespace Leetcode
{
    public class LinkedListCycleLC141
    {
        public bool HasCycle(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;

            // #Key condition for fast pointer only.
            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
                if (fast == slow) return true;
            }
            return false;
        }
    }
}

//Another extension of the above question could be to find the length the cycle. 
// 1->2->3->4->5->
//             |   \
//             |   6
//             7<-/
// Above the length of the cycle is 3.
// Once fast==slow in line 15. Just advance the slow pointer one-by-one until you reach fast and do length++.