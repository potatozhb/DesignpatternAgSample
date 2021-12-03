using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    //bulid a roboter
    public class BuilderPattern : IWantBuild
    {
        CanBulid robot = new CanBulid("Lily");

        public void BulidArms()
        {
            robot.BulidArms("short arms");
        }

        public void BulidHead()
        {
            robot.BulidHead("big head");
        }

        public void BulidLegs()
        {
            robot.BulidLegs("strong legs");
        }

        public void BulidTorso()
        {
            robot.BulidTorso("thin torso");
        }

        public CanBulid GetProduct()
        {
            return robot;
        }
    }

    public interface IWantBuild
    {
        void BulidHead();
        void BulidTorso();
        void BulidArms();
        void BulidLegs();
        CanBulid GetProduct();
    }

    public class CanBulid : IcanBulid
    {
        string productname;
        string myhead, mytorso, myarms, mylegs;

        public CanBulid(string newproduct)
        {
            productname = newproduct;

            SingletonPatternLog.AddLog($"my name is {newproduct}");
        }

        public void BulidArms(string arms)
        {
            myarms = arms;
            SingletonPatternLog.AddLog($"Build Arms: {arms}");
        }

        public void BulidHead(string head)
        {
            myhead = head;
            SingletonPatternLog.AddLog($"Build Arms: {head}");
        }

        public void BulidLegs(string legs)
        {
            mylegs = legs;
            SingletonPatternLog.AddLog($"Build Arms: {legs}");
        }

        public void BulidTorso(string torso)
        {
            mytorso = torso;
            SingletonPatternLog.AddLog($"Build Arms: {torso}");
        }

        public string GetProduct()
        {
            SingletonPatternLog.AddLog($"my name is { productname} ");
            return productname;
        }
    }

    public interface IcanBulid
    {
        void BulidHead(string head);
        void BulidTorso(string torso);
        void BulidArms(string arms);
        void BulidLegs(string legs);
        string GetProduct();
    }
}
