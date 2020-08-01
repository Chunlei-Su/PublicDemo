using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassManageLiarary;

namespace Production_ClassManage
{
    public partial class sginIn : Form
    {
        public sginIn()
        {
            InitializeComponent();
        }

        #region 注册与取消

        /// <summary>
        /// 取消注册关闭窗口
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 鼠标点击注册账号
        /// </summary>
        private void btnSginIn_Click(object sender, EventArgs e)
        {
            if (txtPsd.Text.Trim() == "" || txtUserId.Text.Trim() == "")
            {
                MessageBox.Show("请输入注册信息！", "提示");
                return;
            }
            if (!new DataCheck().checkLoginData(txtPsd.Text.Trim(), txtPsd.Text.Trim()))
            {
                MessageBox.Show("用户名和密码都为6为英文或数字的组合");
                return;
            }
            SqlConnection connection = ManagerConnection.ConSql();
            try
            {
                connection.Open();
                int result = new ManagerCommand(connection).SiginInfo(txtUserId.Text.Trim(), txtPsd.Text.Trim());
                if (result > 0)
                {
                    MessageBox.Show("注册成功！");
                }
                else
                {
                    MessageBox.Show("注册失败！");
                }
            }
            catch(SqlException ex)
            {
                MessageBox.Show("注册失败！原因是：" + ex.Message);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }

        #endregion

    }
}
