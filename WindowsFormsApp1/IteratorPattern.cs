using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class IteratorPattern
    {
        public void Run()
        {
            ArrayClass ac = new ArrayClass();


            foreach (int n in ac)
            {
                SingletonPatternLog.AddLog(n.ToString());
            }

            HashtableClass hashtableClass = new HashtableClass();

            foreach(People pe in hashtableClass)
            {
                SingletonPatternLog.AddLog($"people is {pe.Name}");
            }
        }

        public class People
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public int Age { get; set; }
        }
        public class HashtableClass : IEnumerable
        {
            Hashtable ht = new Hashtable();

            public HashtableClass()
            {
                ht.Add(ht.Count, new People() { Name = "Joe", Description ="good", Age =44 });
                ht.Add(ht.Count, new People() { Name = "Tom", Description ="dfds", Age =3 });
                ht.Add(ht.Count, new People() { Name = "TT", Description ="1111", Age =6 });
                ht.Add(ht.Count, new People() { Name = "Kary", Description ="ffff", Age =8 });
                ht.Add(ht.Count, new People() { Name = "4444", Description ="bad", Age =9 });
                ht.Add(ht.Count, new People() { Name = "EI", Description ="6666", Age =43 });
            }

            public IEnumerator GetEnumerator()
            {
                return (IEnumerator)new HashtableEnumerator(ht);
            }
        }

        public class HashtableEnumerator : IEnumerator
        {
            Hashtable ht = new Hashtable();
            List<object> keys;
            int currentkey = -1;

            public HashtableEnumerator(Hashtable newht)
            {
                ht = newht;
                keys = ht.Keys.Cast<object>().ToList();
            }

            public object Current
            {
                get
                {
                    try
                    {
                        return ht[keys[currentkey]];
                    }
                    catch (Exception e)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }


            public bool MoveNext()
            {
                currentkey++;
                return currentkey < ht.Count;
            }

            public bool MovePrevious()
            {
                currentkey--;
                return currentkey >=0;
            }

            public void Reset()
            {
                currentkey =-1;
            }

            
        }

        public class ArrayClass : IEnumerable
        {
            int[] myarray = new int[5] { 4, 1, 3, 2, 5 };


            public IEnumerator GetEnumerator()
            {
                return (IEnumerator)new ArrayEnumerator(myarray);
            }
        }

        public class ArrayEnumerator : IEnumerator
        {
            int[] myarray;
            int currentpos = -1;

            public ArrayEnumerator(int[] newarray)
            {
                myarray = newarray;
            }

            public object Current
            {
                get
                {
                    try
                    {
                        return myarray[currentpos];
                    }
                    catch (Exception e)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }


            public bool MoveNext()
            {
                currentpos++;
                return currentpos < myarray.Length;
            }

            public bool MovePrevious()
            {
                currentpos--;
                return currentpos >=0;
            }

            public void Reset()
            {
                currentpos =-1;
            }
        }
    }
}
