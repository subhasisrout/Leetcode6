using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class ShiftLinkedListAE
    {
		public static LinkedList ShiftLinkedList(LinkedList head, int k)
		{
			if (k == 0)
				return head;
			if (k < 0)
				return ShiftLinkedListKNegative(head, k);
			int len = 0;
			LinkedList curr = head;
			while (curr != null)
			{
				len++;
				curr = curr.next;
			}

			k = k % len; // case where k is larger than the len of the linkedlist
			if (k == 0)
				return head;

			int newIdx = len - k;
			curr = head;
			int idx = 0;
			while (idx < newIdx - 1)
			{
				idx++;
				curr = curr.next;
			}

			LinkedList newHead = curr.next;
			curr.next = null;

			curr = newHead;
			while (curr.next != null)
				curr = curr.next;

			curr.next = head;
			return newHead;

		}

		public static LinkedList ShiftLinkedListKNegative(LinkedList head, int k)
		{
			int len = 0;
			LinkedList curr = head;
			LinkedList originalLastNode = null;
			while (curr != null)
			{
				len++;
				originalLastNode = curr;
				curr = curr.next;
			}

			k = k * -1;
			k = k % len; // case where k is larger than the len of the linkedlist
			if (k == 0)
				return head;

			curr = head;
			int newIdx = 0;
			LinkedList newLastNode = null;
			while (newIdx < k)
			{
				newLastNode = curr;
				curr = curr.next;
				newIdx++;
			}

			originalLastNode.next = head;
			newLastNode.next = null;
			return curr;
		}

		public class LinkedList
        {
            public int value;
            public LinkedList next;

            public LinkedList(int value)
            {
                this.value = value;
                next = null;
            }
        }
    }
}
