using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class AbstractFactoryTest
    {
        public void Run()
        {
            ShapeFactory shapeFactory = new ShapeFactory();
            FactoryItem factoryItem = shapeFactory.GetData((int)ShapeType.Rectangle);
            ((Rectangle)factoryItem.Data).GetInfo();

            factoryItem = shapeFactory.GetData((int)ShapeType.Circle);
            ((Circle)factoryItem.Data).GetInfo();
        }
    }

    interface IFactory
    {
        FactoryItem GetData(int type);
    }


    public abstract class AbstractFactory:IFactory
    {
        public abstract FactoryItem GetData(int type);
    }

    public class FactoryItem
    {
        private object _data;
        public FactoryItem(object data)
        {
            _data = data;
        }

        public object Data { get { return _data; } }
    }

    public class Circle
    { 
        public void GetInfo()
        {
            SingletonPatternLog.AddLog("This is Circle");
        }
    }
    public class Rectangle
    {
        public void GetInfo()
        {
            SingletonPatternLog.AddLog("This is Rectangle");
        }
    }

    public enum ShapeType
    {
        Circle = 0,
        Rectangle = 1
    }


    public class ShapeFactory:AbstractFactory
    {
        private FactoryItem _data;        

        public override FactoryItem GetData(int type)
        {
            switch (type)
            {
                case (int)ShapeType.Circle:
                    _data = new FactoryItem(new Circle());
                    break;
                case (int)ShapeType.Rectangle:
                    _data = new FactoryItem(new Rectangle());
                    break;
                default:
                    _data = new FactoryItem(new Circle());
                    break;
            }

            return _data;
        }

    }


}
