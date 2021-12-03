using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
	public class Node
	{
		public int data;
		public Node Left;
		public Node Right;
		public Node(int n)
		{
			data = n;
		}

	}

	public class BinarySearchTree
	{
		Node root;

		public void BanlanceBT()
        {
			int ncheck = 0;
			int leftdep = -1;
			int rightdep = -1;
			if (!CheckBalance(root, out leftdep, out rightdep))
			{
				SingletonPatternLog.AddLog($"banlance root node {++ncheck} time, data： {root.data} *****************");
				BalanceBThelper(root);

				bool bb = CheckBalance(root, out leftdep, out rightdep);
			}

			SingletonPatternLog.AddtoTopLog($"@@@@@@@@@check {ncheck} times.@@@@@@@@@@@");

		}

		private void BalanceBThelper(Node newroot, Node parent = null)
		{

			int leftdep = -1;
			int rightdep = -1;
			bool bBalanced = CheckBalance(newroot, out leftdep, out rightdep);
			if (!bBalanced)
			{
				BalanceBThelper(newroot.Left, newroot);
				BalanceBThelper(newroot.Right, newroot);

				//rotate tree
				bBalanced = CheckBalance(newroot, out leftdep, out rightdep);
				while (!bBalanced)
				{
					SingletonPatternLog.AddLog($"Children banlance root node {newroot.data}");

					newroot =RotateBT(newroot, leftdep, rightdep, parent);
					BalanceBThelper(newroot, parent);

					bBalanced = CheckBalance(newroot, out leftdep, out rightdep);
				}
			}
		}

		private Node RotateBT(Node newroot, int dleft, int dright, Node parent)
		{
			Node rotatedroot = newroot;//save rotated new root

			SingletonPatternLog.AddLog($"banlance node {newroot.data}");

			if (dleft > dright)
			{//if need right
				int subdleft = CheckDepth(newroot.Left.Left);
				int subdright = CheckDepth(newroot.Left.Right);

				if (subdright > subdleft)
				{
					SingletonPatternLog.AddLog($"#rotate node {newroot.Left.data} right");
					//if need left-right
					Node tempnode = newroot.Left;
					newroot.Left = tempnode.Right;
					tempnode.Right = newroot.Left.Left;
					newroot.Left.Left = tempnode;

				}

				if (parent != null)
				{
					SingletonPatternLog.AddLog($"#rotate node {newroot.data} right");

					if (parent.Left != null && parent.Left.data == newroot.data)
					{
						rotatedroot = newroot.Left;
						parent.Left = rotatedroot;
						newroot.Left = rotatedroot.Right;
						rotatedroot.Right = newroot;

					}
					else
					{
						rotatedroot = newroot.Left;
						parent.Right = rotatedroot;
						newroot.Left = rotatedroot.Right;
						rotatedroot.Right = newroot;
					}
				}
				else
				{
					SingletonPatternLog.AddLog($"#move root node to {newroot.Left.data}");
					rotatedroot = newroot.Left;
					root = rotatedroot;
					newroot.Left = rotatedroot.Right;
					rotatedroot.Right = newroot;
				}
			}
			else
			{
				//if need left
				int subdleft = CheckDepth(newroot.Right.Left);
				int subdright = CheckDepth(newroot.Right.Right);

				if (subdleft > subdright)
				{
					SingletonPatternLog.AddLog($"rotate node {newroot.Right.data} right");
					//if need right-left
					Node tempnode = newroot.Right;
					newroot.Right = tempnode.Left;
					tempnode.Left = newroot.Right.Right;
					newroot.Right.Right = tempnode;
				}

				if (parent != null)
				{
					SingletonPatternLog.AddLog($"rotate node {newroot.data} left");
					if (parent.Left != null && parent.Left.data == newroot.data)
					{
						rotatedroot = newroot.Right;
						parent.Left = rotatedroot;
						newroot.Right = rotatedroot.Left;
						rotatedroot.Left = newroot;

					}
					else
					{
						rotatedroot = newroot.Right;
						parent.Right = rotatedroot;
						newroot.Right = rotatedroot.Left;
						rotatedroot.Left = newroot;

					}
				}
				else
				{
					SingletonPatternLog.AddLog($"#move root node to {newroot.Right.data}");
					rotatedroot = newroot.Right;
					root = rotatedroot;
					newroot.Right = rotatedroot.Left;
					rotatedroot.Left = newroot;
				}
			}

			return rotatedroot;
		}


		private bool CheckBalance(Node newroot, out int leftdepth, out int rightdepth)
		{

			if (newroot == null)
            {
				leftdepth =-1;
				rightdepth =-1;
				return true;
            }
			else
			{
				bool lbalance = CheckBalance(newroot.Left, out leftdepth, out rightdepth);
				bool rbalance = CheckBalance(newroot.Right, out leftdepth, out rightdepth);

				leftdepth = CheckDepth(newroot.Left)+1;
				rightdepth = CheckDepth(newroot.Right)+1;

				if (lbalance && rbalance && Math.Abs(leftdepth - rightdepth) <=1)
					return true;
				else
					return false;
			}

		}

		private int CheckDepth(Node newroot)
        {

			if (newroot == null)
				return -1;
			else
			{
				int ldepth = CheckDepth(newroot.Left);
				int rdepth = CheckDepth(newroot.Right);

				if (ldepth > rdepth)
					return ldepth+1;
				else 
					return rdepth+1;
			}

        }

		public Node Search(int data)
        {
			//return  SearchParentHelper(root, data);
			return SearchHelper(root, data);
        }
		private Node SearchHelper(Node newroot, int data)
		{
			if(newroot == null)
				return null;
			else
            {
				if (newroot.data > data)
					return SearchHelper(newroot.Left, data);
				else if (newroot.data < data)
					return SearchHelper(newroot.Right, data);
				else
					return newroot;
            }
		}

		private Node SearchParentHelper(Node newroot, int data)
		{
			if (newroot == null)
				return null;
			else if (newroot.Left !=null && newroot.Left.data == data)
				return newroot;
			else if (newroot.Right !=null && newroot.Right.data == data)
				return newroot;
			else
			{
				if (newroot.data > data)
					return SearchParentHelper(newroot.Left, data);
				else
					return SearchParentHelper(newroot.Right, data);
				
			}
		}

		public void Insert(Node data)
		{
			root = InsertHelper(root, data);
		}
		//recursion
		private Node InsertHelper(Node root, Node data)
		{
			if (root == null)
			{
				root = data;
				return root;
			}
			else if (data.data < root.data)
			{
				root.Left = InsertHelper(root.Left, data);
			}
			else if (data.data >= root.data)
			{
				root.Right = InsertHelper(root.Right, data);
			}
			return root;
		}
		public bool Remove(int data)
		{
			return RemoveNodeHelper(data) != null;
		}

		private Node RemoveNodeHelper(int data)
		{
			Node parent = SearchParentHelper(root, data);
			Node deletenode = SearchHelper(root, data);
			if (deletenode == null)
				return null;
			if (deletenode.Left ==null && deletenode.Right == null)
			{//leaf node
				if(parent == null)
					return null;
				if (parent.Left != null && parent.Left.data == data)
					parent.Left =null;
				else
					parent.Right = null;

				return deletenode;
			}
			else if (deletenode.Left !=null && deletenode.Right == null)
			{//one child node
				if (parent != null)
				{
					if (parent.Left != null && parent.Left.data == data)
						parent.Left =deletenode.Left;
					else
						parent.Right = deletenode.Left;
				}
				else
					root = deletenode.Left;

				return deletenode;
			}
			else if (deletenode.Left == null && deletenode.Right != null)
			{//one child node
				if (parent != null)
				{
					if (parent.Left != null && parent.Left.data == data)
						parent.Left =deletenode.Right;
					else
						parent.Right = deletenode.Right;
				}
				else
					root = deletenode.Left;

				return deletenode;
			}
			else
			{
				//search the max data to replace the delete data
				SearchMaxNode(deletenode.Left);
				Node replacenode = SearchMinNode(deletenode.Right);

				RemoveNodeHelper(replacenode.data);

				deletenode.data = replacenode.data;

				return replacenode;
			}


			return null;
		}

		public Node SearchMaxNode(Node newroot)
        {
			if(newroot.Right == null)
				return newroot;
			else
				return SearchMaxNode(newroot.Right);
        }

		public Node SearchMinNode(Node newroot)
		{
			if (newroot.Left == null)
				return newroot;
			else
				return SearchMinNode(newroot.Left);
		}


		public void Display()
		{
			root = DisplayHelper(root);
		}

		//recursion
		private Node DisplayHelper(Node root)
        {
			SingletonPatternLog.AddLog(root.data.ToString());
			if(root.Left != null)
				root.Left = DisplayHelper(root.Left);


			if(root.Right != null)
				root.Right = DisplayHelper(root.Right);
			return root;
		}
	}


}
