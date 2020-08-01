using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace 委托窗体传值
{
    /// <summary>
    /// 子ck.xaml 的交互逻辑
    /// </summary>
    public partial class 子ck : Window
    {
        public 子ck()
        {
            InitializeComponent();
        }

        //声明共有的委托(无返回值，一个参数)
        public delegate void Test(string data);
        //实例共有委托对象
        public Test test;

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //将文本传入
            test(textBox.Text);
        }
    }
}
