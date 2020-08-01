using System;
using System.Threading.Tasks;
using System.Linq;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task = Task.Run(() => { fun(); });

            int[] vs = new int[] { 1, 2, 3, 4, 5 };
            //linQ表达式(和数据库中的select查询超级像)
            //var类型就是系统自动判别类型（这里就是int数组）
            var a = from v in vs    //设置一个变量v，在vs中
                    where v > 2     //查询大于2的数
                    select v;       //查出来的每一个变量v，赋给a
            //foreach 遍历输出
            foreach(var t in a)
            {
                Console.Write(t);
            }
            Console.ReadKey();
        }
        static void fun()
        {
            Console.WriteLine("inner join");
        }
    }
}
