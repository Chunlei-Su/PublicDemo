using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ClassManageLiarary;
using System.Text.RegularExpressions;

namespace Production_ClassManage
{
    public partial class ChooseCourse : Form
    {
        public ChooseCourse()
        {
            InitializeComponent();
        }

        #region 事件

        /// <summary>
        /// 窗体加载
        /// </summary>
        private void ChooseCourse_Load(object sender, EventArgs e)
        {
            //查询可选课程
            ShowCourseName();
            //查学号
            ShowSID();
            //查选修人数
            SelectCourseChooseCount();

        }

        /// <summary>
        /// 选修
        /// </summary>
        private void btnChoose_Click(object sender, EventArgs e)
        {
            if (SelectStuCourse(0) >= 3)
            {
                MessageBox.Show("该学生已完成三门选课，不可再选", "提示");
                return;
            }

            if (MessageBox.Show("学生名：" + cmbSid.Text + "，要选修的课程名：" + cmbCourse.Text, "确认选修此课程？", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                MessageBox.Show("操作已取消");
                return;
            }

            SqlConnection connection = ManagerConnection.ConSql();
            try
            {
                if (CheckStudentCourse(cmbSid.SelectedValue.ToString().Trim(), cmbCourse.SelectedValue.ToString()) != "01")
                {
                    MessageBox.Show("该学生已经选修此课程", "提示");
                    return;
                }
                connection.Open();
                if (new ManagerCommand(connection).InsertSC(cmbSid.SelectedValue.ToString().Trim(), cmbCourse.SelectedValue.ToString()) > 0)
                {
                    MessageBox.Show("选课成功", "提示");
                }
                else
                {
                    MessageBox.Show("选课失败，请重试");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("执行选课时出错，原因" + ex.Message);
            }
            finally
            {

                connection.Close();
                connection.Dispose();
            }
        }

        /// <summary>
        /// 刷新表
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            ShowAllStudentCourse();
        }

        /// <summary>
        /// 点击数据表的某一格，将这一格的数据加载到信息表
        /// </summary>
        private void dataView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cmbCourse.SelectedValue = dataView.CurrentRow.Cells[1].Value.ToString();
            cmbSid.SelectedValue = dataView.CurrentRow.Cells[0].Value.ToString();
        }

