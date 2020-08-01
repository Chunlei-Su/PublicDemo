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

namespace 窗体传值实例
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

        ChildWin childWin;
        
        private void button_Click(object sender, RoutedEventArgs e)
        {
            childWin = new ChildWin();
            childWin.data = "你好";
            ChildWin.data1 = "你好";
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            childWin.ShowDialog();
        }
    }
}
