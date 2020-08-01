using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassManageLiarary;

namespace Production_ClassManage
{
    public partial class Form1 : Form
    {
        public static string NowLogin = null;

        public Form1()
        {
            InitializeComponent();
            labNow.Text = NowLogin;
        }

        #region 对学生信息的操作

        #region 窗体加载和退载

        /// <summary>
        /// 窗体加载
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            PicBox.LoadAsync("../../images/liuyifei.jpg");
            AddComData();
            ForPageSelectData(NowPage);
        }

        int p = 0;
        /// <summary>
        /// 窗体退载
        /// </summary>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (p == 0)
            {
                if (MessageBox.Show("确认退出？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }

        }

        /// <summary>
        /// 退出系统
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        private void btnOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否退出登录？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Thread thread = new Thread(() => new loginForm().ShowDialog());
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                p = 1;
                this.Close();
            }
        }

        #endregion

        #region 增删改

        /// <summary>
        /// 添加数据
        /// </summary>
        private void btnInsert_Click(object sender, EventArgs e)
        {

            SqlConnection connection = ManagerConnection.ConSql();
            ManagerCommand command = null;
            DataCheck dataCheck = new DataCheck();
            try
            {
                connection.Open();
                command = new ManagerCommand(connection);
                string sex = null;
                if (rdoMen.Checked == true)
                    sex = "男";
                else
                    sex = "女";
                //封装数据
                Manager manager = command.PackData(txtSid.Text.Trim(), txtSname.Text.Trim(), sex, BirthdayData.Value, CmbSpec.Text, txtScorse.Text.Trim(), imgData);
                //检查数据
                string result = dataCheck.checkLoginData(dataCheck.checkLoginData(manager));
                //插入数据
                if (result == "0")
                {
                    if (command.InsertData(manager) > 0)
                    {
                        imgData = null;
                        MessageBox.Show("插入成功");
                        //更新数据
                        ForPageSelectData(NowPage);
                    }
                    else
                    {
                        MessageBox.Show("插入失败");
                    }
                }
                //反馈错误
                else
                {
                    MessageBox.Show(result);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("插入时出错，原因：" + ex.Message);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string patten = "^[0-9]{10}$";
            if (!Regex.IsMatch(txtSid.Text, patten))
            {
                MessageBox.Show("学号无效", "提示");
                return;
            }
            if (MessageBox.Show("确认删除学号为：" + txtSid.Text.Trim() + "的信息？", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                MessageBox.Show("删除操作已取消", "提示");
                return;
            }
            SqlConnection connection = ManagerConnection.ConSql();
            try
            {
                connection.Open();
                if (new ManagerCommand(connection).DeleteData(txtSid.Text.Trim()) > 0)
                {
                    MessageBox.Show("删除成功");
                    txtSid.Text = "";
                    txtSname.Text = "";
                    txtScorse.Text = "";
                    rdoMen.Checked = true;
                    BirthdayData.Value = DateTime.Now;
                    CmbSpec.SelectedIndex = 0;
                    PicBox.LoadAsync("../../images/liuyifei.jpg");
                    //更新数据
                    ForPageSelectData(NowPage);
                }
                else
                {
                    MessageBox.Show("删除失败，原因可能为数据库无此数据");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("删除时出错，原因：" + ex.Message);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection connection = ManagerConnection.ConSql();
            ManagerCommand command = null;
            DataCheck dataCheck = new DataCheck();
            try
            {
                connection.Open();
                command = new ManagerCommand(connection);
                string sex = null;
                if (rdoMen.Checked == true)
                    sex = "男";
                else
                    sex = "女";
                //封装数据
                Manager manager = command.PackData(txtSid.Text.Trim(), txtSname.Text.Trim(), sex, BirthdayData.Value, CmbSpec.Text, txtScorse.Text.Trim(), imgData);

                //比对数据是否发生修改
                if (!new EqualsManager().EqualsManagerData(manager, UpdateManager))
                {
                    MessageBox.Show("您并未修改任何数据,无需更新数据", "提示");
                    return;
                }

                //检查数据
                string result = dataCheck.checkLoginData(dataCheck.checkLoginData(manager, 1));
                //插入数据
                if (result == "0")
                {
                    if (command.UpDateData(manager) > 0)
                    {
                        MessageBox.Show("更新成功");
                        ForPageSelectData(NowPage);
                    }
                    else
                    {
                        MessageBox.Show("更新失败");
                    }
                }
                //反馈错误
                else
                {
                    MessageBox.Show(result);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("更新时出错，原因：" + ex.Message);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }

        #endregion

        #region 杂项方法

        /// <summary>
        /// 获取专业名
        /// </summary>
        public void AddComData()
        {
            SqlConnection connection = ManagerConnection.ConSql();
            try
            {
                List<object> list = new List<object>();
                connection.Open();
                SqlDataReader reader = new ManagerCommand(connection).selectSpecialty();
                while (reader.Read())
                {
                    list.Add(new { Specialty = reader[0], SpecialtyId = reader[1] });
                }
                CmbSpec.DataSource = list;
                CmbSpec.DisplayMember = "Specialty";
                CmbSpec.ValueMember = "SpecialtyId";
            }
            catch (SqlException ex)
            {
                MessageBox.Show("在加载专业名时出错,原因为：" + ex.Message);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }

        /// <summary>
        /// 查找学生信息
        /// </summary>
        private void btnFind_Click(object sender, EventArgs e)
        {
            string patten = "^[0-9]{10}$";
            if (!Regex.IsMatch(txtSid.Text.Trim(), patten))
            {
                MessageBox.Show("您输入的学号不正确", "提示");
                return;
            }
            SqlConnection connection = ManagerConnection.ConSql();
            try
            {
                connection.Open();
                SqlDataReader reader = new ManagerCommand(connection).selectSomeoneData(txtSid.Text.Trim());
                if (reader.Read())
                {
                    List<object> list = new List<object>();
                    list.Add(new
                    {
                        SID = reader["SID"],
                        Sname = reader["Sname"],
                        Sex = reader["Sex"],
                        Birthdate = reader["Birthdate"],
                        Specialty = reader["Specialty"],
                        AScores = reader["AScores"],
                        logo = reader["logo"],
                    });
                    dataView.DataSource = list;
                    labPage.Text = "查找成功";
                }
                else
                {
                    MessageBox.Show("无学生对应该学号", "提示");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("查询学生信息时出错，原因为：" + ex.Message);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }

        OpenFileDialog FileDialog = null;
        byte[] imgData = null;
        /// <summary>
        /// 浏览图片（调用系统API，选择图片）
        /// </summary>
        private void btnBrowsePic_Click(object sender, EventArgs e)
        {
            FileDialog = new OpenFileDialog();
            //设置要查找的格式
            FileDialog.Filter = "图片(*jpg,*.gif,*.png,*.jpepg)|*.jpg;*.gif;*.png;*.jpepg";
            //弹出选择框，并判断是否选择成功
            if (FileDialog.ShowDialog() == DialogResult.OK)
            {
                //获取选定文件的文件信息，判断所选文件是否是符合大小
                FileInfo file = new FileInfo(FileDialog.FileName);
                if ((float)file.Length / 1024 > 10.0)
                {
                    MessageBox.Show("您选择的文件过大！");
                    return;
                }
                imgData = new byte[file.Length];
                //读取图片流数据
                using (FileStream stream = new FileStream(FileDialog.FileName, FileMode.Open, FileAccess.Read))
                {
                    stream.Read(imgData, 0, (int)stream.Length);
                }
                PicBox.LoadAsync(FileDialog.FileName);
            }
            else
            {
                MessageBox.Show("您尚未选择的头像。");
                imgData = null;
            }
        }

        Manager UpdateManager = null;
        /// <summary>
        /// 点击任意数据项时，将此项所在行的数据填至信息框
        /// </summary>
        private void dataView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            UpdateManager = new Manager();

            txtSid.Text = dataView.CurrentRow.Cells[0].Value.ToString().Trim();
            txtSname.Text = dataView.CurrentRow.Cells[1].Value.ToString().Trim();
            string sex = "";
            if (dataView.CurrentRow.Cells[2].Value.ToString().Equals("男"))
            {
                sex = "男";
                rdoMen.Checked = true;
            }
            else
            {
                sex = "女";
                rdoWomen.Checked = true;
            }
            BirthdayData.Value = (DateTime)dataView.CurrentRow.Cells[3].Value;
            CmbSpec.Text = dataView.CurrentRow.Cells[4].Value.ToString().Trim();
            txtScorse.Text = dataView.CurrentRow.Cells[5].Value.ToString().Trim();
            imgData = (byte[])dataView.CurrentRow.Cells[6].Value;
            MemoryStream stream = new MemoryStream(imgData);
            Bitmap bitmap = new Bitmap(stream);
            PicBox.Image = bitmap;
            UpdateManager = new Manager(txtSid.Text.Trim(), txtSname.Text.Trim(), sex, BirthdayData.Value, CmbSpec.Text, txtScorse.Text.Trim(), imgData);
        }

        #endregion

        #endregion

        #region 分页查询

        /// <summary>
        /// 总页数
        /// </summary>
        private int PageAll;
        /// <summary>
        /// 当前页
        /// </summary>
        private int NowPage = 1;
        /// <summary>
        /// 每页显示多少行
        /// </summary>
        private int CountShow = 6;

        /// <summary>
        /// 首页
        /// </summary>
        private void btnfirstPage_Click(object sender, EventArgs e)
        {
            NowPage = 1;
            ForPageSelectData(NowPage);
        }

        /// <summary>
        /// 查询总页数
        /// </summary>
        public void PageCount()
        {
            SqlConnection connection = ManagerConnection.ConSql();
            try
            {
                connection.Open();
                int count = new ManagerCommand(connection).SelectePageCount();
                PageAll = count / CountShow;
                PageAll = count % PageAll == 0 ? PageAll : ++PageAll;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("计算总页时出错，原因为：" + ex.Message);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }

        /// <summary>
        /// 根据页数查数据
        /// </summary>
        /// <param name="nowpage">要显示的页数</param>
        public void ForPageSelectData(int nowpage)
        {
            PageCount();
            List<object> list = new List<object>();
            SqlConnection connection = ManagerConnection.ConSql();
            try
            {
                connection.Open();
                SqlDataReader reader = new ManagerCommand(connection).selectAllData();
                for (int i = 0; i < (nowpage - 1) * CountShow; i++)
                {
                    reader.Read();
                }
                for (int i = 0; i < CountShow; i++)
                {
                    if (!reader.Read())
                    {
                        break;
                    }
                    list.Add(new
                    {
                        SID = reader["SID"],
                        Sname = reader["Sname"],
                        Sex = reader["Sex"],
                        Birthdate = reader["Birthdate"],
                        Specialty = reader["Specialty"],
                        AScores = reader["AScores"],
                        logo = reader["logo"],
                    });
                }
                dataView.DataSource = list;
                labPage.Text = "当前" + nowpage + "页，共" + PageAll + "页";
            }
            catch (SqlException ex)
            {
                MessageBox.Show("查询时出错，原因为" + ex.Message);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }

        /// <summary>
        /// 下一页
        /// </summary>
        private void btnPageNext_Click(object sender, EventArgs e)
        {
            NowPage = ++NowPage;
            if (NowPage == PageAll + 1)
            {
                NowPage = PageAll;
                return;
            }
            ForPageSelectData(NowPage);
        }

        /// <summary>
        /// 上一页
        /// </summary>
        private void btnPageOn_Click(object sender, EventArgs e)
        {
            NowPage = --NowPage;
            if (NowPage == 0)
            {
                NowPage = 1;
                return;
            }
            ForPageSelectData(NowPage);
        }

        /// <summary>
        /// 尾页
        /// </summary>
        private void btnPageEnd_Click(object sender, EventArgs e)
        {
            NowPage = PageAll;
            ForPageSelectData(NowPage);
        }

        /// <summary>
        /// 跳转到
        /// </summary>
        private void btnPageTo_Click(object sender, EventArgs e)
        {
            try
            {
                NowPage = int.Parse(txtPage.Text);
                if (NowPage > PageAll)
                {
                    NowPage = PageAll;
                    MessageBox.Show("页码无效,已跳转至临近有效页", "提示");
                }
                if (NowPage < 1)
                {
                    NowPage = 1;
                    MessageBox.Show("页码无效，已跳转至临近有效页", "提示");
                }

                ForPageSelectData(NowPage);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region 课程相关

        /// <summary>
        /// 打开选课界面
        /// </summary>
        private void btnCourse_Click(object sender, EventArgs e)
        {
            ChooseCourse course = new ChooseCourse();
            course.ShowDialog();
        }

        /// <summary>
        /// 增设课程
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            AddCourse course = new AddCourse();
            course.ShowDialog();
        }

        #endregion


        /// <summary>
        /// 设置文本框限制（示例方法）
        /// </summary>
        private void txtPage_KeyPress(object sender, KeyPressEventArgs e)
        {
            //46是小数点
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 1 && e.KeyChar != 3 && e.KeyChar != 8 && e.KeyChar != 22)
            {
                e.Handled = true;
            }
        }

    }

}