        /// <summary>
        /// 确认录入课程成绩
        /// </summary>
        /// 成绩一旦录入，不能修改
        private void btnWrite_Click(object sender, EventArgs e)
        {
            //匹配1-2个小数的正数
            string patten = @"^[0-9]+(.[0-9]{1,2})?$";
            if (!Regex.IsMatch(txtScores.Text, patten))
            {
                MessageBox.Show("成绩无效", "提示");
                return;
            }
            string result = CheckStudentCourse(cmbSid.SelectedValue.ToString().Trim(), cmbCourse.SelectedValue.ToString().Trim());
            if (MessageBox.Show("录入学号：" + cmbSid.SelectedValue.ToString() + " 的《" + cmbCourse.Text.Trim() + "》 课程的成绩为:" + txtScores.Text.Trim(), "提示", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                MessageBox.Show("录入操作已取消", "提示");
                return;
            }
            //如果没有录入过成绩，可以录入
            if (result == "")
            {
                SqlConnection connection = ManagerConnection.ConSql();
                try
                {
                    connection.Open();
                    if (new ManagerCommand(connection).WirteStudentScores(cmbSid.SelectedValue.ToString().Trim(), cmbCourse.SelectedValue.ToString().Trim(), txtScores.Text) > 0)
                    {
                        MessageBox.Show("录入成功");
                    }
                    else
                    {
                        MessageBox.Show("录入失败");
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("录入时出错，原因为：" + ex.Message, "提示");
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
            else if (result == "01")
            {
                MessageBox.Show("此学生本门课程未选修,不可录入成绩", "提示");
            }
            else
            {
                MessageBox.Show("此学生本门课程成绩录入完毕，不可修改,如果有其他原因，请联系校办。", "提示");

            }
        }

        /// <summary>
        /// 查询某学生选课信息
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            SelectStuCourse();
        }

        /// <summary>
        /// 查询选中课程共被多少学生选修
        /// </summary>
        private void cmbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectCourseChooseCount();
        }

        #endregion

        #region 方法

        /// <summary>
        /// 查询当前可选课程
        /// </summary>
        private void ShowCourseName()
        {
            SqlConnection connection = ManagerConnection.ConSql();
            try
            {
                connection.Open();
                List<object> list = new List<object>();
                SqlDataReader reader = new ManagerCommand(connection).SelectCourseInfo();
                while (reader.Read())
                {
                    list.Add(new { CID = reader[0], Cname = reader[1] });
                }
                cmbCourse.DataSource = list;
                cmbCourse.DisplayMember = "Cname";
                cmbCourse.ValueMember = "CID";

            }
            catch (SqlException ex)
            {
                MessageBox.Show("选课时出错，原因为" + ex.Message);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }

        /// <summary>
        /// 查询所有学号及学生姓名
        /// </summary>
        private void ShowSID()
        {
            SqlConnection connection = ManagerConnection.ConSql();
            try
            {
                connection.Open();
                List<object> list = new List<object>();
                SqlDataReader reader = new ManagerCommand(connection).SelectSID();
                while (reader.Read())
                {
                    list.Add(new { SID = reader[0], Sname = reader[1] });
                }
                cmbSid.DataSource = list;
                cmbSid.DisplayMember = "Sname";
                cmbSid.ValueMember = "SID";
            }
            catch (SqlException ex)
            {
                MessageBox.Show("查询学生学号时出错，原因为" + ex.Message);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }

        /// <summary>
        /// 查询所有学生的选修课程
        /// </summary>
        private void ShowAllStudentCourse()
        {
            List<object> list = new List<object>();
            SqlConnection connection = ManagerConnection.ConSql();
            try
            {
                connection.Open();
                SqlDataReader reader = new ManagerCommand(connection).SelectAllStudentCourse();
                while (reader.Read())
                {
                    list.Add(new { 学号 = reader["SID"], 课程号 = reader["CID"], 成绩 = reader["Scores"] });
                }
                dataView.DataSource = list;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("查询学生学号时出错，原因为" + ex.Message);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }

        /// <summary>
        /// 检查学生是否选修此课程
        /// </summary>
        /// <param name="sid"></param>
        /// <returns>返回查询结果</returns>
        private string CheckStudentCourse(string sid, string cid)
        {
            SqlConnection connection = ManagerConnection.ConSql();
            try
            {
                connection.Open();
                SqlDataReader reader = new ManagerCommand(connection).SelectStudentCourse(sid, cid);
                //选修了就返回成绩，此处主要服务于成绩录入
                if (reader.HasRows)
                {
                    reader.Read();
                    string a = reader["Scores"].ToString();
                    return a;
                }
                //没选修就返回0，此处主要服务于课程选修
                else
                {
                    return "01";
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("执行查询时出错，原因" + ex.Message);
                return null;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }

        /// <summary>
        /// 查询某学生选课信息
        /// </summary>
        /// <returns>返回该学生的选修课程数</returns>
        private int SelectStuCourse(int a = 1)
        {
            List<object> list = new List<object>();
            SqlConnection connection = ManagerConnection.ConSql();
            try
            {
                connection.Open();
                SqlDataReader reader = new ManagerCommand(connection).SelectStudentAllCourse(cmbSid.SelectedValue.ToString());
                if (!reader.HasRows && a == 0)
                {
                    MessageBox.Show("该学生无选课课程", "提示");
                    return -1;
                }
                while (reader.Read())
                {
                    list.Add(new { 学号 = reader["SID"], 课程号 = reader["CID"], 成绩 = reader["Scores"] });
                }
                dataView.DataSource = list;
                return list.Count();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("执行查询时出错，原因" + ex.Message);
                return -1;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }

        /// <summary>
        /// 查询课程选修人数
        /// </summary>
        private void SelectCourseChooseCount()
        {
            SqlConnection connection = ManagerConnection.ConSql();
            try
            {
                connection.Open();
                SqlDataReader reader = new ManagerCommand(connection).SelectCourseChooseCount(cmbCourse.SelectedValue.ToString());
                if (reader.Read())
                {
                    labCourse.Text = "当前课程选修人数为：" + reader["ChooseCount"] + " 人";
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("查询课程选修数时出错，原因为：" + ex.Message);
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
