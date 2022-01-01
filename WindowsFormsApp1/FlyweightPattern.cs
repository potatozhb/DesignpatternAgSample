using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class FlyweightPattern
    {       

        public void RunNormal()
        {
            long start = DateTime.Now.Ticks;
            List<IVehicle> list = new List<IVehicle>();
            for (int i = 0; i<10_000_000; i++)
            {
                list.Add(VehicleManager.BulidFord());
            }
            long end = DateTime.Now.Ticks;
            SingletonPatternLog.AddLog((end - start).ToString());
        }
        public void RunFlyweight()
        {
            long start = DateTime.Now.Ticks;
            List<IVehicle> list = new List<IVehicle>();
            for (int i = 0; i<10_000_000; i++)
            {
                list.Add(VehicleManager.BulidBMW());
            }
            long end = DateTime.Now.Ticks;
            SingletonPatternLog.AddLog((end - start).ToString());
        }
    }

    public class FlyweighFactory
    {
        private static Dictionary<string, SharedVehicleInfo> sharedInfo = new Dictionary<string, SharedVehicleInfo>();

        public static SharedVehicleInfo GetInfo(string type, string engine, string color)
        {
           
               SharedVehicleInfo vehicleInfo;
            if(!sharedInfo.TryGetValue(type, out vehicleInfo))
            {                
                vehicleInfo = new SharedVehicleInfo(engine, color);

                sharedInfo.Add(type, vehicleInfo);

                return vehicleInfo;
            }

            return sharedInfo[type];
        }
    }

    public class SharedVehicleInfo
    {
        private string  _color, _engine;

        public string Color => _color;

        public string Engine => _engine;

        public SharedVehicleInfo(string engine, string color)
        {
            _color = color;
            _engine = engine;
        }
    }

    public class VehicleManager
    {
        public static BMWcar BulidBMW()
        {
            return new BMWcar("4 cylinder", "Yellow");
        }

        public static Fordcar BulidFord()
        {
            return new Fordcar("6 cylinder", "Red");
        }

    }

    public interface IVehicle
    {
        string Color { get; }
        string Engine { get; }
        void SetMaxSpeed(int maxSpeed);
    }

    public class BMWcar : IVehicle
    {
        private int _maxSpeed = 0;

        //shared info, assume same type has same engine and color
        //private string _color, _engine;
        //public string Color { get => _color; }
        //public string Engine { get => _engine; }

        public string Color { get => _vehicleInfo.Color; }
        public string Engine { get => _vehicleInfo.Engine; }
        SharedVehicleInfo _vehicleInfo;

        //private info
        private long _uid;
        public long UID { get => _uid; }


        public BMWcar(string engine, string color)
        {
            _uid = DateTime.Now.Ticks;
            //_color = color;
            //_engine=engine;
            _vehicleInfo = FlyweighFactory.GetInfo(this.GetType().Name,engine,color);
        }
        public void SetMaxSpeed(int maxSpeed)
        {
            _maxSpeed = maxSpeed;
        }
    }


    public class Fordcar : IVehicle
    {
        private int _maxSpeed = 0;

        //shared info, assume same type has same engine and color
        private string _color, _engine;
        public string Color { get => _color; }
        public string Engine { get => _engine; }

        //public string Color { get => _vehicleInfo.Color; }
        //public string Engine { get => _vehicleInfo.Engine; }
        //SharedVehicleInfo _vehicleInfo;

        //private info
        private string _uid;
        public string UID { get => _uid; }


        public Fordcar(string engine, string color)
        {
            _uid = DateTime.Now.GetHashCode().ToString();
            _color = color;
            _engine=engine;
            //_vehicleInfo = FlyweighFactory.GetInfo(this.GetType().Name, engine, color);
        }
        public void SetMaxSpeed(int maxSpeed)
        {
            _maxSpeed = maxSpeed;
        }
    }
}
