using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventDemo2
{
    /// <summary>
    /// 事件的拥有者也是事件的响应者
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Form form=new Form();
            Controller controller=new Controller(form);
            form.ShowDialog();
        }
    }

    class Controller
    {
        private Form form;

        public Controller(Form form)
        {
            if (form!=null)
            {
                this.form = form;
                this.form.Click += this.FormClicked;
            }
        }

        private void FormClicked(object sender, EventArgs e)
        {
            this.form.Text = DateTime.Now.ToString();
        }
    }
}
