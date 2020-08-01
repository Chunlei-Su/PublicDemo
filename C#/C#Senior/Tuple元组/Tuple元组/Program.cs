using System;

namespace Tuple元组
{
    class Program
    {
        static void Main(string[] args)
        {
            //tuple是存放一组数据的一个结构
            // Tuple<int, string> tuple = new Tuple<int, string>(1, "你好");
            //var tupledata=("你好",1,2);   //定义一个tuple
            ////输出tuple的值要使用.item1.2.3···这样的形式
            //Console.WriteLine(tupledata.Item1);
            //Console.WriteLine(tupledata.Item2);
            //Console.WriteLine(tupledata.Item3);

            //元组是值类型，可读写的
            //tupledata.Item1 = "你不好";
            //int a = tuple.Item1;
            //string b = tuple.Item2;
            ////tuple也是可预定义类型的,实例如下
            //(int,int)tupledemo = (1, 2);

            //Console.WriteLine(returnTuple());

            //tuple也是可以自定义元素名字的
            //var tup = (name: 1, age: 2);
            //Console.WriteLine(tup.Item1);   //之前的调用方法依然是可用的
            //Console.WriteLine(tup.age);

            //deconstruction模式可以把tuple反拆分
            //就是将数据从元组中分离成单个的数据
            //(int name, int age) = tup;
            //这样就把元组数据拆分成了多个数据
            //Console.WriteLine(name);
            //Console.WriteLine(age);

            //Console.WriteLine("Hello World!");
            //var result = returnTuple();
            //Console.WriteLine(result.Item1);
            //Console.WriteLine(result.Item2);




            MyStruct test = new MyStruct
            {
                id = 1,
                name = "小艺"
            };
            Console.WriteLine(test.id);
            Console.WriteLine(test.name);
            Console.ReadKey();
        }

        //元组是可以作为返回值的
        static (int, string) returnTuple() => (1, "你好");


       

    }

    struct MyStruct
    {
        public int id;
        public string name;
    }
}
