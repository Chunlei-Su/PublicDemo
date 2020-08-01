using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationDll
{
    /// <summary>
    /// Student 实体类封装数据
    /// </summary>
    public class Student
    {
        private string sid;
        private string name;
        private string sex;
        private DateTime birth;
        private string speacialty;
        private double score;

        public string Sid { get => sid; set => sid = value; }
        public string Name { get => name; set => name = value; }
        public string Sex { get => sex; set => sex = value; }
        public DateTime Birth { get => birth; set => birth = value; }
        public string Speacialty { get => speacialty; set => speacialty = value; }
        public double Score { get => score; set => score = value; }
    }
}
