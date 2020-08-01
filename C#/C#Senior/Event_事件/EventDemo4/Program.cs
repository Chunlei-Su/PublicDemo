using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace EventDemo4
{
    /// <summary>
    /// 事件的拥有者是事件响应者的一个字段或者成员
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            MyForm myForm=new MyForm();
            myForm.ShowDialog();
        }
    }
    class MyForm : Form
    {
        private TextBox textBox;
        private Button button;

        public MyForm()
        {
            this.textBox=new TextBox();
            this.button=new Button();
            this.textBox.Left = 100;
            this.button.Text = "say hello";
            this.Controls.Add(this.button); //添加数据
            this.Controls.Add(this.textBox);
            this.button.Click += this.ButtonClicked;
        }

        private void ButtonClicked(object sender, EventArgs e)
        {
            this.textBox.Text = "hello world";
        }
    }
}
