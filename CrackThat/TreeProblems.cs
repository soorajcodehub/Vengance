using System;
using System.Collections.Generic;
namespace CrackThat
{
    public class TreeProblems
    {
        public TreeProblems()
        {
        }

        public static bool IsTreeBalanced(TreeNode root)
        {
            balanceResult result = TreeProblems.isTreeBalanacedUtil(root);
            return result.isBalanced;
        }

        public static TreeNode GetInorderSuccessor(TreeNode root, TreeNode node)
        {
            if (node.right != null)
            {
                return TreeProblems._findLeftMostNode(node);
            }

            TreeNode parent = node.parent;

            while (parent != null && parent.right == node)
            {
                node = parent;
                parent = node.parent;
            }

            return node;

        }

        public static List<TreeNode> PrintInorderTraversal(TreeNode node)
        {
            bool isLeftSubTreeDone = false;
            List<TreeNode> inorder = new List<TreeNode>();

            while (node != null)
            {
                // traverse left subtree
                while (node.left != null && !isLeftSubTreeDone)
                {
                    node = node.left;
                }

                // print node
                Console.WriteLine(node.data);
                inorder.Add(node);

                // now travers right tee
                if (node.right != null)
                {
                    node = node.right;
                    isLeftSubTreeDone = false;
                }
                // if right tree does not exist go back to parent, mark this left subtree done.
                else if (node.parent.left == node)
                {
                    node = node.parent;
                    isLeftSubTreeDone = true;
                }

                // if right tree does not exist and current node is right child
                // go to paent of the curent leftsubtree
                // mark this left subtree done.
                else
                {
                    while (node.parent != null && node.parent.left != node)
                    {
                        node = node.parent;
                    }

                    node = node.parent;
                    isLeftSubTreeDone = true;
                }
            }

            return inorder;
        }

        public static List<TreeNode> GetPreorderList(TreeNode root)
        {
            Stack<TreeNode> nodeStack = new Stack<TreeNode>();
            TreeNode node = root;
            nodeStack.Push(node);
            List<TreeNode> preoder = new List<TreeNode>();

            while (nodeStack.Count > 0)
            {
                TreeNode poppedNode = nodeStack.Pop();
                Console.WriteLine(poppedNode.data);
                preoder.Add(poppedNode);
                if (poppedNode.right != null)
                {
                    nodeStack.Push(poppedNode.right);
                }
                if (poppedNode.left != null)
                {
                    nodeStack.Push(poppedNode.left);
                }
            }

            return preoder;
        }


        public static TreeNode ConstructTreeFromPreorderAndInorder(List<TreeNode> inorder, List<TreeNode> preorder)
        {
            TreeNode root = TreeProblems._ConstructTreeUtil(inorder, preorder, 0, inorder.Count - 1, 0);
            return root;
        }

        private static TreeNode _ConstructTreeUtil(
                                          List<TreeNode> inorder, 
                                          List<TreeNode> preorder, 
                                          int startInInorder, 
                                          int endInInorder,
                                          int currentIndexInPreOrder
                                         )
        {
            if (startInInorder > endInInorder || currentIndexInPreOrder > preorder.Count - 1)
            {
                return null;
            }

            TreeNode root = preorder[currentIndexInPreOrder];
            int inIndex = inorder.IndexOf(root);
            root.left = _ConstructTreeUtil(inorder, preorder, startInInorder, inIndex - 1, currentIndexInPreOrder + 1);
            root.right = _ConstructTreeUtil(inorder, preorder, inIndex + 1, endInInorder, currentIndexInPreOrder + 1);
            return root;
        }

        public static int SumRootToLeafPath(TreeNode node)
        {
            return _sumRootToLeafPath(node, 0);
        }

        private static int _sumRootToLeafPath(TreeNode node, int partialSum)
        {
            if (node == null)
            {
                return 0;
            }

            partialSum = 2 * partialSum + node.data;

            if (node.left == null && node.right == null)
            {
                return partialSum;
            }

            return _sumRootToLeafPath(node.left, partialSum) + _sumRootToLeafPath(node.right, partialSum);
        }

        public static bool HasRequiredSumPath(TreeNode node, int requiredSum)
        {
            return _hasRequiredSumPath(node, requiredSum);
        }

        private static bool _hasRequiredSumPath(TreeNode node, int requiredSum)
        {
            if (node == null)
            {
                return false;
            }

            if (node.data - requiredSum == 0)
            {
                return true;
            }
            else if(node.data < requiredSum)
            {
                return false;
            }

            return (_hasRequiredSumPath(node.left, node.data - requiredSum) || _hasRequiredSumPath(node.right, node.data - requiredSum));
        }

