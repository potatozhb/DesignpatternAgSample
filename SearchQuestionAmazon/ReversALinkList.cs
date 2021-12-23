using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchQuestionAmazon
{
    public class ReversALinkList
    {
        static LinkNode root = null;

        public static void BuildLink()
        {
            InsertNode("a");
            InsertNode("b");
            InsertNode("c");
            InsertNode("d");
            InsertNode("e");
            InsertNode("f");
            InsertNode("g");
            InsertNode("h");
            InsertNode("i");
            InsertNode("j");
        }
        public static void ReverseV1()
        {
            LinkNode pre = null;

            while(root != null)
            {
                LinkNode next = root.NextNode;
                root.NextNode = pre;
                pre = root;
                root = next;

            }
            //last node
            root = pre;
        }

        public static string InsertNode(string data)
        {
            LinkNode node = new LinkNode();
            node.data = data;
            InsertNodeHelper(root, node);

            return TravelThroughLink();
        }

        private static void InsertNodeHelper(LinkNode temproot, LinkNode node)
        { 
            if (temproot == null)
            {
                temproot = node;
                root = temproot;
                return;
            }    

            if (temproot.NextNode == null)
                temproot.NextNode = node;
            else
            {
                InsertNodeHelper(temproot.NextNode, node);
            }
        }

        public static string TravelThroughLink()
        {
            string rs = "";
            if(root ==null)
                return rs;
            else
            {
                rs = root.data;
                LinkNode temproot = root;
                while(temproot.NextNode != null)
                {
                    rs +="," + temproot.NextNode.data;
                    temproot = temproot.NextNode;
                }
            }

            return rs;
        }
    }

    public class LinkNode
    {
        public string data;
        public LinkNode NextNode;

    }
}
