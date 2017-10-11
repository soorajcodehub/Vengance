using System;
using System.Collections.Generic;

namespace CrackThat
{
    public class LinkedListNode
    {
        internal int data;
        internal LinkedListNode next;
        internal LinkedListNode(int data)
        {
            this.data = data;   
        }
    }

    public class LinkedList
    {
        internal LinkedListNode head;
        internal LinkedListNode tail;

        internal void PushNode(int data)
        {
            if (head == null)
            {
                tail = head = new LinkedListNode(data);
            }

            else 
            {
                tail.next = new LinkedListNode(data);
                tail = tail.next;
            }
        }

        internal static void PrintList(LinkedListNode head)
        {
            LinkedListNode current = head;
            while (current != null)
            {
                Console.Write(current.data);
                if (current.next != null)
                {
                    Console.Write(" => ");
                }
                current = current.next;
            }

            Console.WriteLine();
        }

    }

    public class LinkedListProblems
    {
        public static LinkedListNode MergeTwoSortedLinkedLists(LinkedListNode current1, LinkedListNode current2)
        {

            if (current1 == null && current2 != null)
            {
                return current2;
            }

            else if (current2 == null && current1 != null)
            {
                return current1;
            }

            LinkedListNode mergedHead = null;
			LinkedListNode previous = null;

            if (current1.data < current2.data)
            {
                mergedHead = current1;
                previous = current1;
                current1 = current1.next;
            }
            else
            {
                mergedHead = current2;
                previous = current2;
                current2 = current2.next;
            }

            while (true)
            {
                if (current1 == null && current2 != null)
                {
                    current1 = current2;
                    break;
                }

                if (current2 == null && current1 != null)
                {
					current2 = current1;
					break;
                }

                if (current1.data < current2.data)
                {
                    LinkedListNode temp = current1.next;
                    previous.next = current1;
                    current1.next = current2;
                    previous = current1;
                    current1 = temp;
                }
                else
                {
				    LinkedListNode temp = current2.next;
                    previous.next = current2;
					current2.next = current1;
                    previous = current1;
					current2 = temp;
                }

            }

            LinkedList.PrintList(mergedHead);
            return mergedHead;

        }

        public static void MergeKSortedLists(List<LinkedList> listOfLists)
        {
            LinkedListNode mergedHead = null;

			for (int i = 0; i < listOfLists.Count; i ++)
            {
               mergedHead  =  MergeTwoSortedLinkedLists(mergedHead, listOfLists[i].head);
            }

            LinkedList.PrintList(mergedHead);

        }

		private static void _moveSmallerNodeBeforeBiggerNode(ref LinkedListNode smallerNode, ref LinkedListNode biggerNode)
		{
            LinkedListNode temp = smallerNode.next;
            smallerNode.next = biggerNode;
            smallerNode = temp;
		}
    }
}
