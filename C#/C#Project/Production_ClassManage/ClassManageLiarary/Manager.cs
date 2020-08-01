using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassManageLiarary
{
    /// <summary>
    /// 封装学生数据的实体类
    /// </summary>
    public class Manager
    {
        #region 

        string sid;
        string sname;
        string sex;
        DateTime birthday;
        string specialty;
        string scores;
        byte[] logo;

        #endregion

        /// <summary>
        /// 全部参数的构造方法
        /// </summary>
        /// <param name="sid">学号</param>
        /// <param name="sname">姓名</param>
        /// <param name="sex"性别></param>
        /// <param name="birthday">生日</param>
        /// <param name="specialty">专业</param>
        /// <param name="scores">成绩</param>
        /// <param name="logo">头像</param>
        public Manager(string sid, string sname, string sex, DateTime birthday, string specialty, string scores, byte[] logo)
        {
            Sid = sid;
            Sname = sname;
            Sex = sex;
            Birthday = birthday;
            Specialty = specialty;
            Scores = scores;
            Logo = logo;
        }

        /// <summary>
        /// 无参构造
        /// </summary>
        public Manager()
        {

        }

        /// <summary>
        /// 学号
        /// </summary>
        public string Sid { get => sid; set => sid = value; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Sname { get => sname; set => sname = value; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get => sex; set => sex = value; }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime Birthday { get => birthday; set => birthday = value; }
        /// <summary>
        /// 专业
        /// </summary>
        public string Specialty { get => specialty; set => specialty = value; }
        /// <summary>
        /// 成绩
        /// </summary>
        public string Scores { get => scores; set => scores = value; }
        /// <summary>
        /// 头像
        /// </summary>
        public byte[] Logo { get => logo; set => logo = value; }
    }

    /// <summary>
    /// 封装登录账号和密码的实体类
    /// </summary>
    public class LoginSigin
    {
        string userId;
        string psd;

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserId { get => userId; set => userId = value; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Psd { get => psd; set => psd = value; }
    }

    /// <summary>
    /// 对象检查类
    /// </summary>
    public class EqualsManager
    {
        /// <summary>
        /// 比对实体类字段是否都相等
        /// </summary>
        /// <param name="manager1">实体类1</param>
        /// <param name="manager2">实体类2</param>
        /// <returns>全部相等返回false 否则true</returns>
        public bool EqualsManagerData(Manager manager1, Manager manager2)
        {
            if (manager2 == null)
            {
                return true;
            }

            if (!(manager1.Sid == manager2.Sid))
            {
                return true;
            }
            if (!(manager1.Sname == manager2.Sname))
            {
                return true;
            }
            if (!(manager1.Sex == manager2.Sex))
            {
                return true;
            }
            if (!(manager1.Birthday == manager2.Birthday))
            {
                return true;
            }
            if (!(manager1.Specialty == manager2.Specialty))
            {
                return true;
            }
            if (!(manager1.Scores == manager2.Scores))
            {
                return true;
            }
            if (!(manager1.Logo == manager2.Logo))
            {
                return true;
            }
            return false;
        }
    }

    /// <summary>
    /// 封装选修信息的实体类
    /// </summary>
    public class CourseInfo : Manager
    {
        string cid;

        public CourseInfo(string sid, string cid)
        {
            this.Sid = sid;
            this.Cid = cid;
        }

        public string Cid { get => cid; set => cid = value; }
    }

    /// <summary>
    /// 封装新增选课数据的实体类
    /// </summary>

    public class Course
    {
        string cid;
        string cname;
        string credit;

        /// <summary>
        /// 构造传参
        /// </summary>
        /// <param name="cid">课程号</param>
        /// <param name="cname">课程名</param>
        /// <param name="credit">课程分</param>
        public Course(string cid, string cname, string credit)
        {
            Cid = cid;
            Cname = cname;
            Credit = credit;
        }

        /// <summary>
        /// 课程号
        /// </summary>
        public string Cid { get => cid; set => cid = value; }
        /// <summary>
        /// 课程名
        /// </summary>
        public string Cname { get => cname; set => cname = value; }
        /// <summary>
        /// 课程学分
        /// </summary>
        public string Credit { get => credit; set => credit = value; }
    }

}
