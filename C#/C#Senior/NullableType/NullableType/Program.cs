using System;
using System.Diagnostics;

namespace NullableType
{
    class Program
    {
        static void Main(string[] args)
        {

            //int a=null;
            //Console.WriteLine(a);

            System.Nullable<int> b = new int();
            b = 1;
            //Console.WriteLine(b);
            if (b.HasValue)
            {
                //Console.WriteLine(b.Value);
            }

            int? a = null;
            Console.WriteLine(a ?? 1);

            Person p=null;
            //Console.WriteLine(p?.GetCount() ?? "null");
            Console.WriteLine(p?.GetCount() ?? 0);

        }
    }

    class Person
    {
        public int? a = 10;
        
        public int? GetCount() => a;
    }
}
