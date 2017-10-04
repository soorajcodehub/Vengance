using System;
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

        public static bool IsTreeBinarySearchTree(TreeNode root)
        {
            if (root == null)
            {
                return false;
            }

            return TreeProblems._isTreeBinarySearchTree(root, int.MaxValue, int.MinValue);
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
