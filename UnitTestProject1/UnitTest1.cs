
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WindowsFormsApp1;

namespace UnitTestProject1
{
    public class UnitTest1
    {

        public void TestMethod1()
        {
            Assert.Fail();
        }

        public void TrieTest()
        {
            string ss = "dbcabcabddda";
            Tries tries = new Tries();
            tries.InsertNode("abc");
            tries.InsertNode("abd");
            tries.InsertNode("bbc");

            List<string> slist = tries.Becontains(ss);


            Assert.AreEqual(1, slist.Count);
        }
    }
}
