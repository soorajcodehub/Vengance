using System;
using System.Collections;
using System.Collections.Generic;

public class BackTrack 
{
    public int[,] GetQueenConfiguration(int numberOfQueens)
    {
        int[,] chessBoard = new int[numberOfQueens, numberOfQueens];
        if (_isQueenConfigValid(ref chessBoard, 0))
            System.Console.WriteLine("Configuration is Valid");
        else
            System.Console.WriteLine("Configuration is not Valid");

        return chessBoard;
    }

    public void PrintQueensonChessBoard(int [,] chessBoard)
    {
		int rows = chessBoard.GetLength(0);
		int columns = chessBoard.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                System.Console.Write(" " + chessBoard[i, j]);
            }

            System.Console.WriteLine(" ");
        }
        
    }

    public void PrintArraySubsets(int [] array, int targetSum)
    {
        int [] subSumArray = new int[array.Length];
        this._printArraySubsets(
            array,
            subSumArray,
            0,
            0,
            targetSum,
            0
        );
    }

    public void printLettersForPhoneNumber(int [] phoneNumber)
    {
        Dictionary<int, string> phoneWords = new Dictionary<int, string>();
        phoneWords.Add(0, "");
        phoneWords.Add(1, "");
        phoneWords.Add(2, "abc");
        phoneWords.Add(3, "def");
        phoneWords.Add(4, "ghi");
        phoneWords.Add(5, "jkl");
        phoneWords.Add(6, "mno");
        phoneWords.Add(7, "pqrs");
        phoneWords.Add(8, "tuv");
        phoneWords.Add(9, "wxyz");

        char[] outputwords = new char[8];

        _printPhoneNumberUtil(phoneNumber,
                                   outputwords,
                                   0,
                                   phoneWords
                                  );
    }

    public bool CanGraphBeColoredWithNColors(int [,] graph, int colors)
    {
        return false;
    }

    private void _printPhoneNumberUtil(
        int[] phoneNumber, 
        char[] outputWords, 
        int indexOfDialedDigit, 
        Dictionary<int, string> phoneWords)
    {
        if (indexOfDialedDigit == phoneNumber.Length)
        {
            for (int i = 0; i < indexOfDialedDigit; i++)
            {
                Console.Write(outputWords[i]);
                Console.Write(" ");
            }

            Console.WriteLine();
            return;
        }

        int currentDialiedNumber = phoneNumber[indexOfDialedDigit];

        for (int i = 0; i < phoneWords[currentDialiedNumber].Length; i++ )
        {
            outputWords[indexOfDialedDigit] = phoneWords[currentDialiedNumber][i];
            _printPhoneNumberUtil(phoneNumber, 
                                  outputWords,
                                  indexOfDialedDigit + 1,
                                  phoneWords);
            
			if (phoneNumber[indexOfDialedDigit] == 1 || phoneNumber[indexOfDialedDigit] == 0)
			{
				return;
			}
        }
    }

    private bool _isSafe(int c, int currentVertex, int[,] graph, int[] currentVertexColors)
    {
        for (int i = 0; i < graph.GetLength(0); i ++ )
        {
            if (graph[currentVertex, i] != 0 && currentVertexColors[i] == c)
                return false;
        }

        return true;      
    }

    private bool _graphColoringUtil(int [,] graph, int currentVertex, int [] currentVertexColors, int colors)
    {
        if (currentVertex == graph.GetLength(0))
        {
            return true;
        }

        for (int c = 0; c < colors; c++)
        {
            if (this._isSafe(c, currentVertex, graph, currentVertexColors))
            {
                currentVertexColors[currentVertex] = c;
                if (_graphColoringUtil(graph, currentVertex + 1, currentVertexColors, colors))
                {
                    return true;
                }
                currentVertexColors[currentVertex] = 0;
            }
        }

        return false;
    }

    private void _printArray(int[] array, int length)
    {
        for (int i = 0; i < length; i ++)
        {
            System.Console.Write(array[i]);
            System.Console.Write(" ");
        }
    }

    // depth first recursion search and breadth first along the array
    private void _printArraySubsets(
        int [] array, 
        int[] subSumArray, 
        int subSumArrayCurrentIndex, 
        int arrayCurrentIndex,
        int targetSum, 
        int currentSum)
    {
        if (targetSum == currentSum)
        {
            _printArray(subSumArray, subSumArrayCurrentIndex);
            System.Console.WriteLine();

            if (arrayCurrentIndex + 1 < array.Length &&
                currentSum - array[arrayCurrentIndex] + array[arrayCurrentIndex + 1] <= targetSum)
            {
				_printArraySubsets(
                	array,
                	subSumArray,
                	subSumArrayCurrentIndex + 1,
                	arrayCurrentIndex + 1,
                	targetSum,
                	currentSum - array[arrayCurrentIndex]);
            }

            return;
        }
        else 
        {
            if (arrayCurrentIndex < array.Length && 
                currentSum + array[arrayCurrentIndex] <= targetSum)
            {
                for (int i = arrayCurrentIndex; i < array.Length; i ++)
                {
                    subSumArray[subSumArrayCurrentIndex] = array[i];

                    if (currentSum + array[i] <= targetSum)
                    _printArraySubsets(
                        array,
                        subSumArray,
                        subSumArrayCurrentIndex + 1,
                        i + 1,
                        targetSum,
                        currentSum + array[arrayCurrentIndex]
                    );
                }
            }
        }  
    }

    private bool _isQueenConfigValid (ref int[,] chessBoard, int column)
    {
        int rows = chessBoard.GetLength(0);
        int columns = chessBoard.GetLength(1);

        if (column >= columns)
            return true;

        for (int i = 0; i < rows; i ++)
        {
            if (_canPlaceQueen(chessBoard, i, column))
            {
                chessBoard[i, column] = 1;

                if (_isQueenConfigValid(ref chessBoard, column + 1))
                {
                    return true;
                }

                chessBoard[i, column] = 0;
            }
        }
        return false;
    }

    private bool _canPlaceQueen(int[,] chessBoard, int positionX, int positionY)
    {
        for (int i = 0; i < positionY; i++)
        {
            if (chessBoard[positionX, i] == 1)
            {
                return false;
            }
        }

        for (int i = positionX, j = positionY; i >= 0 && j >= 0; i--, j--)
        {
            if (chessBoard[i, j] == 1)
            {
                return false;
            }
        }


        for (int i = positionX, j = positionY; i < chessBoard.GetLength(0) && j >= 0; i ++, j --)

        {
            if (chessBoard[i, j] == 1)
            {
                return false;
            }
        }

        return true;
    }
}