using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClassManageLiarary
{
    /// <summary>
    /// 生成班级管理系统的数据库的连接对象
    /// </summary>
    public class ManagerConnection
    {
        static string conString = "server=.;database=EDUC;user id=sa;password=123456";
        public static SqlConnection ConSql()
        {
            return new SqlConnection(conString);
        }
    }

    /// <summary>
    /// 班级管理系统数据库操作类
    /// </summary>
    public class ManagerCommand
    {
        #region 初始化

        SqlConnection connection = null;
        /// <summary>
        /// 传入必要的数据库连接对象
        /// </summary>
        public ManagerCommand(SqlConnection connection)
        {
            this.connection = connection;
        }

        #endregion

        #region 登录和注册

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userid">用户名</param>
        /// <param name="psd">密码</param>
        /// <returns>返回查到的数据条数</returns>
        public int loginSystem(string userid, string psd)
        {
            string com = "select count(*) from UserInfo where UserId=@id and PassWord=@psd";
            SqlCommand command = new SqlCommand(com, connection);
            command.Parameters.AddWithValue("id", userid);
            command.Parameters.AddWithValue("psd", psd);
            return (int)command.ExecuteScalar();
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="userid">用户名</param>
        /// <param name="psd">密码</param>
        /// <returns>返回受影响的数据条数</returns>
        public int SiginInfo(string userid, string psd)
        {
            string com = "insert into UserInfo values(@id,@psd)";
            SqlCommand command = new SqlCommand(com, connection);
            command.Parameters.AddWithValue("id", userid);
            command.Parameters.AddWithValue("psd", psd);
            return command.ExecuteNonQuery();
        }

        #endregion

        #region 查询数据

        /// <summary>
        /// 查询所有的专业名
        /// </summary>
        /// <returns>返回带有数据的reader对象</returns>
        public SqlDataReader selectSpecialty()
        {
            string com = "select Specialty,SpecialtyId from DepartmentInfo";
            SqlCommand command = new SqlCommand(com, connection);
            return command.ExecuteReader();
        }

        /// <summary>
        /// 查询所有学生数据
        /// </summary>
        /// <returns>返回带有数据的reader对象</returns>
        public SqlDataReader selectAllData()
        {
            string com = "select * from Student";
            SqlCommand command = new SqlCommand(com, connection);
            return command.ExecuteReader();
        }

        /// <summary>
        /// 查询单个学生数据
        /// </summary>
        /// <param name="sid">学号</param>
        /// <returns>返回带有数据的reader对象</returns>
        public SqlDataReader selectSomeoneData(string sid)
        {
            string com = "select * from Student where SID=@sid";
            SqlCommand command = new SqlCommand(com, connection);
            command.Parameters.AddWithValue("@sid", sid);
            return command.ExecuteReader();
        }

        /// <summary>
        /// 查询总页数
        /// </summary>
        /// <returns>返回总页数</returns>
        public int SelectePageCount()
        {
            string com = "select count(SID) from Student";
            SqlCommand command = new SqlCommand(com, connection);
            return (int)command.ExecuteScalar();
        }

        /// <summary>
        /// 查询SID数据
        /// </summary>
        /// <returns>所有学生ID</returns>
        public SqlDataReader SelectSID()
        {
            string com = "select SID,Sname from Student";
            SqlCommand command = new SqlCommand(com, connection);
            return command.ExecuteReader();
        }

        /// <summary>
        /// 查询某个学生某门选课信息
        /// </summary>
        /// <param name="sid">学号</param>
        /// <param name="cid">书号</param>
        /// <returns>返回学生选课信息</returns>
        public SqlDataReader SelectStudentCourse(string sid, string cid)
        {
            string com = "select * from SC where SID=@sid and CID=@cid";
            SqlCommand command = new SqlCommand(com, connection);
            command.Parameters.AddWithValue("@sid", sid);
            command.Parameters.AddWithValue("@cid", cid);
            return command.ExecuteReader();
        }

        /// <summary>
        /// 查询某个学生所有选课信息
        /// </summary>
        /// <param name="sid">学号</param>
        /// <returns>返回学生选课表信息</returns>
        public SqlDataReader SelectStudentAllCourse(string sid)
        {
            string com = "select * from SC where SID=@sid";
            SqlCommand command = new SqlCommand(com, connection);
            command.Parameters.AddWithValue("@sid", sid);
            return command.ExecuteReader(); ;
        }

        /// <summary>
        /// 查询所有学生选课信息
        /// </summary>
        /// <returns>返回所有学生选课信息</returns>
        public SqlDataReader SelectAllStudentCourse()
        {
            string com = "select * from SC";
            SqlCommand command = new SqlCommand(com, connection);
            return command.ExecuteReader();
        }

        /// <summary>
        /// 查询课程选修请况
        /// </summary>
        /// <param name="cid">课程号</param>
        /// <returns>返回数据</returns>
        public SqlDataReader SelectCourseChooseCount(string cid)
        {
            string com = "select ChooseCount from Course where CID=@cid ";
            SqlCommand command = new SqlCommand(com, connection);
            command.Parameters.AddWithValue("@cid", cid);
            return command.ExecuteReader();
        }

        /// <summary>
        /// 查询某个的课程信息
        /// </summary>
        /// 
        /// <returns>返回数据对象</returns>
        public SqlDataReader SelectCourseInfo(string cid)
        {
            string com = "select * from Course";
            SqlCommand command = new SqlCommand(com, connection);
            return command.ExecuteReader();
        }

        /// <summary>
        /// 查询专业课信息
        /// </summary>
        /// <returns>返回查询到的数据</returns>
        public SqlDataReader SelectCourseInfo()
        {
            string com = "select * from Course";
            SqlCommand command = new SqlCommand(com, connection);
            return command.ExecuteReader();
        }

        #endregion

        #region 添加数据

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="manager">封装学生数据的实体类</param>
        /// <returns>受影响的行数</returns>
        public int InsertData(Manager manager)
        {
            string com = "insert into Student(SID,Sname,Sex,Birthdate,Specialty,AScores,logo) values(@sid,@sname,@sex,@birdate,@spec,@scores,@logo)";
            SqlCommand command = new SqlCommand(com, connection);
            command.Parameters.AddWithValue("@sid", manager.Sid);
            command.Parameters.AddWithValue("@sname", manager.Sname);
            command.Parameters.AddWithValue("@sex", manager.Sex);
            command.Parameters.AddWithValue("@birdate", manager.Birthday);
            command.Parameters.AddWithValue("@spec", manager.Specialty);
            command.Parameters.AddWithValue("@scores", manager.Scores);
            command.Parameters.AddWithValue("@logo", manager.Logo);
            return command.ExecuteNonQuery();
        }

        /// <summary>
        /// 添加选课数据
        /// </summary>
        /// <param name="courseInfo">封装选课数据的实体类</param>
        /// <returns>返回受影响的行数</returns>
        /// 使用C#中的事务管理进行数据的添加
        /// 添加数据需要改动两个表：SC的数据，Course表中的选修人数
        public int InsertSC(string sid, string cid)
        {
            string com1 = "insert into SC(SID,CID) values(@sid,@cid)";
            string com2 = "UpDate Course set ChooseCount=ChooseCount+1 where CID=@CidS";

            //使用C#中的事务处理
            SqlTransaction transaction = null;
            try
            {
                //初始化事务
                SqlCommand command = connection.CreateCommand();
                transaction = connection.BeginTransaction();
                command.Connection = connection;
                command.Transaction = transaction;

                //执行任务1
                command.CommandText = com1;
                command.Parameters.AddWithValue("@sid", sid);
                command.Parameters.AddWithValue("@cid", cid);
                command.ExecuteNonQuery();

                //执行任务2
                command.CommandText = com2;
                command.Parameters.AddWithValue("@CidS", cid);
                command.ExecuteNonQuery();

                //提交事务
                transaction.Commit();

                return 1;
            }
            catch (SqlException ex)
            {
                string a = ex.Message;
                //事务回滚
                if (transaction != null)
                    transaction.Rollback();
                return 0;
            }
            finally
            {
                transaction.Dispose();
            }
        }

        /// <summary>
        /// 录入学生成绩
        /// </summary>
        /// <param name="sid">学号</param>
        /// <param name="cid">书号</param>
        /// <param name="Score">成绩</param>
        /// <returns>返回受影响的行数</returns>
        public int WirteStudentScores(string sid, string cid, string Score)
        {
            string com = "UpDate SC set Scores=@sco where SID=@sid and CID=@cid";
            SqlCommand command = new SqlCommand(com, connection);
            command.Parameters.AddWithValue("@sco", Score);
            command.Parameters.AddWithValue("@sid", sid);
            command.Parameters.AddWithValue("@cid", cid);
            return command.ExecuteNonQuery();
        }

        /// <summary>
        /// 添加课程信息
        /// </summary>
        /// <param name="course">课程参数实体类对象</param>
        /// <returns>返回受影响的行数</returns>
        public int InsertCourseInfo(Course course)
        {
            string com = "insert into Course(CID,Cname,Credit) values(@cid,@cname,@credit)";
            SqlCommand command = new SqlCommand(com, connection);
            command.Parameters.AddWithValue("@cid", course.Cid);
            command.Parameters.AddWithValue("@cname", course.Cname);
            command.Parameters.AddWithValue("@credit", course.Credit);
            return command.ExecuteNonQuery();
        }

        #endregion

        #region 删除数据

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id">要删除的id号</param>
        /// <returns>返回受影响的行数</returns>
        public int DeleteData(string id)
        {
            string com = "delete Student where SID=@id";
            SqlCommand command = new SqlCommand(com, connection);
            command.Parameters.AddWithValue("@id", id);
            return command.ExecuteNonQuery();
        }

        #endregion

        #region 更新数据

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="manager">要更新的数据</param>
        /// <returns>受影响的行数</returns>
        public int UpDateData(Manager manager)
        {
            string com = "update Student set Sname=@sname,Sex=@sex,Birthdate=@birdate,Specialty=@spec,AScores=@scores,logo=@logo where SID=@sid";
            SqlCommand command = new SqlCommand(com, connection);
            command.Parameters.AddWithValue("@sname", manager.Sname);
            command.Parameters.AddWithValue("@sex", manager.Sex);
            command.Parameters.AddWithValue("@birdate", manager.Birthday);
            command.Parameters.AddWithValue("@spec", manager.Specialty);
            command.Parameters.AddWithValue("@scores", manager.Scores);
            command.Parameters.AddWithValue("@logo", manager.Logo);
            command.Parameters.AddWithValue("@sid", manager.Sid);
            return command.ExecuteNonQuery();
        }

        #endregion

        #region 封装数据

        /// <summary>
        /// 调用此方法封装数据
        /// </summary>
        /// <param name="SID">学号</param>
        /// <param name="Sname">姓名</param>
        /// <param name="Sex">性别</param>
        /// <param name="Birthdate">生日</param>
        /// <param name="Specialty">专业</param>
        /// <param name="AScores">成绩</param>
        /// <param name="logo">头像数据</param>
        /// <returns></returns>
        public Manager PackData(string SID, string Sname, string Sex, DateTime Birthdate, string Specialty, string AScores, byte[] logo)
        {
            return new Manager(SID, Sname, Sex, Birthdate, Specialty, AScores, logo);
        }

        #endregion

    }

    #region 检查数据

    /// <summary>
    /// 检查数据类
    /// </summary>
    public class DataCheck
    {
        /// <summary>
        /// 检查登录数据是否正确
        /// </summary>
        /// <param name="userid">用户名</param>
        /// <param name="psd">密码</param>
        /// <returns>布尔值</returns>
        public bool checkLoginData(string userid, string psd)
        {
            string patten = "^[0-9A-Za-z]{6}$";
            if (!Regex.IsMatch(userid, patten))
            {
                return false;
            }
            if (!Regex.IsMatch(psd, patten))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 检查方法的重载，用于检查学生数据实体类对象数据是否合格
        /// </summary>
        /// <param name="manager">封装好的实体类</param>
        /// <param name="a">为0时（默认）检查图像是否为空（此项主要用于添加数据的操作）为1时跳过检查图片是否为空（此项用于更新数据）</param>
        /// <returns>检查结果供检查重载方法检查</returns>
        public int checkLoginData(Manager manager, int a = 0)
        {
            //学号
            string patten = "^[0-9]{10}$";
            if (!Regex.IsMatch(manager.Sid, patten))
            {
                return 1;
            }
            //姓名
            patten = "^[\u4e00-\u9fa5]{0,4}$";
            if (!Regex.IsMatch(manager.Sname, patten))
            {
                return 2;
            }
            //生日
            if (manager.Birthday >= DateTime.Now)
            {
                return 3;
            }
            if (manager.Scores != "")
            {
                if (float.Parse(manager.Scores) > 750.0 || float.Parse(manager.Scores) < 0.0)
                {
                    return 4;
                }
            }
            else
            {
                return 6;
            }

            if (a == 0)
            {
                if (manager.Logo == null)
                {
                    return 5;
                }
            }

            return 0;
        }

        /// <summary>
        /// 判断检查结果，并反馈
        /// </summary>
        /// <param name="result">检查实体类的返回值</param>
        /// <returns>返回错误信息，为0则无误</returns>
        public string checkLoginData(int result)
        {
            switch (result)
            {
                case 1: return "学号为10位数字";
                case 2: return "请检查您的姓名";
                case 3: return "请选择的生日有误";
                case 4: return "您输入的成绩有误";
                case 5: return "请选择您的头像";
                case 6: return "请填写所有的信息，不能输入空字符串";
                case 7: return "书号为8位数字";
                case 8: return "书名不能为空";
                case 9: return "学分输入有误";


                default: return "0";
            }
        }

        /// <summary>
        /// 检查方法的重载，用于检查增设课程实体类对象数据是否合格
        /// </summary>
        /// <returns>返回检查结果供检查重载方法检查</returns>
        public int checkLoginData(Course course)
        {
            string patten = "^[0-9]{8}$";
            if (!Regex.IsMatch(course.Cid, patten))
            {
                return 7;
            }
            if (course.Cname=="")
            {
                return 8;
            }
            patten = @"^[0-9]+(.[0-9]{1,2})?$";
            if (!Regex.IsMatch(course.Credit, patten))
            {
                return 9;
            }
            return 0;

        }

    }

    #endregion
}
