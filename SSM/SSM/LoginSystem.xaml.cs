using Dal;
using Model.Models;
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

namespace SSM
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;//界面一打开初始化在屏幕中间显示
        }

        //左键点击窗体可移动
        private void Mouse_Left_Click_down(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
            username.Background = new SolidColorBrush(Colors.LightGray);
            password.Background = new SolidColorBrush(Colors.LightGray);
        }

        #region --关闭按钮区域事件
        //鼠标左键单击关闭按钮
        private void Login_Win_Close_Left_Down(object sender, MouseButtonEventArgs e)
        {

            Application.Current.Shutdown();
        }

        //鼠标进入关闭按钮区域
        private void Login_Win_Close_Mouse_Enter(object sender, MouseEventArgs e)
        {
            wara_Close.Background = new SolidColorBrush(Colors.White);//使 Name="wara_Close" 控件的背景颜色变成白色
            wara_Close.Height = wara_Close.Width = 38;
            Message_Close.Visibility = Visibility.Visible;

            //wrap1.Background = new SolidColorBrush(Colors.Red);
        }
        //鼠标离开关闭按钮区域
        private void Login_Win_Close_Mouse_Leave(object sender, MouseEventArgs e)
        {
            wara_Close.Background = Grid_Login_Frist.Background;//使 Name="wara_Close" 控件的背景颜色变成白色
            wara_Close.Height = wara_Close.Width = 40;
            Message_Close.Visibility = Visibility.Hidden;

        }
        #endregion

        #region --设置按钮区域事件
        //鼠标进入设置按钮区域
        private void Login_Win_Set_Mouse_Enter(object sender, MouseEventArgs e)
        {
            wara_Set.Background = new SolidColorBrush(Colors.White);//使 Name="wara_Set" 控件的背景颜色变成白色
            wara_Set.Height = wara_Close.Width = 38;
            wara_Close.Margin = new Thickness(41, 0, 0, 0);
            Message_Set.Visibility = Visibility.Visible;

        }
        //鼠标离开设置按钮区域
        private void Login_Win_Set_Mouse_Leave(object sender, MouseEventArgs e)
        {
            wara_Set.Background = Grid_Login_Frist.Background;//使 Name="wara_Set" 控件的背景颜色变成白色
            wara_Set.Height = wara_Close.Width = 40;
            wara_Close.Margin = new Thickness(40, 0, 0, 0);
            Message_Set.Visibility = Visibility.Hidden;
        }
        #endregion

        #region --点击输入框事件
        /// <summary>
        /// 点击User输入框改变样式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void user_output_text(object sender, MouseButtonEventArgs e)
        {
            username.Background = new SolidColorBrush(Colors.White);
            password.Background = new SolidColorBrush(Colors.LightGray);
        }
        /// <summary>
        /// 点击Password输入框改变样式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void password_output_text(object sender, MouseButtonEventArgs e)
        {
            password.Background = new SolidColorBrush(Colors.White);
            username.Background = new SolidColorBrush(Colors.LightGray);
        }
        #endregion


        #region --登陆按钮事件
        /// <summary>
        /// 登陆按钮区域进入触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_Ok_btn_Enter(object sender, MouseEventArgs e)
        {
            Ok_Login_btn.Background = new SolidColorBrush(Colors.White);
            //Ok_Login_btn.Background = (Brush)TryFindResource("MyGradientBackground");
        }



        private void login_win_mouse_down(object sender, MouseButtonEventArgs e)
        {
            wara_Close.Background = new SolidColorBrush(Colors.Tomato);
        }

        /// <summary>
        /// 登陆确定、左键点击按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_OK_left_down(object sender, MouseButtonEventArgs e)
        {
            T_Admin tmode = new T_Admin();
            tmode.UserName = username.Text;
            tmode.PassWord = password.Password;
            D_Admin dmode = new D_Admin();

            string getResult_OK = dmode.Scan_Account(tmode);
            if (tmode.UserName == "" || tmode.PassWord == "")
            {
                if (tmode.UserName == "" && tmode.PassWord == "")
                {
                    MessageBox.Show("用户名和密码都不得为空");
                }
                if(tmode.UserName == "" && tmode.PassWord != "")
                {
                    MessageBox.Show("用户名不得为空");
                }
                if(tmode.UserName != "" && tmode.PassWord == "")
                {
                    MessageBox.Show("登陆密码不得为空");
                }
            }
            else
            {


                if (getResult_OK == "true")
                {
                    MessageBox.Show("登陆成功!");
                    WindowMain winMain = new WindowMain();
                    winMain.Show();//打开新窗体
                    this.Close();//关闭改窗体
                }
                if (getResult_OK == "false")
                {
                    username.Text = "";
                    password.Password = "";
                    MessageBox.Show("登陆失败！账号或密码不正确");
                }
                if (getResult_OK != "true" && getResult_OK != "false")
                {
                    MessageBox.Show(getResult_OK);
                }
            }
        }
        #endregion

        //点击设置按钮事件
        private void Login_Seting_Left_Down(object sender, MouseButtonEventArgs e)
        {
            SetingSystem setWin = new SetingSystem();
            setWin.ShowInTaskbar = false;
            setWin.Topmost = true;                  // ensure we're Always On Top
            //sw.ResizeMode = ResizeMode.NoResize;
            //sw.Owner = this;//父窗体是page，子船体是window，不要这句话也行。
            setWin.ShowDialog();
        }
    }
}
