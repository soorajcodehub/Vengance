using System;
using System.Collections.Generic;
namespace CrackThat
{
    public class MatrixProblems
    {
        public MatrixProblems()
        {

        }

        public static void generateSpiralMatrix(int n)
        {
            int midRow, midCol;
            midRow = midCol = (n % 2 == 0) ? n / 2 - 1 : n / 2;

            int[,] a = new int[n, n];

            string direction = "right";

            a[midRow, midCol] = 1;
            int i = 0;
            double totalElements = Math.Pow(n, 2);
            while (i < totalElements)
            {
                // Go right -increment col
                while (i < totalElements && !CanGoRight(midRow, midCol, a, n))
                {
                   goAccordingToLastDirection(direction, ref midRow, ref midCol, ref a);
                    i++;
                }

                if (CanGoRight(midRow, midCol, a, n))
                {
					goRight(ref a, ref midRow, ref midCol);
					direction = "right";
					i++;
                }

                // go down --increment row
                while (i < totalElements && !CanGoBottom(midRow, midCol, a,  n))
                {
                    goAccordingToLastDirection(direction, ref midRow, ref midCol, ref a);
                    i++;
                }

                if (CanGoBottom(midRow, midCol, a, n))
                {
					goBottom(ref a, ref midRow, ref midCol);
					direction = "bottom";
					i++;   
                }

                // go left -- decrement column
                while (i < totalElements && !CanGoLeft(midRow, midCol, a))
                {
					goAccordingToLastDirection(direction, ref midRow, ref midCol, ref a);
                    i++;
                }

                if (CanGoLeft(midRow, midCol, a))
                {
                    goLeft(ref a, ref midRow, ref midCol);
                    direction = "left";
                    i++;
                }

                // go up decrement row
                while (i < totalElements && !CanGoTOp(midRow, midCol, a))
                {
                    goAccordingToLastDirection(direction, ref midRow, ref midCol, ref a);
                    i++;
                }

                if (CanGoTOp(midRow, midCol, a))
                {
                    goTop(ref a, ref midRow, ref midCol);
                    direction = "top";
                    i++;
                }
            }

            printMatrix(a);
        }

        private static void printMatrix(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write(a[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
  
        private static bool CanGoRight(int row, int col, int [,] a, int n)
        {
            return (col + 1  < n && a[row, col + 1] == 0);   
        }

		private static  bool CanGoLeft(int row, int col, int[,] a)
		{
			return (col - 1 >= 0 && a[row, col - 1] == 0);
		}

		private static  bool CanGoTOp(int row, int col, int[,] a)
		{
			return (row - 1 >= 0 && a[row - 1, col] == 0);
		}

		private static bool CanGoBottom(int row, int col, int[,] a, int n)
		{
			return (row + 1 < n && a[row + 1, col] == 0);
		}
                    
        private static void goAccordingToLastDirection(string lastDirection, ref int row, ref int col, ref int [,] a)
        {
            switch(lastDirection)
            {
                case "right" : 
                    goRight(ref a, ref row, ref col);
                    break;
                case "left" :
                    goLeft(ref a, ref row, ref col);
                    break;
                case "top" :
                    goTop(ref a, ref row, ref col);
                    break;
                case "bottom" :
                    goBottom(ref a, ref row, ref col);
                    break;
            }
        }

        private static void goTop(ref int[,] a, ref int row, ref int col)
        {
            if (row - 1 >= 0)
            {
				a[row - 1, col] = a[row, col] + 1;
				row = row - 1;   
            }
        }

        private static void goRight(ref int[,] a, ref int row, ref int col)
        {
            if (col + 1 < a.GetLength(1))
            {
				a[row, col + 1] = a[row, col] + 1;
				col = col + 1;
            }
        }

        private static void goBottom(ref int[,] a, ref int row, ref int col)
        {
            if (row + 1 < a.GetLength(0))
            {
				a[row + 1, col] = a[row, col] + 1;
				row = row + 1;   
            }
        }

        private static void goLeft(ref int[,] a, ref int row, ref int col)
        {
            if (col -  1 >= 0)
            {
				a[row, col - 1] = a[row, col] + 1;
				col = col - 1;   
            }
        }

        public static double FindAreaMaxIsland(int [,] matrix)
        {
            int[] leftBoundary;
            int [] rightBoundary;
            int[] height;

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int currLeft = 0;
            int currRight = cols;

            leftBoundary = new int[cols];
            rightBoundary = new int[cols];
            height = new int[cols];
            double maxArea = 0;

            populateArray(leftBoundary, 0);
            populateArray(rightBoundary, cols);
            populateArray(height, 0);

            for (int row = 0; row < rows; row ++)
            {
                currLeft = 0;
                currRight = cols;
                maxArea = 0;

                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == 1)
                    {
                        leftBoundary[col] = Math.Max(leftBoundary[col], currLeft);
                        height[col] = height[col] + 1;
                    }
                    else
                    {
                        currLeft = col + 1;
                    }
                }

                for (int col = cols - 1; col >= 0; col --)
                {
					if (matrix[row, col] == 1)
					{
                        rightBoundary[col] = Math.Min(rightBoundary[col], currRight);
					}
					else
					{
                        currRight = col;
					}
                }

                for (int col = 0; col < cols; col ++)
                {
                    if (matrix[row, col] == 1)
                    {
                        maxArea = Math.Max(
                            maxArea, 
                            (rightBoundary[col] - leftBoundary[col]) * height[col]
                        );
                    }
                }
            }

            return maxArea;
        }

        public static int FindNumberOfIslands(int [,] matrix)
        {
            int count = 0;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            bool[,] visited = new bool[rows, cols];

			int [] rowNbr = { -1, -1, -1, 0, 0, 1, 1, 1 };
			int [] colNbr = { -1, 0, 1, -1, 1, -1, 0, 1 };

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 1 && 
                        !visited[i,j]
                       )
                    {
                        DFSMatrix(matrix, visited, i, j, rowNbr, colNbr);
						count++;
                    }
                }
            }

