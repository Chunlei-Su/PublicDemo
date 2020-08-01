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

namespace 窗体传值实例
{
    /// <summary>
    /// ChildWin.xaml 的交互逻辑
    /// </summary>
    public partial class ChildWin : Window
    {
        public string data;
        public static string data1;
        public ChildWin()
        {
            InitializeComponent();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            textBox.Text = data;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
           
           
               
        }
    }
}
