using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SearchQuestionAmazon
{
    public class TreeNode
    {
        public char c;
        public bool isaWord;
        public TreeNode[] ChildrenNode;

        public TreeNode()
        {
            ChildrenNode = new TreeNode[26];
        }
    }

    [MemoryDiagnoser]
    public class Tries
    {
        private TreeNode root;

        public Tries()
        {
            root = new TreeNode();
            root.c ='\0';
        }

        public void InsertNode(string str)
        {
            string temp = str.ToLower();
            TreeNode temproot = root;
            for (int i = 0; i<str.Length; i++)
            {//o(n)
                int index = temp[i] - 'a';
                TreeNode node = new TreeNode();
                node.c = temp[i];
                if (temproot.ChildrenNode[index] == null)
                {
                    temproot.ChildrenNode[index] = node;
                }
                temproot = temproot.ChildrenNode[index];
            }

            temproot.isaWord = true;

        }


        //[Benchmark]
        public void YieldReturn()
        {
            IEnumerable<int> rs = YieldReturnTest();
            foreach (int i in rs)
            {
                if (i< 100)
                {
                    int j = i;
                }
                else
                {
                    break;
                }
            }

        }

        //[Benchmark]
        public void NormalReturn()
        {
            IEnumerable<int> rs = Test();
            foreach (int i in rs)
            {
                if (i< 100)
                {
                    int j = i;
                }
                else
                {
                    break;
                }
            }

        }

        public IEnumerable<int> YieldReturnTest()
        {
            for (int i = 0; i<10000; i++)
            {
                yield return i;
            }

        }

        public IEnumerable<int> Test()
        {
            List<int> list = new List<int>();
            for (int i=0; i<10000;i++)
            {
                list.Add(i);
            }

            return list;

        }


        public List<string> Search(string targetstr)
        {
            words = new List<string>();
            if (targetstr.Length>1)
            {
                TreeNode temproot = root;
                for (int i = 0; i<targetstr.Length; i++)
                {
                    int index = targetstr[i] - 'a';
                    if (temproot.ChildrenNode[index] !=null)
                    {
                        temproot = temproot.ChildrenNode[index];
                    }
                }

                return GetWords(temproot, targetstr);

            }
            else
                return null;

        }

        List<string> words = new List<string>();

        public List<string> GetWords(TreeNode temproot, string prefix)
        {
            if (temproot.isaWord)
                words.Add(prefix);

            foreach (TreeNode node in temproot.ChildrenNode)
            {
                if (words.Count ==3)
                    break;
                if (node != null)
                {
                    temproot = node;
                    GetWords(temproot, prefix + node.c);
                }
            }

            return words;
        }
    }
}
