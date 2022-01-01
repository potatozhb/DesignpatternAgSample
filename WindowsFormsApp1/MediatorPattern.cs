using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class MediatorPattern
    {
        public void Run()
        {
            IMediator concreteMediator = new ConcreteMediator();
            Ring ring = new Ring(concreteMediator);
            Watch watch = new Watch(concreteMediator);
            Phone phone = new Phone(concreteMediator);

            ring.SendMessage("Message from Ring.");
        }

    }

    public interface IMediator
    {
        void Subscribe(ISubscriber mediator);
        void SendMessage(string message);
    }

    public class ConcreteMediator : IMediator
    {
        private readonly List<ISubscriber> _subscribers = new List<ISubscriber>();

        public void SendMessage(string message)
        {
            foreach(var subscriber in _subscribers)
            {
                subscriber.UpdateMessage(message);
            }
        }

        public void Subscribe(ISubscriber subs)
        {
            _subscribers.Add(subs);
        }
    }
    public interface ISubscriber
    {
        void SendMessage(string message);
        void UpdateMessage(string message);
    }

    public class Ring : ISubscriber
    {
        private IMediator _mediator;

        public Ring(IMediator mediator)
        {
            this._mediator = mediator;
            //_mediator.Subscribe(this);
        }

        public void SendMessage(string message)
        {
            _mediator.SendMessage(message);
        }

        public void UpdateMessage(string message)
        {
            SingletonPatternLog.AddLog("Ring got a message: " + message);
        }
    }


    public class Phone : ISubscriber
    {
        private IMediator _mediator;

        public Phone(IMediator mediator)
        {
            this._mediator = mediator;
            _mediator.Subscribe(this);
        }

        public void SendMessage(string message)
        {
            _mediator.SendMessage(message);
        }

        public void UpdateMessage(string message)
        {
            SingletonPatternLog.AddLog("Phone got a message: " + message);
        }
    }


    public class Watch : ISubscriber
    {
        private IMediator _mediator;

        public Watch(IMediator mediator)
        {
            this._mediator = mediator;
            _mediator.Subscribe(this);
        }

        public void SendMessage(string message)
        {
            _mediator.SendMessage(message);
        }

        public void UpdateMessage(string message)
        {
            SingletonPatternLog.AddLog("Watch got a message: " + message);
        }
    }
}
