using System;

namespace ConsoleApp2
{
    class Program
    {
        /// <summary>
        /// 新建一个无返回值的委托
        /// </summary>
        delegate void Dele(int d);  //无返回值，无参
        delegate int dEle(int d);   //有返回值，有参
        static void Main(string[] args)
        {
            
            Dele dele =new Dele(sp1);//为委托对象初始化并传参
            dele += sp2;    //通过运算符添加托管方法

            Action<int> newdele=new Action<int>(sp1);
            newdele += sp2;
            newdele(1);

            Wei wei = new Wei();
            dele += Wei.SP;


            dele(1);


            dEle dEle = new dEle(de);
            int f = dEle(2);
            Console.WriteLine("Hello World!"+f.ToString());

            //泛型委托func<>类用于定义一个泛型委托
            Func<int> func = new Func<int>(add);//定义一个返回值为int的泛型委托
            //执行委托方法
            func();
            Action<int>
            Console.ReadKey(); 
        }

        static int add()
        {
            return 3;
        }

        static void  sp1(int a)
        {
            Console.WriteLine("中国！"+a);
        }
        static void sp2(int d)
        {
            Console.WriteLine("新加坡"+d);
        }
        static int de(int s)
        {
            return s * s;
        }
    }
    public  class Wei
    {
        static public void SP(int s)
        {
            Console.WriteLine("英国"+s);
        }
    }
}
