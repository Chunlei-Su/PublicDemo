using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassManageLiarary;

namespace Production_ClassManage
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 弹出注册窗口
        /// </summary>
        private void signIn_Click(object sender, EventArgs e)
        {
            sginIn sgin = new sginIn();
            sgin.ShowDialog();
        }

        #region 登录与取消

        /// <summary>
        /// 登录
        /// </summary>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtPsd.Text.Trim() == "" || txtUserId.Text.Trim() == "")
            {
                MessageBox.Show("请输入登录信息！", "提示");
                return;
            }
            if (!new DataCheck().checkLoginData(txtPsd.Text.Trim(), txtPsd.Text.Trim()))
            {
                MessageBox.Show("用户名和密码都为6为英文或数字的组合");
                return;
            }
            //获取连接对象
            SqlConnection connection = ManagerConnection.ConSql();
            try
            {
                connection.Open();
                int result = new ManagerCommand(connection).loginSystem(txtUserId.Text.Trim(), txtPsd.Text.Trim());
                if (result > 0)
                {
                    MessageBox.Show("登录成功！");
                    Thread thread = new Thread(() =>
                    {
                        new Form1().ShowDialog();
                    });
                    //脱离主线程的绑定
                    thread.SetApartmentState(ApartmentState.STA);
                    thread.Start();
                    Form1.NowLogin = txtUserId.Text;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("登录失败，请检查您的用户名和密码。");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("登录失败。原因：" + ex.Message);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }

        /// <summary>
        /// 取消
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

    }
}
