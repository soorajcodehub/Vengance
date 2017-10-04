using System;
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
    }
}
