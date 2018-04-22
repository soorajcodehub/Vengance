using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace CrackThat
{
    public static class ArrayProblems
    {

        public static int computeMaxProfit(int[] stockPrices)
        {
            int maxProfit = 0;
            int minPrice = Int32.MaxValue;

            for (int i = 0; i < stockPrices.Length; i++)
            {
                maxProfit = Math.Max(stockPrices[i] - minPrice, maxProfit);
                minPrice = Math.Min(stockPrices[i], minPrice);
            }

            return maxProfit;

        }

        public static double GetMedianOfSortedArrays(int[] array1, int[] array2)
        {
            int m = array1.Length;
            int n = array2.Length;
            int totalItems = (m + n);
            int median = totalItems / 2;
            bool isEven = (totalItems % 2 == 0);
            double resultMedian;
            int i = m - 1;
            int j = n - 1;
            int m2 = -1, m1 = -1;
            int numberOfElementsCompared = 0;

            while (i >= 0 && j >= 0)
            {
                if (array1[i] > array2[j])
                {
                    m2 = array1[i];
                    m1 = array2[j];
                    numberOfElementsCompared++;
                    i--;
                }
                else
                {
                    m2 = array2[j];
                    m1 = array1[i];
                    numberOfElementsCompared++;
                    j--;
                }

                if (isEven && numberOfElementsCompared == median)
                {
                    resultMedian = (m1 + m2) / 2;
                    return resultMedian;
                }
                else if (!isEven && numberOfElementsCompared == median + 1)
                {
                    return m2;
                }
            }

            while (j >= 0)
            {
                m2 = array2[j];
                if (j - 1 >= 0)
                {
                    m1 = array2[j - 1];
                }

                numberOfElementsCompared++;
                if (isEven && numberOfElementsCompared == median)
                {
                    resultMedian = (m1 + m2) / 2;
                    return resultMedian;
                }
                else if (!isEven && numberOfElementsCompared == median + 1)
                {
                    return m2;
                }

                j--;
            }

            while (i >= 0)
            {
                m2 = array1[i];
                if (j - 1 >= 0)
                {
                    m1 = array2[i - 1];
                }

                numberOfElementsCompared++;
                if (isEven && numberOfElementsCompared == median)
                {
                    resultMedian = (m1 + m2) / 2;
                    return resultMedian;
                }
                else if (!isEven && numberOfElementsCompared == median + 1)
                {
                    return m2;
                }

                i--;
            }

            return 0;
        }

        public static double FindMedianOfTwoArrays(int[] arr1, int[] arr2)
        {
            int heapSize = (arr1.Length + arr2.Length) / 2;
            Heap maxHeap = new Heap(heapSize, true);
            Heap minHeap = new Heap(heapSize, false);
            int i = 0, j = 0;
            double median = 0;

            while (i < arr1.Length || j <arr2.Length)
            {
                if (i < arr1.Length)
                {
                    FindMedianOfTwoArraysUtil(arr1[i], ref median, maxHeap, minHeap);
                    i++;
                }
                if (j < arr2.Length)
                {
                    FindMedianOfTwoArraysUtil(arr2[j], ref median, maxHeap, minHeap);
                    j++;
                }
            }

            return median;
        }

        private static void FindMedianOfTwoArraysUtil(int x, ref double median, Heap maxHeap, Heap minHeap)
        {
            if (maxHeap.CurrentSize > minHeap.CurrentSize)
            {
                if (x > median)
                {
                    minHeap.Insert(x);
                }
                else 
                {
                    minHeap.Insert(maxHeap.Root);
                    maxHeap.PopFromHeap();
                    maxHeap.Insert(x);
                }
                median = ((double)maxHeap.Root + (double)minHeap.Root) / 2;
            }
            else if (maxHeap.CurrentSize < minHeap.CurrentSize)
            {
                if (x < median)
                {
                    maxHeap.Insert(x);
                }
                else
                {
                    maxHeap.Insert(minHeap.Root);
                    minHeap.PopFromHeap();
                    minHeap.Insert(x);
                }
                median = ((double)maxHeap.Root + (double)minHeap.Root) / 2;
            }
            else 
            {
                if (x < median)
                {
                    maxHeap.Insert(x);
                }
                else
                {
                    minHeap.Insert(x);
                }
                median = (double)minHeap.Root;
            }
        }

        public static Tuple<int, int> FindTwoSum(int[] array, int target)
        {
            Dictionary<int, int> indexValue = new Dictionary<int, int>();
            for (int i = 0; i < array.Length; i++)
            {
                int numToFind = target - array[i];
                if (indexValue.ContainsKey(numToFind))
                {
                    return new Tuple<int, int>(i, indexValue[numToFind]);
                }
                else
                {
                    indexValue.Add(array[i], i);
                }
            }

            return null;
        }

        public static int computeMaxProfitForTwoStockSell(int[] stockPrices)
        {
            int maxProfit = 0;
            int minPrice = Int32.MaxValue;

            ArrayList maxProfits = new ArrayList();


            for (int i = 0; i < stockPrices.Length; i++)
            {
                maxProfit = Math.Max(stockPrices[i] - minPrice, maxProfit);
                minPrice = Math.Min(stockPrices[i], minPrice);
                maxProfits.Add(maxProfit);
            }


            int maxPrice = Int32.MinValue;
            for (int j = stockPrices.Length - 1; j > 0; j--)
            {
                maxPrice = Math.Max(maxPrice, stockPrices[j]);
                int tempProfit = maxPrice - stockPrices[j];
                maxProfit = Math.Max(maxProfit, tempProfit + (int)maxProfits[j - 1]);
            }

            return maxProfit;
        }

        public static int GetMaxSumSubArray(int[] array)
        {
            int currentMax = array[0];
            int maxSumSoFar = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                currentMax = Math.Max(currentMax + array[i], array[i]);
                maxSumSoFar = Math.Max(currentMax, maxSumSoFar);
            }

            return maxSumSoFar;
        }

        #region Searching

        private enum Ordering { larger, smaller, equal };

        private static Ordering CompareNumbers(double num1, double num2)
        {
            double epsillon = 0.00001;
            double diff = (num1 - num2) / num2;
            return diff < -epsillon ? Ordering.smaller :
                                    (diff > epsillon) ?
                                              Ordering.larger :
                                              Ordering.equal;
        }

        public static int GetFirstIndexInSortedArray(int[] array, int element)
        {
            return _GetFirstIndexInsortedArray(array, element, 0, array.Length - 1);
        }

        private static int _GetFirstIndexInsortedArray(int[] array, int element, int low, int high)
        {
            if (low > high)
            {
                return -1;
            }

            if (low == high)
            {
                return low;
            }

            int mid = (high - low) / 2 + low;

            if (array[mid] == element)
            {
                high = mid;
            }
            else if (array[mid] < element)
            {
                low = mid + 1;
            }
            else if (array[mid] > element)
            {
                high = mid - 1;
            }

            return _GetFirstIndexInsortedArray(array, element, low, high);
        }

        public static int GetEntryMatchingIndex(int[] array, int eleemnt)
        {
            return _GetEntryMatchingIndex(array, eleemnt, 0, array.Length - 1);
        }

        private static int _GetEntryMatchingIndex(int[] array, int element, int low, int high)
        {
            if (high < low)
            {
                return -1;
            }

            int mid = (high - low) / 2 + low;

            if (element == mid)
            {
                return mid;
            }
            else if (element > mid)
            {
                low = mid + 1;
            }
            else if (element < mid)
            {
                high = mid - 1;
            }

            return _GetEntryMatchingIndex(array, element, low, high);
        }

        public static double CalculateSquareRoot(double number)
        {
            double low;
            double mid;
            double high;
            if (number < 1)
            {
                low = number;
                high = 1;
            }
            else
            {
                low = 1;
                high = number;
            }

            while (low < high)
            {
                mid = 0.5 * (high - low) + low;
                double midSquared = mid * mid;
                Ordering ordering = CompareNumbers(number, midSquared);
                if (ordering == Ordering.equal)
                {
                    return mid;
                }
                else if (ordering == Ordering.larger)
                {
                    low = mid;
                }
                else
                {
                    high = mid;
                }
            }

            return low;
        }

        #endregion

        #region dynamic

        public static int FindMinimumNumberOfCoins(int[] coinValues, int amount)
        {
            /* recursive equation ->
             * MinCoinsNeeded(amount) = Min for (i in {0, n}) (MinCoinsNeeded(amount - coins[i]))
             */

            int[] minCoinsNeededForAmount = new int[amount + 1];
            int[] currentCoins = new int[coinValues.Length];

            minCoinsNeededForAmount[0] = 0;

            for (int amt = 1; amt <= amount; amt++)
            {
                for (int j = 0; j < currentCoins.Length; j++)
                {
                    currentCoins[j] = -1;
                }

                for (int i = 0; i < coinValues.Length; i++)
                {
                    if (coinValues[i] <= amt)
                    {
                        currentCoins[i] = minCoinsNeededForAmount[amt - coinValues[i]] + 1;
                    }
                }

                minCoinsNeededForAmount[amt] = -1;
                for (int j = 0; j < currentCoins.Length; j++)
                {
                    if (currentCoins[j] > 0 &&
                        (
                            minCoinsNeededForAmount[amt] == -1 ||
                            minCoinsNeededForAmount[amt] > currentCoins[j]
                        )
                       )
                    {
                        minCoinsNeededForAmount[amt] = currentCoins[j];
                    }
                }
            }

            return minCoinsNeededForAmount[amount];

        }

        public static int FindRainWaterTrappedInArray(int[] array)
        {
            int water = 0;
            int length = array.Length;
            int[] leftWalls = new int[length];
            int[] rightWalls = new int[length];

            leftWalls[0] = array[0];
            rightWalls[array.Length - 1] = array[length - 1];

            for (int i = 1; i < array.Length; i++)
            {
                leftWalls[i] = Math.Max(leftWalls[i - 1], array[i]);
            }

            for (int j = array.Length - 2; j >= 0; j--)
            {
                rightWalls[j] = Math.Max(rightWalls[j + 1], array[j]);
            }

            for (int k = 0; k < array.Length; k++)
            {
                water = water + Math.Min(leftWalls[k], rightWalls[k]) - array[k];

            }

            return water;
        }

        public static int FindRainWater(int[] array)
        {
            int water = 0;
            int leftMax = 0;
            int rightMax = 0;

            int leftWallPointer = 0;
            int rightWallPointer = array.Length - 1;

            while (leftWallPointer < rightWallPointer)
            {

                if (array[leftWallPointer] < array[rightWallPointer])
                {
                    if (leftMax < array[leftWallPointer])
                    {
                        leftMax = array[leftWallPointer];
                    }
                    else
                    {
                        water = water + leftMax - array[leftWallPointer];
                    }

                    leftWallPointer++;
                }
                else
                {
                    if (rightMax < array[rightWallPointer])
                    {
                        rightMax = array[rightWallPointer];
                    }
                    else
                    {
                        water = water + rightMax - array[rightWallPointer];
                    }

                    rightWallPointer--;
                }
            }

            return water;
        }
                
        #endregion

        #region trickyNonsense

        public static void PrintList<T>(List<T> list)
        {
            if (list == null)
            {
                Console.WriteLine("list is null");
                return;
            }

            Console.WriteLine("***** Printing List *********");

            foreach(T element in list)
            {
                Console.Write(" " + element.ToString());
            }
            Console.WriteLine();
            Console.WriteLine("***** Printing List *********");
        }

        public static void PrintTupleList(List<Tuple<int, int>> pairs)
        {
            Console.WriteLine("***** Printing List *********");

            foreach(Tuple<int, int> pair in pairs)
            {
                Console.WriteLine(pair.Item1 + "==>" + pair.Item2);
            }

            Console.WriteLine("***** Printing List *********");
        }

        public static List<int> GetMaxSubArrayOfFibonacciNumbers(int [] a)
        {
            int max = Int32.MinValue;

            for (int j = 0; j < a.Length; j++)
            {
                if (a[j] > max)
                {
                    max = a[j];
                }
            }

            HashSet<int> numberHash = new HashSet<int>();

            int i = 0;
            numberHash.Add(i);
            numberHash.Add(i + 1);
            int current = i + 1;
            int previous = i;
            int temp = previous;
            while ( i < max)
            {
                temp = current;
                current = current + previous;
                previous = temp;
                numberHash.Add(current);
                i = current;
                
            }

            List<int> result = new List<int>();

            for (int k = 0; k < a.Length; k++)
            {
                if (numberHash.Contains(a[k]))
                {
                    result.Add(a[k]);   
                }
            }

            return result;
        }

        public static void PrintMatrix(int [,] a)
        {
            Console.WriteLine("*****************");
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++ )
                {
                    Console.Write(" " + a[i,j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("*****************");
        }

        public static List<Tuple<int, int>> GetPairsWithKDifference(int [] a, int k)
        {
            HashSet<int> lookup = new HashSet<int>();
            List<Tuple<int, int>> pairs = new List<Tuple<int, int>>();

            for (int i = 0; i < a.Length; i++)
            {
                lookup.Add(a[i]);
            }

            for (int j = 0; j < a.Length; j ++)
            {
                if (lookup.Contains(a[j] + k))
                {
                    pairs.Add(new Tuple<int, int>(a[j], a[j] + k));
                }
            }

            return pairs;
        }

        public static int[,] rotateMatrix(int[,] a, bool counterClokwise)
        {
            int rows = a.GetLength(0);
            int cols = a.GetLength(1);

            if (!counterClokwise)
            {
                reverseRows(ref a);
            }
            else 
            {
                reverseColums(ref a);
            }

            PrintMatrix(a);
            for (int i = 0; i < rows; i++)
            {
                for (int j = i + 1; j < cols; j++)
                {
                    int temp = a[i, j];
                    a[i, j] = a[j, i];
                    a[j, i] = temp;
                }
            }

            return a;
        }

        private static void reverseRows(ref int[,] a)
        {
            int s = 0;
            int e = a.GetLength(0) - 1;
            int cols = a.GetLength(1);

            while (s < e)
            {
                for (int c = 0; c < cols; c++)
                {
                    int temp = a[s, c];
                    a[s, c] = a[e, c];
                    a[e, c] = temp;
                }

                s++;
                e--;
            }
        }


        private static void reverseColums(ref int[,] a)
        {
            int s = 0;
            int e = a.GetLength(1) - 1;
            int rows = a.GetLength(0);

            while (s < e)
            {
                for (int r = 0; r < rows; r++)
                {
                    int temp = a[r, s];
                    a[r, s] = a[r, e];
                    a[r, e] = temp;
                }

                s++;
                e--;
            }
        }

        public static bool DoesThreePairExist(int [] array, int sum)
        {
            HashSet<int> lookup = new HashSet<int>();
            for (int i = 0; i < array.Length; i ++)
            {
                lookup.Add(array[i]);
            }

            for (int k = 0; k < array.Length; k++)
            {
                int twoSum = sum - array[k];

                for (int m = k + 1; m < array.Length; m++)
                {
                    if (lookup.Contains(twoSum - array[m]))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

#endregion
    }
}
