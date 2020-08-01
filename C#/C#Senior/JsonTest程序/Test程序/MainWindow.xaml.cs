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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;

namespace Test程序
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
        
        private void button_Click(object sender, RoutedEventArgs e)
        {
            string Jsondata = textBox.Text;
            textBox1.Text = JsonConvert.DeserializeObject(Jsondata).ToString();

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //添加一个消息过滤器
            IntPtr hwnd = new WindowInteropHelper(this).Handle;
            HwndSource.FromHwnd(hwnd).AddHook(new HwndSourceHook(WndProc));
        }

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == WM_NCHITTEST)
            {
                // 获取屏幕坐标
                Point p = new Point();
                int pInt = lParam.ToInt32();
                p.X = (pInt << 16) >> 16;
                p.Y = pInt >> 16;
                if (IsOnTitleBar(p))
                {
                    //欺骗系统鼠标点击在标题栏上
                    handled = true;
                    return new IntPtr(2);
                }
            }

            return IntPtr.Zero;
        }

        private bool IsOnTitleBar(Point p)
        {
            //假设标题栏在0和100之间
            if (p.Y >= 0 && p.Y < 100)
                return true;
            else
                return false;
        }

        private const int WM_NCHITTEST = 0x0084;
    }
}
