using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class NullObjectPattern
    {
        public void Run()
        {
            INullVehicle vehicle = GetVehicle();
            vehicle.MaxSpeed();
        }

        public INullVehicle GetVehicle()
        {
            INullVehicle vehicle = AbsVeichle.nullVeichle;
            if(DateTime.Now.Second %2 ==0)
            {
                vehicle = new Bike();
            }

            return vehicle;
        }
    }

    public interface INullVehicle
    {
        void MaxSpeed();
    }

    public abstract class AbsVeichle: INullVehicle
    {
        public static readonly INullVehicle nullVeichle = new NullVeichle();

        private class NullVeichle : AbsVeichle
        {
            public override void MaxSpeed()
            {
                SingletonPatternLog.AddLog("No speed from null veichle");
            }
        }

        public abstract void MaxSpeed();
    }

    public class Bike:AbsVeichle
    {
        public override void MaxSpeed()
        {
            SingletonPatternLog.AddLog("Bike speed is 18km/h");
        }
    }
}
