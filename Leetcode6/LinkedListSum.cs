// My implementation was naive. While adding a new element to the end, it was doing 'n' iterations (commented)
// Using a "dummyHead" and "currentNode" pattern is smarts. Addition of element is done in constant time.
// while returning, just do "dummyHead.next"
// #Leetcode #LC 2

namespace Leetcode2
{
    public class LinkedListSum
    {


        public LinkedList SumOfLinkedLists(LinkedList l1, LinkedList l2)
        {
            int carry = 0;
            LinkedList head1 = l1;
            LinkedList head2 = l2;
            LinkedList resultHead = new LinkedList(0); //LinkedList resultHead = null;
            LinkedList currentNode = resultHead;
            while (head1 != null || head2 != null)
            {
                int newVal = 0;
                if (head1 == null)
                {
                    newVal = head2.val + carry;
                    head2 = head2.next;
                }
                else if (head2 == null)
                {
                    newVal = head1.val + carry;
                    head1 = head1.next;
                }
                else
                {
                    newVal = head1.val + head2.val + carry;
                    head1 = head1.next;
                    head2 = head2.next;
                }

                if (newVal < 10)
                    carry = 0;
                else
                {
                    carry = 1;
                    newVal = newVal % 10;
                }


                currentNode.next = new LinkedList(newVal);
                currentNode = currentNode.next;

                //if (resultHead == null)
                //    resultHead = new LinkedList(newVal);
                //else
                //{
                //    LinkedList tmp = resultHead;
                //    while (tmp.next != null)
                //    {
                //        tmp = tmp.next;
                //    }
                //    tmp.next = new LinkedList(newVal);
                //}
            }
            if (carry != 0)
            {
                //LinkedList tmp = resultHead;
                //while (tmp.next != null)
                //{
                //    tmp = tmp.next;
                //}
                //tmp.next = new LinkedList(carry);

                currentNode.next = new LinkedList(carry);
                currentNode = currentNode.next;
            }
            return resultHead.next;
        }
    }
    public class LinkedList
    {
        public int val;
        public LinkedList next;

        public LinkedList(int value)
        {
            this.val = value;
            this.next = null;
        }
    }
}
