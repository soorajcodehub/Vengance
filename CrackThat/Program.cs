using System;

namespace CrackThat
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(" Vengace starts with trees");
            //BackTrack btrack = new BackTrack();
            //int[,] chessBoard = btrack.GetQueenConfiguration(8);
            //btrack.PrintQueensonChessBoard(chessBoard);
            //Console.ReadKey();


            //      int [] weights = { 15, 22, 14, 26, 32, 9, 16, 8 };
            //int target = 53;
            //Array.Sort(weights);
            //btrack.PrintArraySubsets(weights, target);
            //Console.ReadKey();

            //int[] dialedNumber = { 2, 3, 4, 5 };
            //btrack.printLettersForPhoneNumber(dialedNumber);;
            //Console.ReadKey();


            //Console.WriteLine( "Enter the size of the matrix to generate : " );
            //int n = Convert.ToInt32(Console.ReadLine());
            //mProb.generateSpiralMatrix(n);

            //Console.WriteLine(PrimitveProblems.GetClosestNumberByWeight(0));
            //Console.ReadKey();

            //int[] stockPrices = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            //Console.WriteLine(ArrayProblems.computeMaxProfit(stockPrices));
            //Console.ReadKey();

            //int[] stockPrices2 = { 12, 11, 13, 9, 12, 8, 14, 13, 15 };
            //Console.WriteLine(ArrayProblems.computeMaxProfitForTwoStockSell(stockPrices2));
            //Console.ReadKey();

            //Console.WriteLine(SortingAndSearchingProblems.FindNearestLargeSquareRoot(16));

            Tree tree = new Tree();
            tree.AddBSTNode(7);
            tree.AddBSTNode(4);
            tree.AddBSTNode(10);
            tree.AddBSTNode(5);
            tree.AddBSTNode(6);
            tree.AddBSTNode(3);
            tree.AddBSTNode(9);
            tree.AddBSTNode(8);
            tree.AddNode(12, true);

            Console.WriteLine();
            tree.printLevelWiseTree(tree.Root);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Height of the tree is " + tree.GetTreeHeight(tree.Root));
            Console.WriteLine("Is tree balanced :" + TreeProblems.IsTreeBalanced(tree.Root));
            Console.WriteLine("Is tree binary search tree :" + TreeProblems.IsTreeBinarySearchTree(tree.Root));
            Console.ReadKey();

        }
    }
}
