using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerEventDefind
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            Waiter waiter = new Waiter();
            customer.Order += waiter.Action;
            //触发事件
            customer.Action();
            customer.PayTheBill();
        }
    }

    /// <summary>
    /// 作为事件参数，要继承于事件参数基类
    /// </summary>
    public class OrderEventArgs : EventArgs
    {
        public string DishName { get; set; }
        public string Size { get; set; }
    }

    //委托是底层基础，事件是上层建筑,事件是用委托实现的，他并不属于委托
    //public delegate void OrderEventHandler(Customer customer, OrderEventArgs e);
    //就像js和jquery

    //(事件的拥有者)
    public class Customer
    {
        //private OrderEventHandler orderEventHandler;

        ////声明事件
        //public event OrderEventHandler Order
        //{
        //    //添加事件
        //    add { this.orderEventHandler += value; }
        //    //删除事件
        //    remove { this.orderEventHandler -= value; }
        //}

        #region 事件的简化声明

        //EventHandler是通用的事件委托
        public event EventHandler Order;

        #endregion


        public double Bill { get; set; }

        public void PayTheBill()
        {
            Console.WriteLine($"I will pay ${Bill}");
        }

        public void Walkin()
        {
            Console.WriteLine("walk into the restaurant");
        }

        public void SitDown()
        {
            Console.WriteLine("SitDown");
        }

        public void Think()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Let me think...");
                Thread.Sleep(500);
            }
            OnOrder("fasedfd","large");
        }

        protected void OnOrder(string dish, string size)
        {
            if (this.Order != null)
            {
                this.Order.Invoke(this, new OrderEventArgs() { DishName = dish, Size = size });
            }
        }
        public void Action()
        {
            Console.ReadLine();
            this.Walkin();
            this.SitDown();
            this.Think();
        }
    }

    //事件的响应者
    public class Waiter
    {
        //处理order
        public void Action(object customerobj, EventArgs e)
        {
            Customer customer = customerobj as Customer;
            OrderEventArgs orderinfo = e as OrderEventArgs;
            Console.WriteLine($"I will server your the dish-{orderinfo.DishName}");
            double price = 10;
            switch (orderinfo.Size)
            {
                case "small": price *= 0.5; break;
                case "large": price *= 1.5; break;
            }

            customer.Bill += price;
        }
    }



}
