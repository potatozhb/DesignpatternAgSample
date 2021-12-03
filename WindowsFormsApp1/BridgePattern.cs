using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public abstract class ElectronicAbsBridgePattern
    {
        public abstract void PowerOn();
        public abstract void PowerOff();
        public abstract void VolumeUp();
        public abstract void VolumeDown();
        public abstract void ChannelUp();
        public abstract void ChannelDown();
        
    }

    public class Television : ElectronicAbsBridgePattern
    {

        private bool isPowerOn = false;
        private int CurrentChannel = 0;
        private int MaxChannel = 0;
        private int Volume = 0;

        public Television(int maxChannel)
        { 
            this.MaxChannel = maxChannel;
        }

        public override void ChannelDown()
        {
            if (CurrentChannel > 1)
                CurrentChannel--;
            else
                CurrentChannel = MaxChannel;
        }

        public override void ChannelUp()
        {
            if (CurrentChannel > MaxChannel)
                CurrentChannel = 1;
            else
                CurrentChannel++;
        }

        public override void PowerOff()
        {
            isPowerOn = false;
        }

        public override void PowerOn()
        {
            isPowerOn = true;
        }

        public override void VolumeDown()
        {
            if (Volume > 0)
            {
                Volume--;
                SingletonPatternLog.AddLog("Current volume is " + Volume);
            }
            else
                SingletonPatternLog.AddLog("Minimum volume " + Volume);
        }

        public override void VolumeUp()
        {

            if (Volume < 100)
            {
                Volume++;
                SingletonPatternLog.AddLog("Current volume is " + Volume);
            }
            else
                SingletonPatternLog.AddLog("Maxmum volume " + Volume);
        }

        public void Pause()
        {
            SingletonPatternLog.AddLog("Current TV is paused");
        }
    }

    public interface interfaceRemote
    {
        void PowerOn();
        void PowerOff();
        void VolumeUp();
        void VolumeDown();
        void ChannelUp();
        void ChannelDown();
    }

    public class RemoteTVpause : interfaceRemote
    {
        Television myTV;
        public RemoteTVpause(Television tv)
        {
            this.myTV = tv;
        }

        public void ChannelDown()
        {
            myTV.ChannelDown();
        }

        public void ChannelUp()
        {
            myTV.ChannelUp();
        }

        public void PowerOff()
        {
            myTV.PowerOff();
        }

        public void PowerOn()
        {
            myTV.PowerOn();
        }

        public void VolumeDown()
        {
            myTV.VolumeDown();
        }

        public void VolumeUp()
        {
            myTV.VolumeUp();
        }

        public void pause()
        {
            myTV.Pause();
        }
    }
}
