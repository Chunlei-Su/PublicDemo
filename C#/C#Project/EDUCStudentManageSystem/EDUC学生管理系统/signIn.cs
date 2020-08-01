using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using EducationDll;


namespace EDUC学生管理系统
{
    public partial class signIn : Form
    {
        public signIn()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 注册按钮
        /// </summary>
        private void btnlogin_Click(object sender, EventArgs e)
        {
            lbMsg.Text = "";
            if (new Check().CheckUserPsd(txtuserId.Text, txtPsd.Text))
            {
                //调用连接类返回数据库连接对象
                SqlConnection connection = ConnectDB.Connect();
                try
                {
                    connection.Open();
                    int a = new SqlConCmd(connection).signin(txtuserId.Text, txtPsd.Text);
                    if (a > 0)
                    {
                        MessageBox.Show("注册成功！");
                        Close();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("注册失败！原因:" + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            else
            {
                lbMsg.ForeColor = Color.Red;
                lbMsg.Text = "用户名为数字或英文6位，密码为6为数字";
            }
        }

        //取消按钮
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
