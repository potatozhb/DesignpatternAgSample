using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class PlayTV
    {
        public void Play()
        {           

            TVDevice myTV = new TVDevice();
            RemoteController remoteController = new RemoteController(myTV);
            remoteController.GetOnButton.press();
            remoteController.GetVupButton.press();
            remoteController.GetVupButton.pressUndo();
            remoteController.GetVupButton.press();
            remoteController.GetVdownButton.press();
            remoteController.GetVupButton.press();
            remoteController.GetVupButton.press();
            remoteController.GetVupButton.press();
            remoteController.GetOffButton.press();

        }
    }

    public class RemoteController
    {
        TVDevice myTV;
        DeviceButton onButton;
        DeviceButton offButton;
        DeviceButton volumeUpButton;
        DeviceButton volumeDownButton;

        public RemoteController(TVDevice newTV)
        {
            myTV =newTV;
            onButton = new DeviceButton(new TurnTVOn(myTV));
            offButton = new DeviceButton(new TurnTVOFF(myTV));
            volumeUpButton = new DeviceButton(new TurnTVVolumeUp(myTV));
            volumeDownButton = new DeviceButton(new TurnTVVolumeDown(myTV));
        }

        public DeviceButton GetOnButton { get { return onButton; } }
        public DeviceButton GetOffButton { get { return offButton; } }
        public DeviceButton GetVupButton { get { return volumeUpButton; } }
        public DeviceButton GetVdownButton { get { return volumeDownButton; } }
    }

    public class DeviceButton
    {
        private ICommand _command;
        public DeviceButton(ICommand newcommand)
        {
            _command = newcommand;
        }

        public void press()
        {
            _command.Execute();
        }
        public void pressUndo()
        {
            _command.Undo();
        }

    }

    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    public class TurnTVOn : ICommand
    {
        private TVDevice _device;

        public TurnTVOn(TVDevice newtv)
        {
            _device = newtv;
        }

        public void Execute()
        {
            _device.On();
        }

        public void Undo()
        {
            _device.OFF();
        }
    }


    public class TurnTVOFF : ICommand
    {
        private TVDevice _device;

        public TurnTVOFF(TVDevice newtv)
        {
            _device = newtv;
        }

        public void Execute()
        {
            _device.OFF();
        }

        public void Undo()
        {
            _device.On();
        }
    }


    public class TurnTVVolumeUp : ICommand
    {
        private TVDevice _device;

        public TurnTVVolumeUp(TVDevice newtv)
        {
            _device = newtv;
        }

        public void Execute()
        {
            _device.VolumeUp();
        }

        public void Undo()
        {
            _device.VolumeDown();
        }
    }


    public class TurnTVVolumeDown : ICommand
    {
        private TVDevice _device;

        public TurnTVVolumeDown(TVDevice newtv)
        {
            _device = newtv;
        }

        public void Execute()
        {
            _device.VolumeDown();
        }

        public void Undo()
        {
            _device.VolumeUp();
        }
    }

    public class TVDevice : IDevice
    {
        private int volume = 0;
        public void OFF()
        {
            SingletonPatternLog.AddLog("TV is OFF");
        }

        public void On()
        {
            SingletonPatternLog.AddLog("TV is ON");
        }

        public void VolumeDown()
        {
            if(volume >0)
                volume--;
            SingletonPatternLog.AddLog("TV volume is " + volume);
        }

        public void VolumeUp()
        {
            if (volume < 100)
                volume++;
            SingletonPatternLog.AddLog("TV volume is " + volume);
        }
    }

    public interface IDevice
    {
        void On();
        void OFF();
        void VolumeUp();
        void VolumeDown();
    }
    
}
