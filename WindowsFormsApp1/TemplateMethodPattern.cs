using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public abstract class TemplateMethodPattern
    {
        public void StartMakeBugger()
        {
            MakeBread();
            MakeMeat();
            MakeVegetable();
        }

        protected virtual void MakeBread()
        {
            SingletonPatternLog.AddLog("Original Bread.");
        }

        protected abstract void MakeMeat();

        protected virtual void MakeVegetable()
        {
            SingletonPatternLog.AddLog("Original vegetable.");
        }
    }

    public class FishBuger:TemplateMethodPattern
    {
        protected override void MakeBread()
        {
            SingletonPatternLog.AddLog("fish burger bread.");
        }

        protected override void MakeMeat()
        {
            SingletonPatternLog.AddLog("New fish.");
        }
    }


    public class VegetableBuger : TemplateMethodPattern
    {
        protected override void MakeBread()
        {
            SingletonPatternLog.AddLog("vegetable burger bread.");
        }

        protected override void MakeMeat()
        {
            SingletonPatternLog.AddLog("No meat.");
        }
    }
}
