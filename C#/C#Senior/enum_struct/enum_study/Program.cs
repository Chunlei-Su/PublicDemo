using System;

namespace enum_struct
{
    //关于枚举的应用
    //声明一个枚举
    public enum MeiJ
    {
        //为枚举添加值
        男,
        女,
        未知性别
        //枚举值最后一项可以有逗号，可以没有，没有更好，可以用来标识是枚举的最后一项
        //枚举的存在就是为了规范开发，枚举本质上是就是一种变量类型，变量的取值范围就是声明枚举时自己
        //写进去的那些值 
        //枚举值可以与int string等类型进行强制转换，int的值是对应的从0开始的枚举值的索引
    }
     
    //关于结构
    public struct JieG
    {
        //结构可以将多个字段方法等属性集成到一个结构类型的变量当中去，减少变量的使用，提高效率
        //字段一般都要在名称前面加上"_"(下划线)
        public string _name;
        public int _age;
    }
    class Program
    {
        static void Main(string[] args)
        {
            //在主方法中调用 
            //为枚举变量赋值
            MeiJ m = MeiJ.男;
            Console.WriteLine(m.ToString());
            //声明一个结构变量
            JieG jie;
            jie._age = 12;
            jie._name = "张三";
            Console.WriteLine("我叫{0}，今年{1}岁了。", jie._name, jie._age);

            Console.ReadKey();

        }
    }
}
