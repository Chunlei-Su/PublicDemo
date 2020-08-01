using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 9;
            a = a.ExtensionInt(6);
            Debug.WriteLine(a);
        }
    }

   
    //静态类
    public static class TestExtensionM
    {
        //静态方法
        public static int ExtensionInt(this int s,int a)  //this关键字
        {
            return s + a;
        }
    }

}
