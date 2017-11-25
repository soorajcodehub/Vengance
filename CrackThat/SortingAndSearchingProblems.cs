using System;
using System.Collections.Generic;

namespace CrackThat
{
    public class SortingAndSearchingProblems
    {
        public SortingAndSearchingProblems()
        {
        }

        public static int FindNearestLargeSquareRoot(int number)
        {
            int left = 0;
            int right = number;

            while (left <= right)
            {
                int mid = left + ((right - left) / 2);
                int midSquare = mid * mid;
                if ( midSquare <= number)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return left - 1;
        }
         
        public static int search2DArray(int[,] array, int number)
        {
            int rows = array.Length;
            int columns = array.GetLength(1);
            int row = 0; int column = columns - 1;
            while (row < rows && row >= 0 && column >= 0 && column < columns)
            {
                if (number > array[0, column]) 
                {
                    row = row + 1;
                }
                else if (number < array[0, column])
                {
                    column = column - 1;
                }
                else 
                {
                    return number;
                }
            }

            return -1;
        }

        public static List<int> FindIntersectionOfTwoArrays(int [] array1, int [] array2)
        {

            if (array1 == null || array2 == null) 
            {
                return null;   
            }
            else if (array1.Length == 0 || array2.Length == 0) 
            {
                return new List<int>();
            }

            List<int> result = new List<int>();

            Array.Sort(array1);
            Array.Sort(array2);

            int i = 0;
            int j = 0;

            while (i < array1.Length && j < array2.Length)
            {
                if (array1[i] == array2[j])
                {
                    result.Add(array1[i]);
                    i++;
                    j++;
                }
                else if(array1[i] < array2[j])
                {
                    i++;
                }
                else
                {
                    j++;
                }  
            }

            return result;
        }
    }
}
