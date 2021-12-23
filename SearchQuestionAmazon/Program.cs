// See https://aka.ms/new-console-template for more information

using SearchQuestionAmazon;
using System.Collections;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        Hashtable ht = new Hashtable();
        ht.Add(1, 1);
        ht.Add(2, 2);
        ht.Add(3, 2);
        ht[1] = 2;

        foreach(var vv in ht.Values)
        {
            
        }    
        Console.WriteLine($"hashtable is {ht[1]}");

        SubMatrixMaxSum subMatrixMaxSum = new SubMatrixMaxSum();

        string s1 = "afccdd";
        var sss = s1.Reverse();
        string s2 = String.Join("", sss);

        char[] cc = s2.ToArray();
        Array.Sort(cc);

        Console.WriteLine($"rem is {String.Join("",cc)}");

        Console.WriteLine("===========================");

        int b;
        int a = Math.DivRem(16, 2, out b);

        ReversALinkList.BuildLink();
        Console.WriteLine($"{ReversALinkList.TravelThroughLink()}");
        ReversALinkList.ReverseV1();
        Console.WriteLine($"{ReversALinkList.TravelThroughLink()}");

        Console.WriteLine("===========================");

        List<int> blist = new List<int>();
        blist.Add(15);
        blist.Add(5);
        blist.Add(6);
        blist.Add(8);
        blist.Add(7);
        blist.Add(2);
        blist.Add(3);
        blist.Add(9);
        blist.Add(4);
        blist.Add(1);

        Console.WriteLine($"{MySort.FastSort(blist)}");


        MySearch mysearch = new MySearch();
        mysearch.BulidBtreeSample();

        Console.WriteLine($"{mysearch.DSF()}");
        Console.WriteLine($"{mysearch.BSF()}");

        Console.WriteLine("===========================");

        List<string> list = new List<string>();
        list.Add("Mobile");
        list.Add("Mouse");
        list.Add("Moneypot");
        list.Add("Monitor");
        list.Add("Mousepad");

        List<List<string>> rs = Search.Run(list, "mouse");

        for(int i=0;i< rs.Count;i++)
        {
            string ss = "";
            for(int j=0;j<rs[i].Count;j++)
            {
                ss+=rs[i][j].ToString() + ",";
            }
            Console.WriteLine(ss);
        }


        System.Console.WriteLine("test");
        Tries tries = new Tries();
        tries.InsertNode("mobile");
        tries.InsertNode("mouse");
        tries.InsertNode("moneypot");
        tries.InsertNode("monitor");
        tries.InsertNode("mousepad");

        list = tries.Search("mo");

        string output = "";
        for (int i = 0; i<list.Count; i++)
        {
            output += list[i] + ",";
        }
        Console.WriteLine(output);

        output = "";
        list = tries.Search("mou");
        for (int i = 0; i<list.Count; i++)
        {
            output += list[i] + ",";
        }
        Console.WriteLine(output);

        output = "";
        list = tries.Search("mous");
        for (int i = 0; i<list.Count; i++)
        {
            output += list[i] + ",";
        }
        Console.WriteLine(output);

        output = "";
        list = tries.Search("mouse");
        for (int i = 0; i<list.Count; i++)
        {
            output += list[i] + ",";
        }
        Console.WriteLine(output);

        Console.ReadLine();

    }

    static class Search
    {
        public static List<List<string>> Run(List<string> repository, string customerQuery)
        {//O(m*n)
            List<List<string>> returnvalue = new List<List<string>>();
            for(int i=0;i<repository.Count;i++)
            {
                repository[i] = repository[i].ToLower();
            }

            repository.Sort();

            for(int i=2;i<customerQuery.Length;i++)
            {
                List<string> temp = new List<string>();
                string substr = customerQuery.Substring(0, i);
                for(int j=0;j<repository.Count;j++)
                {
                    if (repository[j].StartsWith(substr) && temp.Count< 3)
                        temp.Add(repository[j]);

                }
                returnvalue.Add(temp);
            }
            return returnvalue;
        }
    }

}


