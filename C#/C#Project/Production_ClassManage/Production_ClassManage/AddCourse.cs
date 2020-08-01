using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassManageLiarary;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Production_ClassManage
{
    public partial class AddCourse : Form
    {
        public AddCourse()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 添加该课程
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Course course = new Course(txtCid.Text.Trim(), txtCname.Text.Trim(), numCredit.Value.ToString());
            DataCheck dataCheck = new DataCheck();
            string result = dataCheck.checkLoginData(dataCheck.checkLoginData(course));
            if (result != "0")
            {
                MessageBox.Show(result);
                return;
            }
            SqlConnection connection = ManagerConnection.ConSql();
            try
            {
                connection.Open();
                int a = new ManagerCommand(connection).InsertCourseInfo(course);
                if (a > 0)
                {
                    MessageBox.Show("添加成功", "提示");
                    SelectCourseData();
                }
                else
                {
                    MessageBox.Show("添加失败", "提示");
                }
            }
            catch
            {
                MessageBox.Show("执行添加时出错，原因为：此书号已被使用");
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

        /// <summary>
        /// 窗体加载获取全部信息
        /// </summary>
        private void AddCourse_Load(object sender, EventArgs e)
        {
            SelectCourseData();
        }

        /// <summary>
        /// 获取全部信息
        /// </summary>
        public void SelectCourseData()
        {
            SqlConnection connection = ManagerConnection.ConSql();
            try
            {
                List<object> list = new List<object>();
                connection.Open();
                SqlDataReader reader = new ManagerCommand(connection).SelectCourseInfo();
                while (reader.Read())
                {
                    list.Add(new { CID = reader[0], Cname = reader[1], Credit = reader[2], ChooseCount = reader[3] });
                }
                dastaCourseView.DataSource = list;
            }
            catch
            {
                MessageBox.Show("执行查询时出错，原因为：此书号已被使用");
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }

    }
}
