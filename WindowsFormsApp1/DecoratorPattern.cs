using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class DecoratorPattern
    {
        public void Run()
        {
            DecoratObject _decoratObject = new DecoratObject();
            _decoratObject.GetPizzaDescription();

            SingletonPatternLog.AddLog("++++++++++++++++++");

            Decorator1 d1 = new Decorator1(_decoratObject);
            d1.GetPizzaDescription();
            Decorator2 d2 = new Decorator2(_decoratObject);
            d2.GetPizzaDescription();
            Decorator3 d3 = new Decorator3(_decoratObject);
            d3.GetPizzaDescription();


            SingletonPatternLog.AddLog("++++++++++++++++++");

            d2 = new Decorator2(d1);
            d3 = new Decorator3(d2);
            d3.GetPizzaDescription();

        }
        
    }

    interface IDecoratObject
    {//pizza
        string GetPizzaDescription();
    }

    class DecoratObject : IDecoratObject
    {
        public string GetPizzaDescription()
        {
            string description = "This is the basic object";
            SingletonPatternLog.AddLog(description);
            return description;
        }
    }

    class BaseDecorator:IDecoratObject
    {
        private IDecoratObject _decoratObject;
        public BaseDecorator(IDecoratObject obj)
        {
            _decoratObject = obj;
        }

        public virtual string GetPizzaDescription()
        {
            return _decoratObject.GetPizzaDescription();
        }
    }

    class Decorator1 : BaseDecorator
    {
        public Decorator1(IDecoratObject obj) : base(obj) { }

        public override string GetPizzaDescription()
        {
            string des = base.GetPizzaDescription();
            des +="\r\n Add decorator1";

            SingletonPatternLog.AddLog(des);
            return des;
        }
    }

    class Decorator2 : BaseDecorator
    {
        public Decorator2(IDecoratObject obj) : base(obj) { }

        public override string GetPizzaDescription()
        {
            string des = base.GetPizzaDescription();
            des +="\r\n Add decorator2";
            SingletonPatternLog.AddLog(des);
            return des;
        }
    }

    class Decorator3 : BaseDecorator
    {
        public Decorator3(IDecoratObject obj) : base(obj) { }

        public override string GetPizzaDescription()
        {
            string des = base.GetPizzaDescription();
            des +="\r\n Add decorator3";
            SingletonPatternLog.AddLog(des);
            return des;
        }
    }
}
