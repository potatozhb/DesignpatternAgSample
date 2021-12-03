using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{

    public abstract class StrategyPattern
    {
        public string name;
        public string age;
        public string weight;

        public Flytype flytype;

        public abstract void SetFly(Flytype ft);
        public abstract void Fly();

    }

    public class Dog : StrategyPattern
    {
        public Dog()
        {
            flytype = new notFly();
        }

        public override void Fly()
        {
            flytype.Fly();
        }

        public override void SetFly(Flytype ft)
        {
            flytype = ft;
        }
    }

    public class Bird : StrategyPattern
    {
        public Bird()
        {
            flytype = new canFly();
        }
        public override void Fly()
        {
            flytype.Fly();
        }

        public override void SetFly(Flytype ft)
        {
            flytype = ft;
        }
    }

    public interface Flytype
    {
        void Fly();
    }

    public class canFly : Flytype
    {
        public void Fly()
        {
            SingletonPatternLog.AddLog("I can fly");
        }
    }

    public class notFly : Flytype
    {
        public void Fly()
        {
            SingletonPatternLog.AddLog("I can not fly");
        }
    }

    public class sickFly : Flytype
    {
        public void Fly()
        {
            SingletonPatternLog.AddLog("I am sick and can't fly");
        }
    }
}
