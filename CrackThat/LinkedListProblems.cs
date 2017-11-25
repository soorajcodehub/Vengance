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

        public static LinkedListNode Reverse(ref LinkedListNode head)
        {
            if (head == null)
            {
                return head;
            }

            LinkedListNode current = head;
            LinkedListNode previous = null;
            LinkedListNode temp = null;

            while (current != null)
            {
                temp = current.next;
                current.next = previous;
                previous = current;
                current = temp;
            }

            head = previous;
            return head;
        }

        public static LinkedListNode ReverseK(ref LinkedListNode head, int k)
        {
            if (head == null)
            {
                return head;
            }

            LinkedListNode current = head;
            LinkedListNode previous = null;
            LinkedListNode temp = null;
            int i = 0;
            bool isFirstLinkedListSubsetBeingPreocessed = false;
            LinkedListNode endNodeOfCurrentLinkedListSubset = null;
            LinkedListNode endNodeOfPreviousLinkedListSubset = null;
            while (current != null)
            {
                if (_hasEnougNodesToReverse(current, k))
                {
                    endNodeOfPreviousLinkedListSubset = endNodeOfCurrentLinkedListSubset;
                    endNodeOfCurrentLinkedListSubset = current;

                    if (current == head)
                    {
                        previous = null;
                        isFirstLinkedListSubsetBeingPreocessed = true;
                    }
                    else 
                    {
                        isFirstLinkedListSubsetBeingPreocessed = false;
                    }

                    while (i < k)
                    {
                        temp = current.next;
                        current.next = previous;
                        previous = current;
                        current = temp;
                        i++;
                    }

                    // point the end of processed linkesList to the start of the next linkedlist subset 
                    endNodeOfCurrentLinkedListSubset.next = current;

                    i = 0;

                    if(isFirstLinkedListSubsetBeingPreocessed)
                    {
                        head = previous;
                    }
                    else // we have precessed at least one subset, which means we have an end node for a processed subset, so set its next
                    {
                        endNodeOfPreviousLinkedListSubset.next = previous;
                    }

                    previous = endNodeOfCurrentLinkedListSubset;
                }
                else
                {
                    break;
                }
            }

            return head;
        }

        private static bool _hasEnougNodesToReverse(LinkedListNode current, int k)
        {
            int i = 0;
            while (i < k && current != null)
            {
                current = current.next;
                i++;
            }

            return (i == k);
        }

		private static void _moveSmallerNodeBeforeBiggerNode(ref LinkedListNode smallerNode, ref LinkedListNode biggerNode)
		{
            LinkedListNode temp = smallerNode.next;
            smallerNode.next = biggerNode;
            smallerNode = temp;
		}
    }
}
