using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class ChainofResponsibilityPattern
    {
        public void Run()
        {
            AbsChain absChain = new Add().SetNextChain(new Substract()
                .SetNextChain(new Multiply().SetNextChain(new Divide().SetNextChain(new Pow()))));

            Numbers n1 = new Numbers(3, 2, CalculateType.divide);
            Numbers n2 = new Numbers(3, 2, CalculateType.substract);
            Numbers n3 = new Numbers(3, 2, CalculateType.multiply);
            Numbers n4 = new Numbers(3, 2, CalculateType.add);
            Numbers n5 = new Numbers(3, 2, CalculateType.Pow);

            SingletonPatternLog.AddLog(n1.CalType + ", result" + absChain.Calculate(n1));
            SingletonPatternLog.AddLog(n2.CalType + ", result" + absChain.Calculate(n2));
            SingletonPatternLog.AddLog(n3.CalType + ", result" + absChain.Calculate(n3));
            SingletonPatternLog.AddLog(n4.CalType + ", result" + absChain.Calculate(n4));
            SingletonPatternLog.AddLog(n5.CalType + ", result" + absChain.Calculate(n5));
        }
    }

    public abstract class AbsChain
    {
        protected AbsChain nextnode;

        public AbsChain SetNextChain(AbsChain chain)
        {
            AbsChain lastnode = this;
            while(this.nextnode != null)
            {
                lastnode = this.nextnode;
            }

            this.nextnode = chain;
            return this;
        }

        public abstract double? Calculate(Numbers numbers);
    }

    public class Numbers
    {
        private double _number1;
        private double _number2;
        private CalculateType _calType;
        public Numbers(double n1, double n2, CalculateType type)
        {
            _number1 = n1;
            _number2 = n2;
            _calType = type;
        }

        public double Number1 { get { return _number1; } }
        public double Number2 { get { return _number2; } }
        public CalculateType CalType { get { return _calType; } }
    }

    public enum CalculateType
    {
        add = 0,
        substract = 1,
        multiply = 2,
        divide = 3,
        Pow = 4
    }

    public class Add : AbsChain
    {

        public override double? Calculate(Numbers numbers)
        {
            if(numbers.CalType == CalculateType.add)
            {
                SingletonPatternLog.AddLog($"Add {numbers.Number1} and {numbers.Number2}");
                return numbers.Number1 + numbers.Number2;
            }
            else if(this.nextnode != null)
            {
                return this.nextnode.Calculate(numbers);
            }
            else
            {
                return null;
            }
        }
    }

    public class Substract : AbsChain
    {

        public override double? Calculate(Numbers numbers)
        {
            if (numbers.CalType == CalculateType.substract)
            {
                SingletonPatternLog.AddLog($"Substract {numbers.Number1} and {numbers.Number2}");
                return numbers.Number1 - numbers.Number2;
            }
            else if (this.nextnode != null)
            {
                return this.nextnode.Calculate(numbers);
            }
            else
            {
                return null;
            }
        }
    }

    public class Multiply : AbsChain
    {

        public override double? Calculate(Numbers numbers)
        {
            if (numbers.CalType == CalculateType.multiply)
            {
                SingletonPatternLog.AddLog($"Multiply {numbers.Number1} and {numbers.Number2}");
                return numbers.Number1 * numbers.Number2;
            }
            else if (this.nextnode != null)
            {
                return this.nextnode.Calculate(numbers);
            }
            else
            {
                return null;
            }
        }
    }

    public class Divide : AbsChain
    {

        public override double? Calculate(Numbers numbers)
        {
            if (numbers.CalType == CalculateType.divide)
            {
                SingletonPatternLog.AddLog($"Divide {numbers.Number1} and {numbers.Number2}");
                return numbers.Number1 / numbers.Number2;
            }
            else if (this.nextnode != null)
            {
                return this.nextnode.Calculate(numbers);
            }
            else
            {
                return null;
            }
        }
    }

    public class Pow : AbsChain
    {

        public override double? Calculate(Numbers numbers)
        {
            if (numbers.CalType == CalculateType.Pow)
            {
                SingletonPatternLog.AddLog($"Pow {numbers.Number1} and {numbers.Number2}");

                return Math.Pow( numbers.Number1 , numbers.Number2);
            }
            else if (this.nextnode != null)
            {
                return this.nextnode.Calculate(numbers);
            }
            else
            {
                return null;
            }
        }
    }
}
