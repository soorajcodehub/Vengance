using System;
using System.Collections.Generic;

namespace CrackThat
{
    public class Tree
    {
        TreeNode root;
        TreeNode currentNode; 

        //int height;
        //bool isBST;
        //bool isComplete;
        //bool isFull;
        //bool isBalanced;

        public TreeNode Root { get => this.root; }

        public void AddNode(int data, bool toLeft)
        {
            if (this.root == null)
            {
                this.root = new TreeNode(data);
                this.currentNode = this.root;
                return;
            }

            if (toLeft)
            {
                TreeNode left = new TreeNode(data);
                this.currentNode.left = left;
                this.currentNode = this.currentNode.left;
            }
            else 
            {
				TreeNode right = new TreeNode(data);
				this.currentNode.right = right;
				this.currentNode = this.currentNode.right;
            }
        }

        public void AddBSTNode(int data)
        {
            if (this.root == null)
            {
                this.currentNode = this.root = new TreeNode(data);
                return;
            }

            this._addBSTNodeUtil(data, root);   
        }

        private void _addBSTNodeUtil(int data, TreeNode node)
        {
            if (data < node.data)   
            {
                if (node.left == null)
                {
                    node.left = new TreeNode(data);
                    this.currentNode = node.left;
                    return;
                }
                else
                {
                    _addBSTNodeUtil(data, node.left);   
                }
            }
            else if (data > node.data)
            {
				if (node.right == null)
				{
					node.right = new TreeNode(data);
                    this.currentNode = node.right;
                    return;
				}
				else
				{
					_addBSTNodeUtil(data, node.right);
				}
            }
            else 
            {
                throw new NotSupportedException("Duplicate key in BST not supported");
            }
        }

        public void printLevelWiseTree(TreeNode root)
        {
            try
            {
                if (root == null)
                {
                    throw new ArgumentException("Invalid Tree");
                }

                int centerPositionOnScreen = (Console.LargestWindowWidth - root.data.ToString().Length) / 2;
				int topPositionOnScreen = Console.CursorTop;
                Queue<TreeNodePrintDetail> nodes = new Queue<TreeNodePrintDetail>();
                nodes.Enqueue(new TreeNodePrintDetail(root, 0, centerPositionOnScreen));
                int level = 0;
                int treeHeight = this.GetTreeHeight(this.Root);
                int maxLeaves = (int)Math.Pow(treeHeight, 2);

                while(nodes.Count > 0)
                {

                    while (nodes.Count > 0 && level == nodes.Peek().level)
                    {
                        TreeNodePrintDetail nodeLevel = nodes.Dequeue();

                        if (nodeLevel.node.left != null)
                        {
                            if (nodeLevel.level == 0)
                            {
                                int nextPosition = (maxLeaves / 2) * 5;
                                nodes.Enqueue(new TreeNodePrintDetail(nodeLevel.node.left, nodeLevel.level + 1, nodeLevel.posLeft - nextPosition));
                            }
                            else
                            {
                                nodes.Enqueue(new TreeNodePrintDetail(nodeLevel.node.left, nodeLevel.level + 1, nodeLevel.posLeft - 5 - (nodeLevel.level * 2)));
                            }
                        }
                        if (nodeLevel.node.right != null)
                        {
                            if (nodeLevel.level == 0)
                            {
								int nextPosition = (maxLeaves / 2) * 5;
								nodes.Enqueue(new TreeNodePrintDetail(nodeLevel.node.right, nodeLevel.level + 1, nodeLevel.posLeft + nextPosition));
                            }
                            else 
                            {
                                nodes.Enqueue(new TreeNodePrintDetail(nodeLevel.node.right, nodeLevel.level + 1, nodeLevel.posLeft + 5 + (nodeLevel.level * 2)));
                            }
                        }

                        Console.SetCursorPosition(nodeLevel.posLeft, nodeLevel.level * 2);
                        Console.Write(nodeLevel.node.data);
					}

                    level++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public int GetTreeHeight(TreeNode root)
        {
            if (root == null || (root.left == null && root.right == null))
            {
                return 0;
            }

            int leftTreeHeight = GetTreeHeight(root.left) + 1;
            int rightTreeHeight = GetTreeHeight(root.right) + 1;

            return Math.Max(leftTreeHeight, rightTreeHeight);
        }

        internal class TreeNodePrintDetail 
        {
            internal TreeNodePrintDetail(TreeNode node, int level, int posLeft)
            {
                this.node = node;
                this.level = level;
                this.posLeft = posLeft;
            }

            internal int posLeft;
            internal TreeNode node;
            internal int level;
        }
    }
}
