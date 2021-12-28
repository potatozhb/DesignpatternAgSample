using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class LazyInitializationPattern
    {
        public void Run()
        {
            OrdersV1 orders = new OrdersV1();
            orders.ShowAll();
            orders.GetOrdersByTypeName(OrderType.Add);
            orders.GetOrdersByTypeName(OrderType.Remove);
            orders.GetOrdersByTypeName(OrderType.Add);
            orders.GetOrdersByTypeName(OrderType.Add);

            orders.ShowAll();

            SingletonPatternLog.AddLog("Lazy V2");

            OrdersV2 v2 = new OrdersV2();
            v2.ShowAll();
        }
    }

    public class OrdersV1
    {//multiton and lazy pattern
        private Dictionary<string,IOrder> _orders = new Dictionary<string, IOrder>();
        public IOrder GetOrdersByTypeName(OrderType type)
        {
            IOrder order;
            if(!_orders.TryGetValue(type.ToString(), out order))
            {
                switch((int)type)
                {
                    case 0:
                        order = new AddOrder("Add",type.ToString());
                        break;
                    case 1:
                        order = new RemoveOrder("Remove", type.ToString());
                        break;
                }
                _orders.Add(type.ToString(), order);
            }
            return order;
        }

        public void ShowAll()
        {
            foreach (string type in _orders.Keys)
            {
                if (_orders[type] != null)
                {
                    SingletonPatternLog.AddLog(type);
                    IOrder myorder = (IOrder)_orders[type];
                    myorder.Run();
                }
                else
                    SingletonPatternLog.AddLog("Null value");
            }
        }
    }

    public class OrdersV2
    {
        private Lazy<Dictionary<string, IOrder>> _orders = null;
        public Dictionary<string,IOrder> Orders
        {
            get { return _orders.Value; }
        }

        public OrdersV2()
        {
            _orders = new Lazy<Dictionary<string, IOrder>>(() => CreateOrders());
        }

        public Dictionary<string, IOrder> CreateOrders()
        {
            Dictionary<string, IOrder> temp = new Dictionary<string, IOrder>();
            IOrder order = new AddOrder("Add", "Add");
            temp.Add(order.Name, order);
            order = new RemoveOrder("Remove", "Remove");
            temp.Add(order.Name, order);

            return temp;
        }

        public void ShowAll()
        {
            foreach (string type in _orders.Value.Keys)
            {
                if (_orders.Value[type] != null)
                {
                    SingletonPatternLog.AddLog(type);
                    IOrder myorder = (IOrder)_orders.Value[type];
                    myorder.Run();
                }
                else
                    SingletonPatternLog.AddLog("Null value");
            }
        }
    }

    public enum OrderType
    {
        Add = 0,
        Remove = 1
    }

    public interface IOrder
    {
        string Name { get; }
        string Type { get; }
        void Run();
    }

    public class AddOrder : IOrder
    {
        private string _name;
        public string Name { get => _name; }
        
        private string _type;
        public string Type { get => _type; }

        public AddOrder(string name, string type)
        {
            _name = name;
            _type = type;
        }
        public void Run()
        {
            SingletonPatternLog.AddLog("Run AddOrder.");
        }
    }

    public class RemoveOrder : IOrder
    {
        private string _name;
        public string Name { get => _name; }

        private string _type;
        public string Type { get => _type; }

        public RemoveOrder(string name, string type)
        {
            _name = name;
            _type = type;
        }
        public void Run()
        {
            SingletonPatternLog.AddLog("Run RemoveOrder.");
        }
    }
}
