using NUnit.Framework;
using SearchQuestionAmazon;
using System.Collections.Generic;

namespace NUnitTestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TriesTest()
        {
            string ss = "dbcabcabddda";
            Tries tries = new Tries();
            tries.InsertNode("abc");
            tries.InsertNode("abd");
            tries.InsertNode("bbc");

            List<string> slist = tries.Search(ss);

            
            Assert.AreEqual(1, slist.Count);
            
        }
    }
}