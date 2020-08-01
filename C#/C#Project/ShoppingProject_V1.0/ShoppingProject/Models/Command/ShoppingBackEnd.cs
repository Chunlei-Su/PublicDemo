using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ShoppingProject.Models.Common;

namespace ShoppingProject.Models.Command
{
    public class ShoppingBackEnd:IShoppingBackEnd
    {
        private readonly IRWXmlConfig _xmlConfig;
        private readonly string connectionString;

        public ShoppingBackEnd(IRWXmlConfig xmlConfig, IConfiguration configuration)
        {
            _xmlConfig = xmlConfig;
            connectionString = configuration.GetConnectionString("DefaultString");
        }

        /// <summary>
        /// 管理员登录
        /// </summary>
        public bool AdminLogin(string adminaccount, string adminpwd)
        {
            string sqlstring = "select COUNT(AdminAccount) from AdminInfo where AdminAccount=@AdminAccount and AdminPwd=@AdminPwd";
            SqlParameter[] parameters = {
                new SqlParameter("@AdminAccount", adminaccount),
                new SqlParameter("@AdminPwd", adminpwd)
            };
            return ToDataBase(sqlstring, parameters, comm => (int) comm.ExecuteScalar() > 0);

        }

        #region 与数据库的操作

        /// <summary>
        /// 与数据库的增删改查操作
        /// </summary>
        /// <typeparam name="T">返回值</typeparam>
        /// <param name="commandString">sql语句</param>
        /// <param name="doFunc">自定义执行委托回调</param>
        /// <returns>T</returns>
        private T ToDataBase<T>(string commandString, SqlParameter[]? parameters, Func<SqlCommand, T> doFunc)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(commandString, connection))
                {
                    try
                    {
                        connection.Open();
                        if (parameters != null)
                            command.Parameters.AddRange(parameters);
                        return doFunc.Invoke(command);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// 通过事务操作数据库(增删改)
        /// </summary>
        private int ToDataBaseWithTransaction(string[] commStrings, SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                //创建一个命令对象
                using (SqlCommand command = connection.CreateCommand())
                {
                    //创建一个事务对象
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            //传入连接对象
                            command.Connection = connection;
                            //传入事务对象
                            command.Transaction = transaction;
                            command.Parameters.AddRange(parameters);
                            //执行事务
                            for (int i = 0; i < commStrings.Length; i++)
                            {
                                command.CommandText = commStrings[i];

                                if (command.ExecuteNonQuery() == 0)
                                {
                                    throw new Exception("执行异常");
                                }
                            }

                            //没有问题直接提交事务
                            transaction.Commit();
                            return 1;
                        }
                        catch (Exception e)
                        {
                            transaction.Rollback();
                            Console.WriteLine(e);
                            return 0;
                        }
                    }
                }
            }
        }

        #endregion
    }
}
