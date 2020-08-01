using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventDemo3
{
    /// <summary>
    /// 事件的拥有者也是事件的响应者
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            MyForm form=new MyForm();
            form.Click += form.Action;
            form.ShowDialog();
        }
    }

    class MyForm:Form
    {
        public void Action(object sender, EventArgs e)
        {
            this.Text = DateTime.Now.ToString();
        }
    }
}
