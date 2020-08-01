using System;
using System.Collections.Generic;

namespace 委托和匿名方法和lamda表达式
{
    class Program
    {
        //委托就是把方法当作参数的存在
        //声明委托
        public delegate void Del(string name);//声明一个无返回值，有一个参数的委托类型
        static void Main(string[] args)
        {
            #region 委托
            //调用WeiT方法，传入string值和方法【这是第一种使用委托的方法】
            WeiT("张三", Weit);
            //【第二种使用委托的方法】就是不经过WeiT这个方法，直接实例化委托调用
            Del del = new Del(Weit);
            //现在del就想当与weit方法，直接调用
            del("张三");

            //委托的多播，就是一个委托对象同时执行多个方法具体如下
            Del del11 = Weit;    //把第一个方法传进去
            del11 += WeiT1;
            del11("委托");
            //个人觉得委托的多播只能适用于一部分情况，因为在调用从传值时，所有的方法都被赋值并且都是同一个值
            del11 -= WeiT1;//能加也能减
            del11 = WeiT1;//如果重新赋值的话就会覆盖原有的方法
            //基本上委托就这些，但是委托在方法的传递上有着巨大的作用需要慢慢在实用中不断去体会

            #endregion

            #region 匿名方法
            //使用匿名方法必须先声明委托
            //还是输出“我叫XX”
            Del del1 = delegate (string s)
              {
                  Console.WriteLine("我叫{0}", s);
              };
            //就是在实例化委托的时候写个没有名称的方法直接赋给委托对象
            del1("李四");
            //匿名方法的编写需要与声明的委托签名一致，所有用到委托的都要与声明的委托签名一致
            #endregion

            #region Lamda表达式 
            //lamda表达式是更精简的匿名方法
            Del del2 = (string s) =>
            {
                Console.WriteLine("我叫{0}", s);
            };
            del2("王五");

            //lamda表达式另一种用法
            List<int> vs = new List<int> { 1, 2, 3, 4, 5, 6 };
            vs.RemoveAll(n => n > 4);       //这种lamada表达式的表现形式更简洁（实现移除比4大的值）
            foreach (var s in vs)
                Console.Write(s);

            #endregion

            Console.ReadKey();
        }
        #region 实例方法
        public static void WeiT(string s,Del del)
        {
            //给这个方法传入一个string值和方法
            //委托调用传入的方法
            del(s);
        }
        public static void Weit(string s)
        {
            Console.WriteLine("我叫{0}", s);
        }
        public static void WeiT1(string name)
        {
            Console.WriteLine("{0}的多播", name);
        }
        #endregion
    }
}
