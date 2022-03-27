// #RememberPattern
// #Similar to LC 108
// #Important part in finding MID - Dont forget to disconnect/break the list.
namespace Leetcode
{
    public class ConvertSortedLinkedListToBalancedBSTLC109
    {
        public TreeNode SortedListToBST(ListNode head)
        {
            if (head == null)
                return null;

            ListNode mid = MiddleNode(head);


            TreeNode root = new TreeNode(mid.val);
            if (head == mid)
                return root;

            root.left = this.SortedListToBST(head);
            root.right = this.SortedListToBST(mid.next);

            return root;
        }
        private ListNode MiddleNode(ListNode head)
        {
            if (head == null)
                return null;

            ListNode prev = null; //this is not needed for finding MID, but for disconnecting the linked list.
            ListNode slow = head;
            ListNode fast = head.next;

            while (fast != null)
            {
                prev = slow;
                slow = slow.next;

                if (fast.next != null)
                    fast = fast.next.next;
                else
                    fast = null; // come out of while loop
            }

            if (prev != null)
                prev.next = null; //this line disconnects (breaks) the list into 2.
                                  //otherwise this program will be stuck in an infinite loop.
            return slow;
        }
    }
}
