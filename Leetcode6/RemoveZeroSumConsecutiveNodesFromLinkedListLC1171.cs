using System.Collections.Generic;

// Excellent explaination with intuition at https://www.youtube.com/watch?v=tss5biw6ctI
// #PrefixSum #HashMap
// #Clever

namespace Leetcode
{
    public class RemoveZeroSumConsecutiveNodesFromLinkedListLC1171
    {
        public ListNode RemoveZeroSumSublists(ListNode head)
        {
            ListNode dummy = new ListNode(-1);
            dummy.next = head;
            int prefixSum = 0;
            Dictionary<int, ListNode> map = new Dictionary<int, ListNode>();
            map.Add(prefixSum, dummy);
            while (head != null)
            {
                prefixSum += head.val;
                if (map.ContainsKey(prefixSum))
                {
                    // Remove from map START
                    int interimSum = prefixSum;
                    ListNode to_remove = map[prefixSum].next;
                    while (to_remove != head)
                    {
                        interimSum += to_remove.val;
                        map.Remove(interimSum);
                        to_remove = to_remove.next;
                    }
                    // Remove from map END

                    // Create Link
                    map[prefixSum].next = head.next;
                }
                else
                {
                    map.Add(prefixSum, head);
                }
                head = head.next;
            }
            return dummy.next;
        }
    }
}
