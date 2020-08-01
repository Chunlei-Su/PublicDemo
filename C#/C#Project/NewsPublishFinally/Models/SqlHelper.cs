using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    //sql工具类

    public class SqlHelper
    {
        private string conStr;
        private readonly IConfiguration configuration;

        public SqlHelper(IConfiguration configuration)
        {
            conStr = configuration.GetConnectionString("DefaultConection");
        }

        /// <summary>
        /// 执行增删改的方法
        /// </summary>
        /// <param name="tSql">传入的命令语句</param>
        /// <param name="pms">可变参数数组（不知道用户会传入多少参数，使用此方法）</param>
        /// <returns>返回受影响的行数</returns>
        /// params关键字修饰可变长参数数组
        /// 方法声明中的 params 关键字之后不允许任何其他参数，并且在方法声明中只允许一个 params 关键字。
        public int ExecuteNonQuery(string tSql, params SqlParameter[] pms)
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                using (SqlCommand command = new SqlCommand(tSql, connection))
                {
                    if (pms != null)
                    {
                        command.Parameters.AddRange(pms);
                    }
                    try
                    {
                        connection.Open();
                        return command.ExecuteNonQuery();
                    }
                    catch
                    {
                        return 0;
                    }
                }
            }
        }

        /// <summary>
        /// 执行返回一个参数的方法
        /// </summary>
        /// <param name="tSql">传入的命令语句</param>
        /// <param name="pms">可变参数数组（不知道用户会传入多少参数，使用此方法）</param>
        public object ExecuteScalar(string tSql, params SqlParameter[] pms)
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                using (SqlCommand command = new SqlCommand(tSql, connection))
                {
                    if (pms != null)
                    {
                        command.Parameters.AddRange(pms);
                    }
                    try
                    {
                        connection.Open();
                        return command.ExecuteScalar();
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
        }

        /// <summary>
        /// 执行返回多行数据的sqldatareader对象
        /// </summary>
        /// <param name="tSql">sql语句</param>
        /// <param name="pms">参数</param>
        public SqlDataReader ExecuteReader(string tSql, params SqlParameter[] pms)
        {
            SqlConnection connection = new SqlConnection(conStr);
            using (SqlCommand command = new SqlCommand(tSql, connection))
            {
                if (pms != null)
                {
                    command.Parameters.AddRange(pms);
                }
                //connection因为没有放在using中出了错不会自动释放对象，所以需要在此加入一个try
                try
                {
                    connection.Open();
                    //为了避免使用完毕对象不自动删除的情况，再调用这个方法时传入CommandBehavior.CloseConnection枚举，这个枚举指示在将来赋给的sqldatareader对象使用完毕后，连同内部使用的连接对象一并删除，防止连接一直处于打开状态
                    return command.ExecuteReader(CommandBehavior.CloseConnection);

                }
                catch
                {
                    //保证出错后也会正常关闭
                    connection.Close();
                    connection.Dispose();
                    //将异常上抛
                    throw;
                }
            }
        }

    }
}
