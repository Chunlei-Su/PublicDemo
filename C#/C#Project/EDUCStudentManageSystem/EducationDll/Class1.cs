using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// MCV之底层篇
/// </summary>
namespace EducationDll
{
    /// <summary>
    /// 链接字符串类
    /// </summary>
    public class ConnectDB
    {
        static string con = "server=.;database=EDUC;user id=sa;password=123456";
        public static SqlConnection Connect()
        {
            return new SqlConnection(con);
        }
    }

    /// <summary>
    /// SQL语句操作类
    /// </summary>
    public class SqlConCmd
    {
        //依托于以下所有操作的连接对象
        SqlConnection connection = null;

        #region 初始化
        /// <summary>
        /// 构造传参
        /// </summary>
        /// <param name="connection">传入要操作的数据库连接对象</param>
        public SqlConCmd(SqlConnection connection)
        {
            this.connection = connection;
        }
        #endregion

        #region 查询数据相关操作

        /// <summary>
        /// 查询数据总条数
        /// </summary>
        /// <returns>数据的总条数</returns>
        public int AllDataCount()
        {
            string seleCount = "select count(*) from student";
            SqlCommand command = new SqlCommand(seleCount, connection);
            object value = command.ExecuteScalar();
            return Convert.ToInt32(value);
        }

        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns>返回对象由用户自行解读</returns>
        public SqlDataReader AllDataRead()
        {
            string seleAll = "select SID,Sname,Sex,Birthdate,Specialty,AScores from Student";
            SqlCommand command = new SqlCommand(seleAll, connection);
            return command.ExecuteReader();
        }

        /// <summary>
        /// 根据字段查询数据
        /// </summary>
        /// <param name="seledata">要查询的数据</param>
        /// <param name="filedname">字段名</param>
        /// <returns>返回查到的数据</returns>
        public SqlDataReader seleSID(string seledata, string filedname)
        {
            string selesid =string.Format( "select SID,Sname,Sex,Birthdate,Specialty,AScores from Student where {0}=@sid",filedname);
            SqlCommand command = new SqlCommand(selesid, connection);
            command.Parameters.AddWithValue("@sid", seledata);
            return command.ExecuteReader();
        }

        /// <summary>
        /// 查询数据表的字段名
        /// </summary>
        public SqlDataReader SeleFiledName()
        {
            //查询数据表的字段名
            SqlCommand command = new SqlCommand("select NAME from SYSCOLUMNS where ID=OBJECT_ID('Student')", connection);
            return command.ExecuteReader();
        }


        #endregion

        #region 添加数据操作

        /// <summary>
        /// 向数据库中添加数据
        /// </summary>
        /// <param name="student">封装数据的实体类对象</param>
        /// <returns>返回受影响的行数</returns>
        public int AddData(Student student)
        {
            string com = string.Format("insert into Student(SID,Sname,Sex,Birthdate,Specialty,AScores)values('{0}','{1}','{2}','{3}','{4}','{5}')", student.Sid, student.Name, student.Sex, student.Birth, student.Speacialty, student.Score);
            SqlCommand command = new SqlCommand(com, connection);
            return command.ExecuteNonQuery();
        }

        #endregion

        #region 删除单行数据操作

        /// <summary>
        /// 传入id删除行数据
        /// </summary>
        /// <param name="id">传入要删除的id</param>
        /// <returns>返回受影响的行数</returns>
        public int DelData(string id)
        {
            string com = "delete Student where SID=@sid";
            SqlCommand command = new SqlCommand(com, connection);
            command.Parameters.AddWithValue("@sid", id);
            return command.ExecuteNonQuery();
        }

        #endregion

        #region 根据id更新某项数据

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="id">要更新的id</param>
        /// <param name="filedname">要更新的字段名</param>
        /// <param name="newdata">要更新的数据</param>
        /// <returns>返回受影响的行数</returns>
        public int Update(string id, string filedname, string newdata)
        {
            string com = string.Format("update Student set {0}='{1}' where SID='{2}'", filedname, newdata, id);
            SqlCommand command = new SqlCommand(com, connection);
            return command.ExecuteNonQuery();
        }

        #endregion

        #region 登录

        /// <summary>
        /// 从数据库中比对用户名和密码实现用户的登录
        /// </summary>
        /// <param name="useid">用户名(数字或英文或它们的组合)</param>
        /// <param name="psd">id(数字)</param>
        public SqlDataReader LoginIn(string useid, string psd)
        {
            string com = "select * from UserInfo where UserId=@userid and PassWord=@psd";
            SqlCommand command = new SqlCommand(com, connection);
            command.Parameters.AddWithValue("@userid", useid);
            command.Parameters.AddWithValue("@psd", Convert.ToInt32(psd));
            return command.ExecuteReader();
        }

        #endregion

        #region 注册

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="useid">用户名</param>
        /// <param name="psd">密码</param>
        /// <returns>返回受影响的行数</returns>
        public int signin(string useid, string psd)
        {
            String com = "insert into UserInfo values(@userid,@psd)";
            SqlCommand command = new SqlCommand(com, connection);
            command.Parameters.AddWithValue("@userid", useid);
            command.Parameters.AddWithValue("@psd", psd);
            return command.ExecuteNonQuery();
        }

        #endregion

    }


}
