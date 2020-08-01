using System;
using System.Collections.Generic;
using System.IO;

namespace 索引器indexer
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student=new Student();
            student["数学"] = null;
            Console.WriteLine(student["数学"]);
            Console.ReadKey();
        }
    }

    public class Student
    {
        private Dictionary<string,int> courseDirectory=new Dictionary<string, int>();

        //定义一个索引器
        public int? this[string cname]
        {
            get
            {
                if (this.courseDirectory.ContainsKey(cname))
                {
                    return courseDirectory[cname];
                }

                return null;
            }
            set
            {
                if (this.courseDirectory.ContainsKey(cname))
                {
                    courseDirectory[cname] = value??0;
                }
                else
                {
                    courseDirectory.Add(cname,value??0);
                }

            }
        }

    }

}
