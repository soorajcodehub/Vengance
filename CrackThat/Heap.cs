using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace CrackThat
{
    public class Heap
    {
        int heapSize;
        int currentSize;
        bool isMaxHeap;
        int[] heapArray;

        public Heap(int heapSize, bool isMaxHeap)
        {
            this.heapSize = heapSize;
            this.isMaxHeap = isMaxHeap;
        }

        public void Insert(int num)
        {
            if (currentSize < this.heapSize)
            {
                if (isMaxHeap)
                {
                    this.heapArray[this.currentSize] = num;
                    for (int i = this.currentSize / 2; i >= 0; i--)
                    {
                        this.maxHeapify(num, this.currentSize);
                    }
                    this.currentSize++;
                }
            }
        }

        public void printHeap()
        {
            this.printHeapUtil(0, 0);
        }

        private void printHeapUtil(int i, int level)
        {
            if (i < this.currentSize) 
            {
                Console.WriteLine(this.heapArray[i] + " at level " + level );
                printHeapUtil(i * 2, level + 1);
                printHeapUtil(i * 2 +1, level + 1);
            }
        }

        private void maxHeapify(int num, int currentIndex)
        {
            int left = currentIndex * 2;
            int right = currentIndex * 2 + 1;
            int largest = currentIndex;; 

            if (left < currentSize && this.heapArray[left] < this.heapArray[largest]) 
            {
                largest = left; 
            }

            if (right < currentSize && this.heapArray[right] < this.heapArray[largest])
            {
                largest = right;
            }

            if (largest != currentIndex)
            {
                int temp = this.heapArray[largest];
                this.heapArray[largest] = this.heapArray[currentIndex];
                this.heapArray[currentIndex] = this.heapArray[largest];

                this.maxHeapify(this.heapArray[largest], largest);
            }

        }
    }
}