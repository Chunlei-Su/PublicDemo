using System;
using System.Threading;

namespace ConsoleApp5               //多线程输出文本的实现
{
    class Program
    {
        static void Main(string[] args)
        {
            //这两个线程是同时运行，每次运行结果都会不同，这要看CPU的调用
            Thread thread1 = new Thread(new ThreadStart(() =>   //lamda表达式
                            {
                                Thread.CurrentThread.Name = "线程1";//给当前线程命名
                                int x = 0;
                                while (true)
                                {
                                    x++;
                                    Console.WriteLine("加     {0}" + Thread.CurrentThread.Name + Thread.CurrentThread.ThreadState, x);//Thread.CurrentThread.ThreadState 获取当前线程的运行情况
                                    if (x == 200)                                             //此处的结果是runing,因为它运行才会输出
                                        break;
                                }
                            }));

            Thread thread2 = new Thread(new ThreadStart(() =>
                        {
                            Thread.CurrentThread.Name = "线程2";
                            int x = 0;
                            while (true)
                            {
                                //这里插入了一个线程2的join方法，意思就是当执行到这里的时候，执行线程1，执行完线程1后再执行本方法的后续语句
                                //这里在没有执行线程2输出语句时就执行线程1，所以结果是一堆加，接着一堆油
                                //thread1.Join();
                                x++;
                                Console.WriteLine("油     {0}" + Thread.CurrentThread.Name + Thread.CurrentThread.ThreadState, x);
                                //thread1.Join();//而在这里呢，是一个油，一堆加，接着一堆油（油先执行了一次）

                                if (x == 200)
                                    break;
                            }
                        }));
            //这两个的优先级都是Normal（平均级）
            //thread1.Start();
            //thread2.Start();
            //下面来改变一下线程的优先级
            thread1.Priority = ThreadPriority.AboveNormal;//高于平均级
            thread2.Priority = ThreadPriority.BelowNormal;//低于平均级
            thread1.Start();
            thread2.Start();
            //关于优先级，不是先执行优先级高的，而是优先级高的占有更多的CPU时间

            //下面实现一个封装线程和调用
            Thr thr = new Thr();
            //调用继承来的start方法实现线程的调用
            thr.start();




            //新建一个线程，复习一下；
            Thread thread3 = new Thread(new ThreadStart(() =>
            {
                //用lamda表达式对新线程写入要执行的代码
                int a = 0;
                while (a < 10)

                {
                    Console.WriteLine("这是个新线程！");
                    a++;
                    //让线程休眠半秒
                    Thread.Sleep(500);
                }
            }
            ));
            thread3.Start();
            Console.ReadKey();
        }
    }
    /// <summary>
    /// 封装一个线程类，实现调用者的多线程能力
    /// 这是个结构
    /// </summary>
    abstract class ther
    {
        Thread Thread = null;
        abstract public void run();
        public void start()
        {
            //如果线程为空，自动创建线程
            if (Thread == null)
            {
                Thread = new Thread(run);
                Thread.Start();
            }
        }
    }
    class Thr : ther   //继承结构
    {
        public override void run()
        {
            Console.WriteLine("多线程能力！");
        }



        public void ThreadDome()
        {
            Thread thread = new Thread(() =>
              {
                  while (true)
                  {
                      Thread.Sleep(300);
                      Console.WriteLine("多线程技术应用！");
                  }
              });
            thread.IsBackground = true;
            thread.Start();
            
        }


    }
}
