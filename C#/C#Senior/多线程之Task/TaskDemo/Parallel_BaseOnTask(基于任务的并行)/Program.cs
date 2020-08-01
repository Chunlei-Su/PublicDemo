using System;
using System.Linq;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Parallel_BaseOnTask_基于任务的并行_
{
    class Program
    {
        static void Main(string[] args)
        {
            //正常的执行顺序就是11 22
            //但使用基于任务的并行方法就使得下方的两个方法在异步情况下一并执行
            //for (int i = 0; i < 10; i++)
            //{
            //    Parallel.Invoke(
            //        () =>
            //        {

            //            Console.WriteLine($"task-{Task.CurrentId} begin");
            //            Console.WriteLine($"task-{Task.CurrentId},threadId--{Thread.CurrentThread.ManagedThreadId}");
            //            Console.WriteLine($"task-{Task.CurrentId} end");
            //        },
            //        () =>
            //        {
            //            Console.WriteLine($"task-{Task.CurrentId} begin");
            //            Console.WriteLine($"task-{Task.CurrentId},threadId--{Thread.CurrentThread.ManagedThreadId}");
            //            Console.WriteLine($"task-{Task.CurrentId} end");
            //        });
            //    Console.WriteLine();
            //}

            //parallel的另外两种用法(并行循环)
            Parallel.For(0, 10, Console.WriteLine);
            Console.WriteLine();
            Parallel.ForEach(Enumerable.Range(0, 10), Console.WriteLine);

            Console.ReadKey();
        }
    }
}
