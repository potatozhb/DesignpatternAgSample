using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
	public class Tries
	{
		public Node root;
		public Tries()
		{
			root = new Node('\0');
		}

		public void InsertNode(string word)
		{
			SingletonPatternLog.AddLog($"word lib:  {word}");
			Node curr = root;
			for (int i = 0; i < word.Length; i++)
			{
				Char c = word[i];
				if (curr.childrennode[c - 'a'] == null) curr.childrennode[c - 'a'] = new Node(c);
				curr = curr.childrennode[c - 'a'];
			}
			curr.isaword = true;
		}

		public bool searchNode(string word)
		{
			Node node = getnode(word);
			if (node == null || node.isaword == false)
				return false;
			else
				return true;

		}



		public List<string> Becontains(string str)
		{
			SingletonPatternLog.AddLog($"search target string is {str}");

			List<string> list = new List<string>();

			for(int i=0;i<str.Length;i++)
            {
				for (int j = i; j < str.Length; j++)
				{
					string ss = str.Substring(i, j-i);
					if (getnode(ss) != null)
					{
						list.Add(ss);

						SingletonPatternLog.AddLog($"# {list.Count} target string is {ss}");
					}
				}
            }
			
			return list;
		}

		public bool Startswith(string prefix)
		{
			return getnode(prefix) != null;
		}

		private Node getnode(string word)
		{
			if(word =="")
				return null;
			Node curr = root;
			for (int i = 0; i < word.Length; i++)
			{
				Char c = word[i];
				if (curr.childrennode[c - 'a'] == null) return null;
				curr = curr.childrennode[c - 'a'];
			}

			if(curr.isaword)
				return curr;
			return null;
		}

		public class Node
		{
			public char c;
			public bool isaword;
			public Node[] childrennode;

			public Node(char c)
			{
				this.c = c;
				isaword = false;
				childrennode = new Node[26];

			}

		}
	}
}
