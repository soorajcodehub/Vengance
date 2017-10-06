using System;
namespace CrackThat
{
	public class TreeNode
	{
		public TreeNode left;
		public TreeNode right;
        public TreeNode parent;
		public int data;
        public int childCount;
        public int bit;

		public TreeNode()
		{

		}

        public TreeNode(int data)
        {
            this.data = data;
        }


	}
}
