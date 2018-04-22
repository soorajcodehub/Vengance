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
            this.heapArray = new int[heapSize];
        }

        public int CurrentSize 
        {
            get 
            {
                return this.currentSize;
            }
        }

        public int Root 
        {
            get
            {
                return this.heapArray[0];
            }
        }

        public void Insert(int num)
        {
            if (this.isMaxHeap)
            {

                if (currentSize < this.heapSize)
                {
                    this.heapArray[this.currentSize] = num;
                    this.currentSize++;
                    for (int i = this.currentSize / 2; i >= 0; i--)
                    {
                        this.maxHeapify(num, i, this.currentSize);
                    }

                }
                else
                {
                    if (this.heapArray[0] > num)
                    {
                        this.heapArray[0] = num;
                        for (int i = this.currentSize / 2; i >= 0; i--)
                        {
                            this.maxHeapify(num, i, this.currentSize);
                        }
                    }
                }
            }
            else
            {
                if (this.currentSize < this.heapSize)
                {
                    this.heapArray[this.currentSize] = num;
                    this.currentSize++;
                    for (int i = this.currentSize / 2; i >= 0; i--)
                    {
                        this.minHeapify(num, i, this.currentSize);
                    }
                }
                else 
                {
                    if (this.heapArray[0] < num)
                    {
                        this.heapArray[0] = num;
                        for (int i = this.currentSize / 2; i >= 0; i--)
                        {
                            this.minHeapify(num, i, this.currentSize);
                        }
                    }
                }
            }
        }

        public void HeapSortForMaxHeap()
        {
            int currentHeapSize = this.currentSize - 1; 
            while (currentHeapSize > 0)
            {
                
                swapNumberAtIndexes(0, currentHeapSize);
                maxHeapify(this.heapArray[currentHeapSize], 0, currentHeapSize);
                currentHeapSize = currentHeapSize - 1;
            }
        }

        public void HeapSortForMinHeap()
        {
            int currentIndex = 1; 
            while (currentIndex < this.currentSize)
            {
                minHeapify(this.heapArray[currentIndex], currentIndex, this.currentSize);
                currentIndex++;
            }
        }

        public void PopFromHeap() 
        {
            if (this.isMaxHeap)
            {
                this.heapArray[0] = int.MinValue;
                for (int i = this.currentSize / 2; i >= 0; i--)
                {
                    this.maxHeapify(this.heapArray[0], i, this.currentSize);
                }
                this.currentSize--;
            }
            else 
            {
                this.heapArray[0] = int.MaxValue;
                for (int i = this.currentSize / 2; i >= 0; i--)
                {
                    this.minHeapify(this.heapArray[0], i, this.currentSize);
                }
                this.currentSize--;
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
                printHeapUtil(i * 2 + 1, level + 1);
                printHeapUtil(i * 2 + 2, level + 1);
            }
        }

        private void swapNumberAtIndexes(int i, int j)
        {
            int temp = this.heapArray[i];
            this.heapArray[i] = this.heapArray[j];
            this.heapArray[j] = temp;
         }

        private void maxHeapify(int num, int currentIndex, int currentHeapSize)
        {
            int left = currentIndex * 2 + 1;
            int right = currentIndex * 2 + 2;
            int largest = currentIndex;; 

            if (left < currentHeapSize && this.heapArray[left] > this.heapArray[largest]) 
            {
                largest = left; 
            }

            if (right < currentHeapSize && this.heapArray[right] > this.heapArray[largest])
            {
                largest = right;
            }

            if (largest != currentIndex)
            {
                int temp = this.heapArray[largest];
                this.heapArray[largest] = this.heapArray[currentIndex];
                this.heapArray[currentIndex] = temp;

                this.maxHeapify(this.heapArray[largest], largest, currentHeapSize);
            }
        }

        private void minHeapify(int num, int currentIndex, int currentHeapSize)
        {
            int left = currentIndex * 2 + 1;
            int right = currentIndex * 2 + 2;
            int smallest = currentIndex; ;

            if (left < currentHeapSize && this.heapArray[left] < this.heapArray[smallest])
            {
                smallest = left;
            }

            if (right < currentHeapSize && this.heapArray[right] < this.heapArray[smallest])
            {
                smallest = right;
            }

            if (smallest != currentIndex)
            {
                int temp = this.heapArray[smallest];
                this.heapArray[smallest] = this.heapArray[currentIndex];
                this.heapArray[currentIndex] = temp;

                this.maxHeapify(this.heapArray[smallest], smallest, currentHeapSize);
            }
        }
    }
}