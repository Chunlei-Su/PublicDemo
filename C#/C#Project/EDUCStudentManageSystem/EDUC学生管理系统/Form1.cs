using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EducationDll;

namespace EDUC学生管理系统
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region 初始化，登录相关

        /// <summary>
        /// 登录按钮
        /// </summary>
        private void btnlogin_Click(object sender, EventArgs e)
        {
            lbMsg.Text = "";
            //调用验证方法进行数据的验证
            if (new Check().CheckUserPsd(txtuserId.Text, txtPsd.Text))
            {
                SqlConnection connection = ConnectDB.Connect();
                try
                {
                    connection.Open();
                    //调用写好的登录方法
                    SqlDataReader reader = new SqlConCmd(connection).LoginIn(txtuserId.Text, txtPsd.Text);
                    //查到了就继续执行
                    if (reader.HasRows)
                    {
                        MessageBox.Show("登录成功！", "提示");
                        groLoginBox.Visible = false;
                        grologinNow.Visible = true;
                        //拓宽窗口宽度
                        this.Size = new Size(964, 569);
                        lbloginTime.Text = DateTime.Now.ToString();
                        lbuserId.Text = txtuserId.Text;
                        groHost.Visible = true;
                        SeleFiledName();
                    }
                    else
                    {
                        lbMsg.Text = "用户名或密码错误。";
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("登录时遇到问题！原因是:" + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            else
            {
                lbMsg.Text = "用户名为数字或英文6位，密码为6为数字";
            }
        }

        /// <summary>
        /// 查询数据库的字段名并加载至下拉列表框
        /// </summary>
        public void SeleFiledName()
        {
            SqlConnection connection = ConnectDB.Connect();
            try
            {
                connection.Open();
                //调用写好的登录方法
                SqlDataReader reader = new SqlConCmd(connection).SeleFiledName();
                //查到了就继续执行
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        comFiledName1.Items.Add(reader[0].ToString());
                        comFiledName2.Items.Add(reader[0].ToString());
                    }
                    if (comFiledName1.Items.Count > 0)
                    {
                        comFiledName1.SelectedIndex = 0;
                        comFiledName2.SelectedIndex = 0;
                    }
                }
                else
                {
                    lbMsg.Text = "无字段。";
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("查询字段名时出错。原因是:" + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// 注册按钮
        /// </summary>
        private void label5_Click(object sender, EventArgs e)
        {
            new signIn().ShowDialog();
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        private void btnunLogin_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("您确定要退出登录？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                groHost.Visible = false;
                groLoginBox.Visible = true;
                grologinNow.Visible = false;
                this.Size = new Size(352, 569);
            }
        }

        /// <summary>
        /// 窗体加载时初始化窗体大小
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(352, 569);
        }

        /// <summary>
        /// 退出按钮
        /// </summary>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 窗体关闭时进行询问
        /// </summary>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("确认退出?", "提示", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        #endregion

        #region 查询

        /// <summary>
        /// 查询全部记录
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            dbmsg.Text = "";
            //新建一个连接字符串
            SqlConnection connection = ConnectDB.Connect();
            List<object> list = new List<object>();
            try
            {
                connection.Open();
                SqlDataReader reader = new SqlConCmd(connection).AllDataRead();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        list.Add(new { 学号 = reader["SID"].ToString(), 姓名 = reader["Sname"].ToString(), 性别 = reader["Sex"].ToString(), 出生日期 = reader["Birthdate"], 专业 = reader["Specialty"].ToString(), 成绩 = reader["AScores"] });
                    }
                    DView.DataSource = list;
                }
                else
                    dbmsg.Text = "无数据";
            }
            catch (SqlException ex)
            {
                dbmsg.Text = "查询时出错，原因是：" + ex.Message;
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// 根据字段名查询单个记录
        /// </summary>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            dbmsg.Text = "";
            //新建一个连接字符串
            SqlConnection connection = ConnectDB.Connect();
            List<object> list = new List<object>();
            try
            {
                connection.Open();
                //调用方法传入字段名和要查询的数据进行查询
                SqlDataReader reader = new SqlConCmd(connection).seleSID(txtSID.Text.Trim(), comFiledName1.Text);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        list.Add(new { 学号 = reader["SID"].ToString(), 姓名 = reader["Sname"].ToString(), 性别 = reader["Sex"].ToString(), 出生日期 = reader["Birthdate"], 专业 = reader["Specialty"].ToString(), 成绩 = reader["AScores"] });
                    }
                    DView.DataSource = list;
                }
                else
                    dbmsg.Text = "无数据";
            }
            catch (SqlException ex)
            {
                dbmsg.Text = "查询时出错，原因是：" + ex.Message;
            }
            finally
            {
                connection.Close();
            }
        }

        #endregion

        #region 更新数据

        /// <summary>
        /// 更新数据
        /// </summary>
        private void btnUpdata_Click(object sender, EventArgs e)
        {
            if (txtUPnew.Text == "" || txtUPsid.Text == "")
            {
                dbmsg.Text = "请输入正确的数据。";
            }
            SqlConnection connection = ConnectDB.Connect();
            try
            {
                connection.Open();
                int a = new SqlConCmd(connection).Update(txtUPsid.Text.Trim(), comFiledName2.Text, txtUPnew.Text.Trim());
                if (a > 0)
                    dbmsg.Text = "修改成功！";
                else
                    dbmsg.Text = "修改失败，原因可能为id错误。";
            }
            catch (SqlException ex)
            {
                dbmsg.Text = "更新时出错，原因是：" + ex.Message;
            }
            finally
            {
                connection.Close();
            }
        }

        #endregion

        #region 删除数据

        /// <summary>
        /// 删除数据行
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否执行删除操作？", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            SqlConnection connection = ConnectDB.Connect();
            try
            {
                connection.Open();
                int a = new SqlConCmd(connection).DelData(txtDesid.Text.Trim());
                if (a > 0)
                    dbmsg.Text = "删除成功！";
                else
                    dbmsg.Text = "删除失败！可能是id错误。";
            }
            catch (SqlException ex)
            {
                dbmsg.Text = "删除时出错，原因是：" + ex.Message;
            }
            finally
            {
                connection.Close();
            }
        }

        #endregion

        #region 插入数据

        /// <summary>
        /// 插入数据
        /// </summary>
        private void btnINsert_Click(object sender, EventArgs e)
        {
            dbmsg.Text = "";
            Check check = new Check();
            string result = check.CheckInsertData(txtINsid.Text.Trim(), txtINsname.Text.Trim(), txtINscores.Text.Trim());
            if (result.Equals("true"))
            {
                SqlConnection connection = ConnectDB.Connect();
                try
                {
                    Student student = new Student();
                    student.Sid = txtINsid.Text.Trim();
                    student.Name = txtINsname.Text.Trim();
                    if (rdoMen.Checked == true)
                        student.Sex = "男";
                    else
                        student.Sex = "女";
                    student.Birth = dateIN.Value;
                    student.Speacialty = txtINspe.Text.Trim();
                    student.Score =Convert.ToDouble( txtINscores.Text.Trim());
                    connection.Open();
                    int a = new SqlConCmd(connection).AddData(student);
                    if (a > 0)
                        dbmsg.Text = "插入成功！";
                    else
                        dbmsg.Text = "插入失败。";
                }
                catch (SqlException ex)
                {
                    dbmsg.Text = "插入时出错，原因是：" + ex.Message;
                }
                finally
                {
                    connection.Close();
                }
            }
            else
            {
                dbmsg.Text = result;
            }
        }

        #endregion
    }
}
