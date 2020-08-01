using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskDemo
{
    class Program
    {
        //Task在线程池的基础上进行了优化，并提供了更多的API。在FCL4.0中，如果我们要编写多线程程序，Task显然已经优于传统的方式。
        static void Main(string[] args)
        {
            #region Task初步

            //---------------------------------------Task使用方法1
            //Task processTask = new Task(() =>
            //  {
            //      Console.WriteLine("开启了一个新线程");
            //      Thread.Sleep(5000);
            //  });

            ////开始这个异步任务
            ////processTask.Start();

            ////ContinueWith用于创建一个异步任务的延续，在任务执行完毕后执行下面的代码
            //processTask.ContinueWith((task) =>
            //{
            //    Console.WriteLine("任务完成，完成时候的状态为：");
            //    Console.WriteLine("IsCanceled={0}\tIsCompleted={1}\tIsFaulted={2}", task.IsCanceled, task.IsCompleted, task.IsFaulted);
            //});
            //等待异步任务执行完毕，传入异步任务名称
            //Task.WaitAll(processTask);//执行到此处，系统会等待任务执行完毕，不会同时输出‘你好’


            //---------------------------------------Task使用方法2
            //Task.Run(() =>
            //{
            //    Console.WriteLine("开启了一个新线程");
            //    Thread.Sleep(5000);
            //})/*.Wait()使用wait主线程会等待异步执行完毕*/;



            //---------------------------------------Task使用方法3
            //Task.Factory.StartNew(() =>
            //{
            //    Console.WriteLine("开启了一个新线程");
            //    Thread.Sleep(5000);
            //}, TaskCreationOptions.LongRunning); //直接异步的方法,参数2标记为长时间运行任务,则任务不会使用线程池,而在单独的线程中运行。

            //var t3 = Task.Factory.StartNew(() =>
            //{
            //    Console.WriteLine("开启了一个新线程");
            //    Thread.Sleep(5000);
            //});
            //Task.WaitAll(t3);//等待所有任务结束


            //Console.WriteLine("主线程执行业务处理.");
            //AsyncFunction();
            //Console.WriteLine("主线程执行其他处理");
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine(string.Format("Main:i={0}", i));
            //}

            //Console.WriteLine("你好");

            #endregion

            #region Task进一步

            Console.WriteLine($"当前主线程线程托管ID:{ Thread.CurrentThread.ManagedThreadId}");
            
            //创建无参无返回值的委托方法
            Action getup = () =>
            {
                Console.WriteLine($"当前运行的任务ID：{Task.CurrentId}\n当前线程托管ID:{Thread.CurrentThread.ManagedThreadId}");
            };

            //有泛型参数的就是有返回值的，没有泛型参数的就是没有返回值的
            Task teTask=new Task(getup);
            teTask.Start();

            #endregion

            Console.ReadKey();
        }


        public async static void AsyncFunction()
        {
            await Task.Delay(1);
            Console.WriteLine("使用System.Threading.Tasks.Task执行异步操作.");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(string.Format("AsyncFunction:i={0}", i));
            }

            string s = "sds";
            s.Split('a', StringSplitOptions.RemoveEmptyEntries);
        }

    }
}
