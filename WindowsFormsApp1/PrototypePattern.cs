using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class PrototypePattern
    {
        public void RunPattern()
        {
            MyDog dog1 = new MyDog();
            SingletonPatternLog.AddLog($"dog1 address is { dog1.GetHashCode()} , {dog1.GetName()}");

            MyDog clonedog = (MyDog) dog1.Copy();
            SingletonPatternLog.AddLog($"Clone dog address is { clonedog.GetHashCode()} , {clonedog.GetName()}");

        }
    }

    public interface IAnimal
    {
        IAnimal Copy();
    }
    public class MyDog : IAnimal
    {
        private string dogname = "dog1";
        public MyDog()
        {
            SingletonPatternLog.AddLog("create a dog");
        }

        public IAnimal Copy()
        {
            MyDog cld = (MyDog)this.MemberwiseClone();
            cld.dogname = "Clone dog";

            return (IAnimal)(cld);
        }

        public string GetName()
        {
            return dogname;
        }

    }
}
