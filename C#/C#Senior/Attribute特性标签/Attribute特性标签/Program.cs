using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Attribute特性标签
{
    class Program
    {
        //attribute是一中扩展机制，它可以为代码元素添加自定义信息
        static void Main(string[] args)
        {
            TestInfo();
            Console.WriteLine(Test);
            Console.ReadKey();
        }


        [XmlElement("Customer", Namespace = "http://oreilly.com")]
        public static int Test=1;
        //attribute参数可以分为两种：
        //位置参数：对应其公共构造函数的参数
        //命名参数：对应公共字段和公共属性（可选）

        //多个attribute可以在一个中括号中隔开也可以放在单独的中阔号中

        //---------------------------------Caller info attribute （调用者的特性标签）

        //针对可选参数的特性标签
        //有三个:
        //[CallerMemberName ]调用者所在的类名
        //[CallerFilePath]调用者的代码文件路径
        //[CallerLineNumber]调用者的行号

        static void TestInfo(
            [CallerMemberName] string Cname = null, 
            [CallerFilePath] string Cpath = null, 
            [CallerLineNumber] int Cline = 0)
        {
            Console.WriteLine(Cname);
            Console.WriteLine(Cpath);
            Console.WriteLine(Cline);
        }

    }

}
