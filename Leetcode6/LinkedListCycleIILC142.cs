// For better understanding, you can also refer Kunal Kushwaha video at https://www.youtube.com/watch?v=70tx7KcMROc
// around. 1 hour: 10 mins
// He explains using the length of the cycle.

namespace Leetcode
{
    public class LinkedListCycleIILC142
    {
        public ListNode DetectCycle(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;

            while (fast != null && fast.next != null && fast.next.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)
                {
                    //START - Below block of code comes into picture, once its confirmed there is a loop
                    //and slow and fast have met. 
                    //Use the formula discussed in #AlgoExpert 
                    fast = head;
                    while (slow != fast)
                    {
                        slow = slow.next;
                        fast = fast.next;
                    }
                    return slow;
                    //END
                }
            }
            return null;
        }
    }
}
