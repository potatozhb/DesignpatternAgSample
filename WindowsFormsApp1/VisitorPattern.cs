using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class VisitorPattern
    {
        public void Run()
        {
            NormalDay normalDay = new NormalDay();
            Holiday holiday = new Holiday();

            Liquor liquor = new Liquor(1.2);
            Electronics electronics = new Electronics(2.4);
            Cloth cloth = new Cloth(3.6);

            liquor.Accepted(normalDay);
            liquor.Accepted(holiday);
            electronics.Accepted(normalDay);
            electronics.Accepted(holiday);
            cloth.Accepted(normalDay);
            cloth.Accepted(holiday);
        }
    }

    public interface ISupperMarket
    {// be visited place

        double visit(Liquor item);
        double visit(Electronics item);
        double visit(Cloth item);
    }

    public class NormalDay : ISupperMarket
    {
        public double visit(Liquor item)
        {
            double rs = item.GetPrice() * 1.18;
            SingletonPatternLog.AddLog("Liquor price is " + rs);
            return rs;
        }

        public double visit(Electronics item)
        {
            double rs = item.GetPrice() * 1.28;
            SingletonPatternLog.AddLog("Electronics price is " + rs);
            return rs;
        }

        public double visit(Cloth item)
        {
            double rs = item.GetPrice() * 1.38;
            SingletonPatternLog.AddLog("Cloth price is " + rs);
            return rs;
        }
    }


    public class Holiday : ISupperMarket
    {
        public double visit(Liquor item)
        {
            double rs = item.GetPrice() * 1.08;
            SingletonPatternLog.AddLog("Liquor holiday price is " + rs);
            return rs;
        }

        public double visit(Electronics item)
        {
            double rs = item.GetPrice() * 1.08;
            SingletonPatternLog.AddLog("Electronics holiday price is " + rs);
            return rs;
        }

        public double visit(Cloth item)
        {
            double rs = item.GetPrice() * 1.08;
            SingletonPatternLog.AddLog("Cloth holiday price is " + rs);
            return rs;
        }
    }

    public interface IVisitor
    {
        void Accepted(ISupperMarket visitaddress);
    }

    public class Liquor : IVisitor
    {
        double _price = 0;
        public Liquor(double d)
        {
            _price = d;
        }

        public double GetPrice()
        {
            return _price;
        }

        public void Accepted(ISupperMarket visitaddress)
        {
            visitaddress.visit(this);
        }
    }

    public class Electronics : IVisitor
    {
        double _price = 0;
        public Electronics(double d)
        {
            _price = d;
        }

        public double GetPrice()
        {
            return _price;
        }

        public void Accepted(ISupperMarket visitaddress)
        {
            visitaddress.visit(this);
        }
    }

    public class Cloth : IVisitor
    {
        double _price = 0;
        public Cloth(double d)
        {
            _price = d;
        }

        public double GetPrice()
        {
            return _price;
        }

        public void Accepted(ISupperMarket visitaddress)
        {
            visitaddress.visit(this);
        }
    }


}
