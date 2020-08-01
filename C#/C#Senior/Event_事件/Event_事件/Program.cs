using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace Event_事件
{
    /// <summary>
    /// 事件初级
    /// </summary>
    /// 一个类最重要的组成成员就是事件，方法，属性
    class Program
    {
        static void Main(string[] args)
        {
            Timer timer=new Timer();
            timer.Interval = 1000;//set timeinteval 1s
            Boy boy=new Boy();
            Girl girl=new Girl();
            timer.Elapsed += boy.Action;    //使用+=订阅事件
            timer.Elapsed += girl.Action;
            timer.Start();
            Console.ReadKey();
        }
    }

    class Boy
    {
        /// <summary>
        /// timer Elapsed的事件处理器     
        /// </summary>
        /// <param name="sender">事件参数</param>
        /// <param name="e">时间参数</param>
        public void Action(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Jump");
        }
    }

    class Girl
    {
        public void Action(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Sing");
        }
    }
}
