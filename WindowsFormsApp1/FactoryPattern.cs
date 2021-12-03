using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public static class FactoryPattern
    {
        public static IBusiness Create()
        {
            var config = Convert.ToBoolean(ConfigurationManager.AppSettings["foo"]);
            if (config)
                return new Business1();
            else
                return new Business2();

        }
    }

    public interface IBusiness
    {
        void produce();

    }
    public class Business1 : IBusiness
    {
        public void produce()
        {
            SingletonPatternLog.AddLog("Hi, this is business 1");
        }
    }

    public class Business2 : IBusiness
    {
        public void produce()
        {
            SingletonPatternLog.AddLog("Hi, this is business 2");
        }
    }
}
