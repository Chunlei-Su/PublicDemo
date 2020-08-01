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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace 委托窗体传值
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 传值方法
        /// </summary>
        /// <param name="data">接收到的值</param>
        public void Data(string data)
        {
            textBox.Text = data;
        }

        /// <summary>
        /// 弹出子窗口
        /// </summary>
        private void button_Click(object sender, RoutedEventArgs e)
        {
            子ck Child = new 子ck();
            //将方法传给子窗口的委托
            Child.test = Data;
            Child.Show();
        }
    }
}
