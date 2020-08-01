using System;
using System.Threading;

namespace ConsoleApp3               //事件
{       /// <summary>
        /// 声明一个委托
        /// </summary>
        public delegate void dele();
        
    class Program
    {
        /// <summary>
        /// 声明一个委托类型的事件
        /// </summary>
        public static event dele ShiJ; 

        static void Main(string[] args)
        {
            //实例委托
            dele dele = new dele(Sp);
            dele += Sp; //再传给他一个事件
            Df(dele);
            Sp();
            Js js = new Js();
            //传入委托
            js.Sss(dele);
            js.Ssh();
            Console.WriteLine("Hello World!");
            //实例一个线程
            Thread thread = new Thread(Sp);
            Thread thread2 = new Thread(Sp);
            thread.Start();
            thread2.Start();
            Console.ReadKey();
        }
        static void Df(dele f)
        {
            ShiJ += f;
        }
        static void Po()
        {
           if(ShiJ!=null)
            {
                ShiJ();
            }
        }
        static int a = 0;
        static void Sp()
        {
            a++;
            Console.WriteLine("注册了一个事件，然后回调了它。"+a);
        }
    }
    /// <summary>
    /// 声明一个类
    /// 注册事件并在主方法中调用一个事件
    /// </summary>
    class Js
    {
        //声明一个事件
        public event dele Sh2;
        public void Sss(dele dele)
        {
            //注册一个事件
            Sh2 += dele;
        }
        /// <summary>
        /// 实现一个事件
        /// </summary>
        public void Ssh()
        {
            if(Sh2!=null)
            {
                Sh2();
            }
        }
        private string name;
        public string Name
        {
            get => name;
            set => name = value;
        }
    }
}
