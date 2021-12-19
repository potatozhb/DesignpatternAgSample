using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchQuestionAmazon
{
    public class MySearch
    {
        BNode root = new BNode(5);

        public void BulidBtreeSample()
        {
            InsertData(root,2);
            InsertData(root, 1);
            InsertData(root, 4);
            InsertData(root, 7);
            InsertData(root, 9);
            InsertData(root, 8);
        }

        public void InsertData(BNode temproot, int d)
        {

            if (temproot.data > d)
            {
                if (temproot.left == null)
                {
                    temproot.left = new BNode(d);
                    temproot.left.parent = temproot;
                    return;
                }
                temproot = temproot.left;
                InsertData(temproot,d);
            }
            else
            {
                if (temproot.right == null)
                {
                    temproot.right = new BNode(d);
                    temproot.right.parent = temproot;
                    return;
                }
                temproot = temproot.right;
                InsertData(temproot,d);
            }
        }

        string rs = "";
        public string DSF()
        {
            rs ="";
            return DSFhelper(root);
        }

        private string DSFhelper(BNode node)
        { 
            rs += node.data;
            if(node.left != null)
                DSFhelper(node.left);
            if(node.right != null)
                DSFhelper(node.right);

            return rs;
        }
        public string BSF()
        {
            rs ="";
            return BSFhelper(root);
        }
        private string BSFhelper(BNode node)
        {
            Queue<BNode> queue = new Queue<BNode>();
            queue.Enqueue(node);
            while(queue.Count>0)
            {
                node = queue.Dequeue();
                rs += node.data;

                if(node.left != null)
                    queue.Enqueue(node.left);
                if(node.right!= null)
                    queue.Enqueue(node.right);
            }

            return rs;
        }
    }

    public class BNode
    {
        public int data;
        public BNode left;
        public BNode right;
        public BNode parent;

        public BNode(int d)
        {
            data = d;
        }

    }
}
