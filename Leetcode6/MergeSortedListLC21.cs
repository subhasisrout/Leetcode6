// Present in #AlgoExpert #AE too, but approaches from @Kevin Naughton Jr and #Michael Muinos are better

namespace Leetcode
{
    public class MergeSortedListLC21
    {
        //Naive version made by me
        public ListNode MergeTwoLists2(ListNode l1, ListNode l2)
        {
            ListNode retVal = null;
            ListNode temp = null;
            ListNode retValCurrNode = null;
            while (l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
                {
                    if (retVal == null)
                        retVal = new ListNode(l1.val);
                    else
                    {
                        retValCurrNode = retVal;
                        while (retValCurrNode != null)
                        {
                            temp = retValCurrNode;
                            retValCurrNode = retValCurrNode.next;
                        }
                        temp.next = new ListNode(l1.val);
                    }
                    l1 = l1.next;
                }
                else
                {
                    if (retVal == null)
                        retVal = new ListNode(l2.val);
                    else
                    {
                        retValCurrNode = retVal;
                        while (retValCurrNode != null)
                        {
                            temp = retValCurrNode;
                            retValCurrNode = retValCurrNode.next;
                        }
                        temp.next = new ListNode(l2.val);
                    }

                    l2 = l2.next;

                }
            }

            if (l1 == null) //add remaining elements of l2
            {
                if (retVal == null)
                    retVal = l2;
                else
                {
                    retValCurrNode = retVal;
                    while (retValCurrNode != null)
                    {
                        temp = retValCurrNode;
                        retValCurrNode = retValCurrNode.next;
                    }
                    temp.next = l2;
                }
            }
            if (l2 == null) //add remaining elements of l1
            {
                if (retVal == null)
                    retVal = l1;
                else
                {
                    retValCurrNode = retVal;
                    while (retValCurrNode != null)
                    {
                        temp = retValCurrNode;
                        retValCurrNode = retValCurrNode.next;
                    }
                    temp.next = l1;
                }
            }
            return retVal;

        }

        //Better polished version from youtube - kevin naughton jr. Similar by Micheal Muinos
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode dummy = new ListNode(-1);
            ListNode head = dummy;
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
            if (l1 != null)
                dummy.next = l1;
            else
                dummy.next = l2;
            return head.next;
        }
    }
}
