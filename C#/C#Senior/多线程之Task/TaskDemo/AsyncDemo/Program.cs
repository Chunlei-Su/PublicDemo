using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncDemo
{
    //异步方法
    class Program
    {
        static void Main(string[] args)
        {
            //async标记的方法被称为异步方法
            //异步方法分为两种，一种是返回void或者task，一种是返回task<T>
            //Console.WriteLine($"before async-1 with thread {Thread.CurrentThread.ManagedThreadId}");
            //Console.WriteLine($"before async-2 with thread {Thread.CurrentThread.ManagedThreadId}");

            //GetUp();
            //GetUpSecond();

            //如果在这里直接执行方法获取到result的值，会阻塞线程的执行，这样就失去了异步的效果，所以要把这一步再包装到一个异步方法中
           // Console.WriteLine(GetUpSecond().Result);

           //将异步取值操作封装到一个异步方法中，不会阻塞主线程
           Wrap();


            for (int i = 0; i < 30; i++)
                //Getup( )里await部分的运行，会打乱这里代码的同步运行
                Console.WriteLine($"after async-{3 + i} with thread {Thread.CurrentThread.ManagedThreadId}");
            Console.ReadKey();
        }

        //异步方法尽量使用task作为返回值，就算没用返回值.net也会将这个方法作为一个task返回
        //无返回值或无准确返回值的方法
        public static async void GetUp()
        {
            Console.WriteLine($"before await-1 with thread {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"before await-2 with thread {Thread.CurrentThread.ManagedThreadId}");

            //await之前的代码，在主线程上运行
            //await开始异步执行，方法从这里开始返回调用者
            //await之后的代码一直到方法结束都是在异步上执行
            await Task.Run(() =>
            {
                Console.WriteLine($"in await with thread {Thread.CurrentThread.ManagedThreadId}");
                // Thread.Sleep(2000);
            });

            //task后方的代码实际上是借用于continueWith的原理，让task执行完毕后在去调用后边的代码
            //直到await中内容执行完毕，才开始(但不是立即或同步的)执行await之后的代码
            Console.WriteLine($"after await-3 with thread {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"after await-4 with thread {Thread.CurrentThread.ManagedThreadId}");
        }

        //取异步数据的异步方法，防止主线程被阻塞
        public static async void Wrap()
        {
            Console.WriteLine(await GetUpSecond());
        }

        /// <summary>
        /// 带返回值的异步方法，返回值被task包裹
        /// </summary>
        public static async Task<int> GetUpSecond()
        {
            return await Task.Run(() =>
            {
                //Thread.Sleep(500);
                Console.WriteLine($"at await in Getup() with thread {Thread.CurrentThread.ManagedThreadId}");
                return new Random().Next();
            });
        }

    }
}
