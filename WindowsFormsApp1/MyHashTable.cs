using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class MyHashTable
    {
        Hashtable hsTable = new Hashtable();
        
        public void RunHashtable()
        {
            hsTable.Add(1, "111111");
            hsTable.Add(2, "2222222222");
            hsTable.Add(3, "3333333333");
            hsTable.Add(4, "444444444444444");
            hsTable.Add(5, "55555555");

            string ss = hsTable[1].ToString();
        }
    }
}
