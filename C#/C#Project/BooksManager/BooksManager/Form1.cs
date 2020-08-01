using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BooksManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //添加书籍
        private void Btn_add_Click(object sender, EventArgs e)
        {
            if (!Verification())
                return;

            string datetime = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            if (btn_add.Text == "添加")
            {
                string sql2 = "select*from Book where bookId=" + txt_id.Text;

                if (DbHelper.ExecuteDataTable(sql2).Rows.Count > 0)
                {
                    MessageBox.Show("当前图书编号：" + txt_id.Text + "已经存在了，请重新输入！");
                }
                else
                {
                    string sql = string.Format("insert into Book values('{0}','{1}','{2}','{3}','{4}','{5}')", txt_id.Text,
                    txt_name.Text, txt_price.Text, datetime, txt_url.Text, comboBox1.SelectedValue);
                    if (DbHelper.ExecuteNonQuery(sql) > 0)
                    {
                        MessageBox.Show("添加成功！");
                        string sql3 = "UPDATE NewCataLog set quantity=quantity+1 where catalogId=" + comboBox1.SelectedValue;
                        DbHelper.ExecuteNonQuery(sql3);
                        InitData();
                        clean();
                    }
                    else
                    {
                        MessageBox.Show("添加失败！");
                    }
                }

            }
            else
            {
                string sql = string.Format("update Book set bookName='{0}',bookPrice='{1}',publisDate='{2}',kogo='{3}',catalogId='{4}' where bookId='{5}'",
              txt_name.Text, txt_price.Text, datetime, txt_url.Text, comboBox1.SelectedValue, txt_id.Text);
                if (DbHelper.ExecuteNonQuery(sql) > 0)
                {
                    MessageBox.Show("修改成功！");
                    InitData();
                    clean();
                }
                else
                {
                    MessageBox.Show("修改失败！");
                }
            }

        }
        #region 验证数据
        public bool Verification()
        {
            if (string.IsNullOrEmpty(txt_id.Text))
            {
                MessageBox.Show("图书编号不能为空！");
                return false;
            }
            else if (string.IsNullOrEmpty(txt_name.Text))
            {
                MessageBox.Show("图书名称不能为空！");
                return false;
            }
            else if (string.IsNullOrEmpty(txt_price.Text))
            {
                MessageBox.Show("图书价格不能为空！");
                return false;
            }
            else if (string.IsNullOrEmpty(txt_url.Text))
            {
                MessageBox.Show("图片封面不能为空！");
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
        byte[] imgData = null;
        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = "C:\\";    //打开对话框后的初始目录
            fileDialog.Filter = "文本文件|*.*|所有文件|*.*";
            fileDialog.RestoreDirectory = false;    //若为false，则打开对话框后为上次的目录。若为true，则为初始目录
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string src = System.IO.Path.GetFullPath(fileDialog.FileName);//将选中的文件的路径传递给TextBox “FilePath”
                //string path = @"..\bin\Debug\Image\" + Path.GetFileName(src);
                //if (!File.Exists(path))
                //{
                //    File.Copy(src, path);
                //}
                FileInfo file = new FileInfo(fileDialog.FileName);
                pictureBox1.Load(src);
                imgData = new byte[file.Length];
                FileStream stream = new FileStream(fileDialog.FileName, FileMode.Open, FileAccess.Read);
                stream.Read(imgData, 0, (int)stream.Length);
                stream.Dispose();
                txt_url.Text = src;
            }
        }

        private static void copyFiles(string srcFolder, string destFolder)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(srcFolder);
            FileInfo[] files = directoryInfo.GetFiles();

            foreach (FileInfo file in files) // Directory.GetFiles(srcFolder)
            {

                file.CopyTo(Path.Combine(destFolder, file.Name)); //复制 ，剪切的话file.MoveTo();
                // will move all files without if stmt 
                //file.MoveTo(Path.Combine(destFolder, file.Name));
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            Init();
            InitData();
        }

        private void InitData()
        {
            string sql = "select b.bookId,b.bookName,b.bookPrice,b.publisDate,b.kogo,catalogName from Book b left join NewCataLog n on b.catalogId=n.catalogId";
            DataTable dt = DbHelper.ExecuteDataTable(sql);
            dataGridView1.DataSource = dt;
        }

        /// <summary>
        /// 窗体加载初始化专业下拉列表框
        /// </summary>
        private void Init()
        {
            string sql = "select*from NewCatalog";
            DataTable dt = DbHelper.ExecuteDataTable(sql);
            List<NewCatalog> list = new List<NewCatalog>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string c1 = dt.Rows[i].ItemArray[0].ToString();
                string s1 = dt.Rows[i].ItemArray[1].ToString();
                list.Add(new NewCatalog(c1, s1));
            }

            comboBox1.DataSource = list;
            comboBox1.DisplayMember = "catalogName";
            comboBox1.ValueMember = "catalogId";
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        private void Button2_Click(object sender, EventArgs e)
        {
            string sql = "select*from Book";
            if (!string.IsNullOrEmpty(txt_selectName.Text))
            {
                sql += " where bookName like '%" + txt_selectName.Text + "%'";
            }
            DataTable dt = DbHelper.ExecuteDataTable(sql);
            dataGridView1.DataSource = dt;
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            if (!string.IsNullOrEmpty(id))
            {
                string sql = "execute   delProc '" + id + "'";
                if (DbHelper.ExecuteNonQuery(sql) > 0)
                {
                    MessageBox.Show("删除成功");
                    InitData();
                    txt_id.ReadOnly = false;
                }
                else
                {
                    MessageBox.Show("删除失败");
                }
            }
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            if (!string.IsNullOrEmpty(id))
            {
                txt_id.ReadOnly = true;
                btn_add.Text = "保存";
                string sql = "select*from Book where bookId=" + id;
                DataTable dt = DbHelper.ExecuteDataTable(sql);
                txt_id.Text = dt.Rows[0].ItemArray[0].ToString();
                txt_name.Text = dt.Rows[0].ItemArray[1].ToString();
                txt_price.Text = dt.Rows[0].ItemArray[2].ToString();
                dateTimePicker1.Value = DateTime.Parse(dt.Rows[0].ItemArray[3].ToString());
                txt_url.Text = dt.Rows[0].ItemArray[4].ToString();
                comboBox1.SelectedValue = dt.Rows[0].ItemArray[5].ToString();
            }
        }

        public void clean()
        {
            txt_id.Text = "";
            txt_name.Text = "";
            txt_price.Text = "";
            txt_url.Text = "";
            pictureBox1.Image = null;
        }
    }
}
