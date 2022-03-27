using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class MergeKSortedListLC23
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null || lists.Count() == 0)
                return null;

            ListNode finalList = null;           
            int listIndexHavingMinVal = 0;            
            while (true)
            {
                bool nodePresentForTraversal = false;
                int minimum = int.MaxValue;
                for (int i = 0; i < lists.Length; i++)
                {                    
                    if (lists[i] != null && lists[i].val <= minimum)
                    {
                        minimum = lists[i].val;
                        listIndexHavingMinVal = i;
                        nodePresentForTraversal = true;
                    }
                }
                if (!nodePresentForTraversal)
                    break;
                if (finalList == null)
                {
                    finalList = new ListNode(lists[listIndexHavingMinVal].val);
                }
                else
                {
                    ListNode tmp = finalList;
                    while (tmp.next != null)
                        tmp = tmp.next;
                    tmp.next = new ListNode(lists[listIndexHavingMinVal].val);
                }
                lists[listIndexHavingMinVal] = lists[listIndexHavingMinVal].next;                
            }
            return finalList;

        }
    }
}
