using System;
using System.Collections.Generic;

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
            tree.AddBSTNode(12);

            Console.WriteLine();
            //tree.printLevelWiseTree(tree.Root);
   //         Console.WriteLine();
   //         Console.WriteLine();
   //         Console.WriteLine("Height of the tree is " + tree.GetTreeHeight(tree.Root));
   //         Console.WriteLine("Is tree balanced :" + TreeProblems.IsTreeBalanced(tree.Root));
   //         Console.WriteLine("Is tree binary search tree :" + TreeProblems.IsTreeBinarySearchTree(tree.Root));
   //         TreeNode node1 = tree.GetNodeWithData(4);
   //         TreeNode node2 = tree.GetNodeWithData(7);
   //         Console.WriteLine("Lowest common ancestor of {0} and {1} ", 
   //                           node1.data, node2.data + 
   //                           " is " + 
   //                           TreeProblems.GetLCA(tree.Root, node1, node2).data);
            
			//Console.WriteLine("Lowest common ancestor of {0} and {1} ",
				  //node1.data, node2 .data +
				  //" is " +
      //            TreeProblems.GetLCAWithParentNodes(tree.Root, node1, node2).data);

      //      Console.WriteLine("Successor of {0} ",
				  //node1.data +
				  //" is " +
            //      TreeProblems.GetInorderSuccessor(tree.Root, node1).data);

            //Console.WriteLine("Populating child counts - ");
            //TreeProblems.CalcluateLeafNodeCounts(tree.Root);

   //         bool shouldContinue = true;
   //         while (shouldContinue)
   //         {
			//	Console.WriteLine(" Enter k ");
   //             string k = Console.ReadLine();
   //             Console.Write("Inorder {0} node ", k ); 
   //             Console.WriteLine( " is " + TreeProblems.FindKthInorderNode(tree.Root, Int32.Parse(k)).data);
   //             Console.WriteLine("Enter false to end or true to continue ");
   //             shouldContinue = Boolean.Parse(Console.ReadLine());
			//}

   //         Tree bitTree = new Tree();
   //         TreeNode root = bitTree.AddNode(1, null, true);
   //         TreeNode B = bitTree.AddNode(0, root, true);
   //         TreeNode I = bitTree.AddNode(1, root, false);

   //         TreeNode C = bitTree.AddNode(0, B, true);
   //         TreeNode F = bitTree.AddNode(1, B, false);

   //         TreeNode D = bitTree.AddNode(0, C, true);
   //         TreeNode E = bitTree.AddNode(1, C, false);

   //         TreeNode G = bitTree.AddNode(1, F, false);

   //         TreeNode H = bitTree.AddNode(0, G, true);

   //         TreeNode J = bitTree.AddNode(0, I, true);
   //         TreeNode O = bitTree.AddNode(0, I, false);
   //         TreeNode P = bitTree.AddNode(0, O, false);

			//TreeNode K = bitTree.AddNode(0, J, false);
            //TreeNode L = bitTree.AddNode(1, K, true); 
            //TreeNode N = bitTree.AddNode(0, K, false);
            //TreeNode M = bitTree.AddNode(1, L, false);

            //bitTree.printLevelWiseTree(bitTree.Root);
            //Console.ReadKey();

            //Console.WriteLine("Sum of all paths from roof to leaves is " + TreeProblems.SumRootToLeafPath(bitTree.Root));

            Console.WriteLine();
            List<TreeNode> inorder = TreeProblems.PrintInorderTraversal(tree.Root);
            Console.ReadKey();


            List<TreeNode> preorder = TreeProblems.GetPreorderList(tree.Root);
            Console.ReadKey();

            TreeNode root = TreeProblems.ConstructTreeFromPreorderAndInorder(inorder, preorder);

            tree.printLevelWiseTree(root);

            Console.ReadKey();
		}
    }
}
