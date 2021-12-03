using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class AdapterPattern:IWarWeapon
    {
        RobotKiller robot = new RobotKiller();

        public AdapterPattern(RobotKiller newrobot)
        {
            this.robot = newrobot;
        }
        public void Fire()
        {
            robot.Laser();
        }

        public void Load()
        {
            robot.Charge();
        }

        public void Operation(string soldier)
        {
            robot.Pilot(soldier);
        }
    }

    public interface IWarWeapon
    {
        void Fire();
        void Load();
        void Operation(string soldier);
    }

    public class Tank:IWarWeapon
    {
        string soldier;

        public void Fire()
        {
            SingletonPatternLog.AddLog("Tank fire");
        }

        public void Load()
        {
            SingletonPatternLog.AddLog("Tank load");
        }

        public void Operation(string name)
        {
            SingletonPatternLog.AddLog($"Tank operator is {name}");
        }
    }

    public class RobotKiller
    {
        string pilot;
        public void Laser()
        {

            SingletonPatternLog.AddLog("RobotKiller laser");
        }

        public void Charge()
        {

            SingletonPatternLog.AddLog("RobotKiller charge");
        }

        public void Pilot(string name)
        {

            SingletonPatternLog.AddLog($"RobotKiller pilot is {name}");
        }
    }
}
