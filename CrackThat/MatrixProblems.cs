using System;
namespace CrackThat
{
    public class MatrixProblems
    {
        public MatrixProblems()
        {

        }

        public void generateSpiralMatrix(int n)
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
                while (i < totalElements && !this.CanGoRight(midRow, midCol, a, n))
                {
                    this.goAccordingToLastDirection(direction, ref midRow, ref midCol, ref a);
                    i++;
                }

                if (this.CanGoRight(midRow, midCol, a, n))
                {
					this.goRight(ref a, ref midRow, ref midCol);
					direction = "right";
					i++;
                }

                // go down --increment row
                while (i < totalElements && !this.CanGoBottom(midRow, midCol, a,  n))
                {
                    this.goAccordingToLastDirection(direction, ref midRow, ref midCol, ref a);
                    i++;
                }

                if (this.CanGoBottom(midRow, midCol, a, n))
                {
					this.goBottom(ref a, ref midRow, ref midCol);
					direction = "bottom";
					i++;   
                }

                // go left -- decrement column
                while (i < totalElements && !this.CanGoLeft(midRow, midCol, a))
                {
					this.goAccordingToLastDirection(direction, ref midRow, ref midCol, ref a);
                    i++;
                }

                if (this.CanGoLeft(midRow, midCol, a))
                {
                    this.goLeft(ref a, ref midRow, ref midCol);
                    direction = "left";
                    i++;
                }

                // go up decrement row
                while (i < totalElements && !this.CanGoTOp(midRow, midCol, a))
                {
                    this.goAccordingToLastDirection(direction, ref midRow, ref midCol, ref a);
                    i++;
                }

                if (this.CanGoTOp(midRow, midCol, a))
                {
                    this.goTop(ref a, ref midRow, ref midCol);
                    direction = "top";
                    i++;
                }
            }

            this.printMatrix(a);
        }

        private void printMatrix(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write(a[i,j]);
                }
                Console.WriteLine();
            }
        }
  
        private bool CanGoRight(int row, int col, int [,] a, int n)
        {
            return (col + 1  < n && a[row, col + 1] == 0);   
        }

		private bool CanGoLeft(int row, int col, int[,] a)
		{
			return (col - 1 >= 0 && a[row, col - 1] == 0);
		}

		private bool CanGoTOp(int row, int col, int[,] a)
		{
			return (row - 1 >= 0 && a[row - 1, col] == 0);
		}

		private bool CanGoBottom(int row, int col, int[,] a, int n)
		{
			return (row + 1 < n && a[row + 1, col] == 0);
		}
                    
        private void goAccordingToLastDirection(string lastDirection, ref int row, ref int col, ref int [,] a)
        {
            switch(lastDirection)
            {
                case "right" : 
                    this.goRight(ref a, ref row, ref col);
                    break;
                case "left" :
                    this.goLeft(ref a, ref row, ref col);
                    break;
                case "top" :
                    this.goTop(ref a, ref row, ref col);
                    break;
                case "bottom" :
                    this.goBottom(ref a, ref row, ref col);
                    break;
            }
        }

        private void goTop(ref int[,] a, ref int row, ref int col)
        {
            if (row - 1 >= 0)
            {
				a[row - 1, col] = a[row, col] + 1;
				row = row - 1;   
            }
        }

        private void goRight(ref int[,] a, ref int row, ref int col)
        {
            if (col + 1 < a.GetLength(1))
            {
				a[row, col + 1] = a[row, col] + 1;
				col = col + 1;
            }
        }

        private void goBottom(ref int[,] a, ref int row, ref int col)
        {
            if (row + 1 < a.GetLength(0))
            {
				a[row + 1, col] = a[row, col] + 1;
				row = row + 1;   
            }
        }

        private void goLeft(ref int[,] a, ref int row, ref int col)
        {
            if (col -  1 >= 0)
            {
				a[row, col - 1] = a[row, col] + 1;
				col = col - 1;   
            }
        }

	}
}
