using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class ProxyPattern : IProxyPattern
    {//limit the access to another class
        private ICar car;

        public void Drive(IDriver driver)
        {
            car = new Car();
            if(driver.Age > 16)
            {
                car.Drive(driver);
            }
            else
            {
                SingletonPatternLog.AddLog("Driver age is under 16. Can't drive.");
            }
        }
    }

    public interface IProxyPattern
    {//Hide lock the car method
        void Drive(IDriver driver);
    }

    public interface IDriver
    {
        int Age{get;}
    }

    public class Driver:IDriver
    {
        private int _age;
        public int Age { get { return _age; } }

        public Driver(int age)
        {
            _age = age;
        }

    }

    public interface ICar
    {
        void LockTheCar();
        void Drive(IDriver driver);
    }

    public class Car : ICar
    {
        public void Drive(IDriver driver)
        {
            SingletonPatternLog.AddLog($"Driver age {driver.Age} is driving the car");
        }

        public void LockTheCar()
        {
            throw new NotImplementedException();
        }
    }
}