        private static TreeNode _findLeftMostNode(TreeNode node)
        {
            node = node.right;
            while (node.left != null)
            {
                node = node.left;
            }

            return node;
        }

        public static bool IsTreeBinarySearchTree(TreeNode root)
        {
            if (root == null)
            {
                return false;
            }

            return TreeProblems._isTreeBinarySearchTree(root, int.MaxValue, int.MinValue);
        }

        public static void CalcluateLeafNodeCounts(TreeNode node)
        {
            _CalculateLeafNodeCounts(node);
        }

        private static int _CalculateLeafNodeCounts(TreeNode node)
        {
            if (node == null)
            {
                return 0;
            }

            node.childCount = _CalculateLeafNodeCounts(node.left) +
                _CalculateLeafNodeCounts(node.right); 

            Console.WriteLine("Node {0} ", node.data + " has these many children " + node.childCount);
            return node.childCount + 1;
        }

        public static TreeNode GetLCA(TreeNode root, TreeNode node1, TreeNode node2)
        {
            return _GetLCAUtil(root, node1, node2);
        }

        public static TreeNode FindKthInorderNode(TreeNode node, int k)
        {
            if (node == null)
            {
                return null;
            }

            TreeNode current = node;
            int leftNodes = 0;
            while (current != null)
            {
                leftNodes = current.left != null ? current.left.childCount + 1 : 0;

                if (leftNodes + 1 < k)
                {
                    k = k - (leftNodes + 1);
                    current = current.right;
                }
                else if (leftNodes + 1 == k)
                {
                    return current;
                }
                else
                {
                    current = current.left;
                }
            }

            return current;
        }

        public static TreeNode GetLCAWithParentNodes(TreeNode root, TreeNode node1, TreeNode node2)
        {
            int d1 = TreeProblems._getDepth(node1);
            int d2 = TreeProblems._getDepth(node2);

            if (d1 > d2)
            {
                TreeNode temp = node2;
                node2 = node1;
                node1 = temp;
            }

            for (int i = 0 ; i < Math.Abs(d1 - d2); i ++)
            {
                node2 = node2.parent;   
            }

            while (node2 != node1)
            {
                node2 = node2.parent;
                node1 = node1.parent;
            }

            return node1;
        }

        private static int _getDepth(TreeNode node)
        {
            int depth = 0;
            while (node.parent != null)
            {
                node = node.parent;
                depth++;
            }

            return depth;
        }

        private static TreeNode _GetLCAUtil(TreeNode root, TreeNode node1, TreeNode node2)
        {
            if (root == null)
            {
                return null;
            }

            if (root.left == node1 ||
                root.right == node1 ||
                root.left == node2 ||
                root.right == node2)
            {
                return root;
            }

            TreeNode left = _GetLCAUtil(root.left, node1, node2);
            TreeNode right = _GetLCAUtil(root.right, node1, node2);

            if (left != null && right == null)
            {
                return left;
            }
            else if (left == null && right != null)
            {
                return right;
            }
            else if (left != null && right != null)
            {
                return root;
            }

            return null;
        }

        private static bool _isTreeBinarySearchTree(TreeNode root, int max, int min)
        {
            if (root == null)
                return true;

            if (root.data < max && root.data > min)
            {
                return (
                    _isTreeBinarySearchTree(root.left, root.data, min) &&
                    _isTreeBinarySearchTree(root.right, max, root.data)
                );
            }
            else 
            {
                return false;    
            }
        }

        private static balanceResult isTreeBalanacedUtil(TreeNode root)
        {
            if (root == null)
                return new balanceResult(-1, true);

            balanceResult leftBalancedResult = isTreeBalanacedUtil(root.left);

            if (!leftBalancedResult.isBalanced)
            {
                return leftBalancedResult;
            }

            balanceResult rightBalancedResult = isTreeBalanacedUtil(root.right);

            if (!rightBalancedResult.isBalanced)
            {
                return rightBalancedResult;
            }

            return new balanceResult(1 + Math.Max(leftBalancedResult.height,rightBalancedResult.height),
                                     Math.Abs(leftBalancedResult.height - rightBalancedResult.height) >= 1);

        }

		private class balanceResult
		{
			public balanceResult(int height, bool isBalanced)
			{
				this.height = height;
				this.isBalanced = isBalanced;
			}
			public int height;
			public bool isBalanced;
		}
    }
}
