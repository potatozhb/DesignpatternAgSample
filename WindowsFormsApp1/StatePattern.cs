using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class StatePattern
    {
        public void RunStatePattern()
        {
            ATMmachine atm = new ATMmachine(2000);
            atm.InsertCard();
            atm.InsertCard();
            atm.InputPin(1234);
            atm.InputPin(2344);

        }
    }

    public interface IATMmachinestate
    {
        void InsertCard();
        void RejectCard();
        void InputPin(int pin);
        void RequestMoney(int money);
    }

    public class HasCardState : IATMmachinestate
    {
        private ATMmachine mATMMachine;

        public HasCardState(ATMmachine newmachine)
        {
            mATMMachine = newmachine;
        }

        public void InputPin(int pin)
        {
            if (pin == mATMMachine.GetRightPin())
                SingletonPatternLog.AddLog("Pin is right");
            else
            {
                SingletonPatternLog.AddLog("Pin is wrong");
                mATMMachine.RejectCard();
            }
        }

        public void InsertCard()
        {
            SingletonPatternLog.AddLog("Already has a card");
        }

        public void RequestMoney(int money)
        {
            throw new NotImplementedException();
        }

        public void RejectCard()
        {
            SingletonPatternLog.AddLog("Card is rejected");
            mATMMachine.ChangeState(mATMMachine.getNoCardState());
        }
    }

    public class NoCardState : IATMmachinestate
    {
        private ATMmachine mATMMachine;

        public NoCardState(ATMmachine newmachine)
        {
            mATMMachine = newmachine;
        }
        public void InputPin(int pin)
        {
            throw new NotImplementedException();
        }

        public void InsertCard()
        {
            SingletonPatternLog.AddLog("Card is inserted");
            mATMMachine.ChangeState(mATMMachine.getHasCardState());

        }

        public void RequestMoney(int money)
        {
            throw new NotImplementedException();
        }

        public void RejectCard()
        {
            throw new NotImplementedException();
        }
    }

    public class PinRightState : IATMmachinestate
    {
        private ATMmachine mATMMachine;

        public PinRightState(ATMmachine newmachine)
        {
            mATMMachine = newmachine;
        }
        public void InputPin(int pin)
        {
            throw new NotImplementedException();
        }

        public void InsertCard()
        {
            throw new NotImplementedException();
        }

        public void RequestMoney(int money)
        {
            throw new NotImplementedException();
        }

        public void RejectCard()
        {
            throw new NotImplementedException();
        }
    }

    public class NoCashState : IATMmachinestate
    {
        private ATMmachine mATMMachine;

        public NoCashState(ATMmachine newmachine)
        {
            mATMMachine = newmachine;
        }
        public void InputPin(int pin)
        {
            throw new NotImplementedException();
        }

        public void InsertCard()
        {
            throw new NotImplementedException();
        }

        public void RequestMoney(int money)
        {
            throw new NotImplementedException();
        }

        public void RejectCard()
        {
            throw new NotImplementedException();
        }
    }

    public class ATMmachine
    {
        IATMmachinestate machineState;

        IATMmachinestate hasCardState;
        IATMmachinestate noCardState;
        IATMmachinestate pinRightState;
        IATMmachinestate noCashState;

        int nMaxCash = 0;
        int defaultPin = 1234;

        public ATMmachine(int maxCash)
        {
            nMaxCash = maxCash;
            hasCardState = new HasCardState(this);
            noCardState = new NoCardState(this);
            pinRightState = new PinRightState(this);
            noCardState = new NoCardState(this);

            machineState = noCardState;
        }

        public int GetRightPin()
        {
            return defaultPin;
        }

        public void ChangeState(IATMmachinestate newstate)
        {
            machineState = newstate;
        }

        public void InsertCard()
        {
            machineState.InsertCard();
        }
        public void RejectCard()
        {
            machineState.RejectCard();
        }
        public void InputPin(int pin)
        {
            machineState.InputPin(pin);
        }
        public void RequestMoney(int money)
        {
            machineState.RequestMoney(money);
        }

        public IATMmachinestate getHasCardState()
        {
            return hasCardState;
        }
        public IATMmachinestate getNoCardState()
        {
            return noCardState;
        }
        public IATMmachinestate getPinRightState()
        {
            return pinRightState;
        }
        public IATMmachinestate getNoCashState()
        {
            return noCashState;
        }

    }
}
