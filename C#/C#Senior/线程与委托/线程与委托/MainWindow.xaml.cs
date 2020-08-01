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
using System.Threading;

namespace 线程与委托
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

        #region 线程

        /// <summary>
        /// 点击按钮实例线程并调用
        /// </summary>
        private void button_Click(object sender, RoutedEventArgs e)
        {
            //使用Ctrl+K+D快捷键规范缩进
            Thread thread = new Thread(() =>
            {
               listBox.Items.Add("后台线程每隔一秒打印本句话"+"\n");
                Thread.Sleep(1000);
            });
            //设置线程属性
            thread.IsBackground = true;
            //线程开始
            thread.Start();
        }

        #endregion

        #region 委托与函数的回调

        //声明一个委托
        delegate string  dele();
        dele deledemo;

        public string Print()
        {
            textBox.Text += "将方法作为参数交给委托对象进行调用；";
            return "1";
        }

        public string Print1()
        {
            textBox.Text += "将方法作为参数交给委托对象进行调用；";
            return "2";
        }

        /// <summary>
        /// 调用委托
        /// </summary>
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //为委托添加参数
            deledemo += Print;
            deledemo += Print1;
            //调用委托相当于调用传入的参数
            string s= deledemo();
            MessageBox.Show(s);
            //调用输出1函数，为输出1传入参数方法实现调用输出二方法
        }

        /// <summary>
        /// 实现函数的回调
        /// 回调函数为什么被称为回调函数？比如你调用了一个函数，那么就叫调用，
        /// 但是如果你在调用一个函数的时候，还需要把令一个函数提供给该函数，调用这个函数的时候，让这个函数再来调用你的另一个函数，那么你提供的这个函数就被称为回调函数（callback）。
        /// 再使用中就比较灵活
        /// </summary>
        /// <param name="action">回调函数</param>
        /// action类定义一个以方法为参数的对象
        public void Print1(Action action)
        {
            textBox.Text += "将方法作为参数交给委托对象进行调用；";
            //把Print2作为参数传入进来，调用action就相当于调用Print2,这就实现了方法的回调
            action();
        }

        /// <summary>
        /// 被回调的函数
        /// </summary>
        public void Print2()
        {
            textBox.Text += "方法的回调";
        }

        #endregion

        #region 事件实例

        /// <summary>
        /// 方法1
        /// </summary>
        class Bridegroom
        {
            //自定义委托
            public delegate void MarryHandler(string msg);

            //使用自定义委托类型定义事件,事件名为MarrEvent
            //event关键字声明一个事件
            public event MarryHandler MarrayEvent;

            /// <summary>
            /// 调用方法出发事件
            /// </summary>
            /// <param name="msg">事件所需的参数</param>
            public void OnMarriageComing(string msg)
            {
                //判断是否绑定了事件处理方法
                if (MarrayEvent != null)
                {
                    //触发事件
                    MarrayEvent(msg);
                }
            }

            /// <summary>
            /// 主方法里边调用
            /// </summary>
            static void Main1(string[] args)
            {
                //初始化新郎官对象
                Bridegroom bridegroom = new Bridegroom();

                //实例化朋友对象
                Friend friend1 = new Friend("张三");
                Friend friend2 = new Friend("李四");

                //使用"+="订阅消息
                bridegroom.MarrayEvent += new MarryHandler(friend1.SendMessage);
                bridegroom.MarrayEvent += new MarryHandler(friend2.SendMessage);

                //使用"-="取消消息
                bridegroom.MarrayEvent -= new MarryHandler(friend2.SendMessage);

                //发出通知消息，触发事件
                bridegroom.OnMarriageComing("到时来参见婚礼!");
               

                //输出结果为
                //到时来参加婚礼!
                //张三收到了,到时候来参加

            }

            //朋友类
            public class Friend
            {
                //字段—朋友名
                public string Name;

                //构造方法为Name赋值
                public Friend(string name)
                {
                    Name = name;
                }

                //事件处理函数,该函数符合MarryHandler委托的定义
                public void SendMessage(string mssage)
                {
                    //输出通知消息
                    Console.WriteLine(mssage);
                    //对事件做出处理
                    Console.WriteLine(this.Name + "收到了,到时候来参加");
                }

            }
        }
        //自定义事件类,并使其带有事件数据
        public class MarryEventArgs : EventArgs
        {
            public string Message;
            public MarryEventArgs(string msg)
            {
                Message = msg;
            }
        }

        /// <summary>
        /// 方法2
        /// </summary>
        class Bridegroom1
        {
            //自定义委托
            public delegate void MarryHandler(object sender, MarryEventArgs e);
            //使用自定义委托类型定义事件,事件名为MarrEvent
            public event MarryHandler MarrayEvent;

            //发出事件
            public void OnMarriageComing(string msg)
            {
                //判断是否绑定了事件处理方法
                if (MarrayEvent != null)
                {
                    //触发事件
                    MarrayEvent(this, new MarryEventArgs(msg));
                }
            }
            static void Main1(string[] args)
            {
                //初始化新郎官对象
                Bridegroom1 bridegroom = new Bridegroom1();

                //实例化朋友对象
                Friend friend1 = new Friend("张三");
                Friend friend2 = new Friend("李四");
                Friend friend3 = new Friend("王五");

                //使用"+="订阅消息
                bridegroom.MarrayEvent += new MarryHandler(friend1.SendMessage);
                bridegroom.MarrayEvent += new MarryHandler(friend2.SendMessage);

                //使用"-="取消消息
                bridegroom.MarrayEvent -= new MarryHandler(friend2.SendMessage);

                //发出通知
                bridegroom.OnMarriageComing("到时来参见婚礼!");
                Console.ReadLine();

                //输出结果为
                //到时来参加婚礼!
                //张三收到了,到时候来参加

            }

            //朋友类
            public class Friend
            {
                //字段
                public string Name;
                //构造函数
                public Friend(string name)
                {
                    Name = name;
                }

                //事件处理函数,该函数符合MarryHandler委托的定义
                public void SendMessage(object s, MarryEventArgs e)
                {
                    //输出通知消息
                    Console.WriteLine(e.Message);
                    //对事件做出处理
                    Console.WriteLine(this.Name + "收到了,到时候来参加");
                }

            }
        }

        #endregion

        //        事件方法2类型说明
        //        EventHandler系统委托类
        //        EventHandler系统委托类定义如下：
        public delegate void EventHandler(Object sender, EventArgs e);
        //        第一个参数sender负责保存对触发事件对象的引用,其类型为Object
        //        第二个参数e负责保存事件数据,EventArgs也是.NET类库中定义的类,它不保存任何数据
        //        扩展EventArgs类
        //          因为EventHandler只用于处理不包含事件数据的事件.如果我们想要在由这种方式定义的事件中包含事件数据,则可以通过派生EventArgs类来实现

    }
}
