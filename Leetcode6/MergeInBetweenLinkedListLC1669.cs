namespace Leetcode
{
    public class MergeInBetweenLinkedListLC1669
    {
        public ListNode MergeInBetween(ListNode list1, int a, int b, ListNode list2)
        {
            int i = 0;
            ListNode list1LeftPrev = null;
            ListNode list1LeftPrevCopy = null;
            ListNode list1RightNext = null;
            ListNode list1Copy = list1;
            while (list1Copy != null)
            {
                if (i == a - 1)
                {
                    list1LeftPrev = list1Copy;
                    list1LeftPrevCopy = list1LeftPrev;
                }
                list1LeftPrev = list1Copy;


                if (i == b)
                {
                    list1RightNext = list1Copy.next;
                    break;
                }

                list1Copy = list1Copy.next;
                i++;
            }

            list1LeftPrevCopy.next = list2;

            ListNode lastList2Node = null;
            while (list2 != null)
            {
                lastList2Node = list2;
                list2 = list2.next;
            }

            lastList2Node.next = list1RightNext;


            return list1;

        }
    }
}