            return count;
        }

        public static List<string> WordBoggle(char[,] matrix, List<string> strings)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            bool[,] visited = new bool[rows, cols];
            List<string> resultStrings = null;

            foreach (String str in strings)
            {
                Tuple<int, int> rowCol = GetCoordinates(str[0], matrix);

                if (rowCol == null)
                {
                    continue;
                }
                    

                int row = rowCol.Item1;
                int col = rowCol.Item2;

                visited[row, col] = true;

                int j = 1;
                for (j = 1; j < str.Length; j++)
                {
                    Tuple<int, int> nextRowCol = getNextEligibleCoordinate(str[j], matrix, row, col, ref visited);

                    if (nextRowCol != null)
                    {
                        row = nextRowCol.Item1;
                        col = nextRowCol.Item2;
                    }
                    else
                    {
                        break;
                    }
                }

                if ( j >= str.Length)
                {
                    if (resultStrings == null)
                    {
                        resultStrings  = new List<string>();
                    }
                    resultStrings.Add(str);
                }

                reInitializeVisited(ref visited, rows, cols);
            }

            return resultStrings;

        }

        private static void reInitializeVisited (ref bool [,] visited, int rows, int cols)
        {
            for (int i = 0; i < rows; i ++)
            {
                for (int j = 0; j < cols; j ++)
                {
                    visited[i,j]  = false;
                }
            }
        }
        private static Tuple<int, int> getNextEligibleCoordinate(char a, char [,] matrix, int row, int col, ref bool[,] visited)
        {
            if (isSafeToVisit(row -1, col, matrix, visited) && matrix[row -1, col] == a)
            {
                visited[row - 1, col] = true;
                return new Tuple<int, int>(row - 1, col);
            }
            if (isSafeToVisit(row, col -1, matrix, visited) && matrix[row, col -1] == a)
            {
                visited[row, col -1] = true;
                return new Tuple<int, int>(row, col -1);
            }
            if (isSafeToVisit(row  + 1, col, matrix, visited) && matrix[row + 1, col] == a)
            {
                visited[row + 1, col] = true;
                return new Tuple<int, int>(row + 1, col);
            }
            if (isSafeToVisit(row, col + 1, matrix, visited) && matrix[row, col + 1] == a)
            {
                visited[row, col + 1] = true;
                return new Tuple<int, int>(row, col + 1);
            }
            if (isSafeToVisit(row - 1, col + 1, matrix, visited) && matrix[row - 1, col + 1] == a)
            {
                visited[row - 1, col + 1] = true;
                return new Tuple<int, int>(row - 1, col + 1);
            }
            if (isSafeToVisit(row + 1, col  - 1, matrix, visited) && matrix[row + 1, col - 1] == a)
            {
                visited[row + 1, col - 1] = true;
                return new Tuple<int, int>(row + 1, col - 1);
            }
            if (isSafeToVisit(row - 1, col - 1, matrix, visited) && matrix[row - 1, col - 1] == a)
            {
                visited[row - 1, col - 1] = true;
                return new Tuple<int, int>(row - 1, col - 1);
            }
            if (isSafeToVisit(row + 1, col + 1, matrix, visited) && matrix[row + 1, col + 1] == a)
            {
                visited[row + 1, col + 1] = true;
                return new Tuple<int, int>(row + 1, col + 1);
            }

            return null;
        }

        private static Tuple<int, int> GetCoordinates(char a, char[,] matrix)
        {
            Tuple<int, int> tuple = null;
            for (int i = 0; i < matrix.GetLength(0); i ++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == a)
                    {
                        tuple = new Tuple<int, int>(i, j);
                        return tuple;
                    }
                }
            }

            return tuple;
        }

        private static void DFSMatrix(int [,] matrix, 
                                     bool [,] visited, 
                                     int row, 
                                     int col, 
                                     int [] rowNbrs, 
                                     int [] colNbrs)
        {
            if(isSafeToVisit(row, col, matrix, visited))
            {
                visited[row, col] = true;
                for (int i = 0; i < rowNbrs.Length; i++)
                {
                    DFSMatrix(matrix, visited, row + rowNbrs[i], col + colNbrs[i], rowNbrs, colNbrs);
                }
            }
        }


        private static bool isSafeToVisit(int row, int col, int [,] matrix, bool [,] visited)
        {
            if ( row >= 0 && 
                row < matrix.GetLength(0) && 
                col >= 0 && 
                col < matrix.GetLength(1) && 
                !visited[row, col] &&
                matrix[row, col] == 1
              )
            {
                return true;
            }

            return false;
        }

        private static bool isSafeToVisit(int row, int col, char[,] matrix, bool[,] visited)
        {
            if (row >= 0 &&
                row < matrix.GetLength(0) &&
                col >= 0 &&
                col < matrix.GetLength(1) &&
                !visited[row, col]
              )
            {
                return true;
            }

            return false;
        }

        private static void populateArray(int[] array, int fillValue)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = fillValue;
            }
        }
	}
}
