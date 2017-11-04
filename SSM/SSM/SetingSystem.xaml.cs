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
using System.Windows.Shapes;

namespace SSM
{
    /// <summary>
    /// SetingSystem.xaml 的交互逻辑
    /// </summary>
    public partial class SetingSystem : Window
    {
        public SetingSystem()
        {
            InitializeComponent();

            T_LoginSet setmodeltwo = new T_LoginSet();
            setmodeltwo = ReWinDation();
            if (setmodeltwo.DataBaseIP == "" && setmodeltwo.DataBaseName =="")
            {
                //数据库IP
                Win_DataBaseIP.Text = "127.0.0.1";
                //数据库实例
                Win_DataBaseInstance.Text = "";
                //数据库名称
                Win_DataBaseName.Text = "SocialSecurityManage";
                //数据库用户
                Win_DataBaseUser.Text = "sa";
                //数据库密码
                Win_DataBasePassword.Password = "123";
            }
            else
            {
                //数据库IP
                Win_DataBaseIP.Text = setmodeltwo.DataBaseIP;
                //数据库实例
                Win_DataBaseInstance.Text = setmodeltwo.DataBaseInstance;
                //数据库名称
                Win_DataBaseName.Text = setmodeltwo.DataBaseName;
                //数据库用户
                Win_DataBaseUser.Text = setmodeltwo.DataBaseUser;
                //数据库密码
                Win_DataBasePassword.Password = setmodeltwo.DataBasePassword;
            }
            
        }

        public T_LoginSet ReWinDation()
        {
            T_LoginSet setmode = new T_LoginSet();
            #region -- 数据从页面中提取并绑定到Mode
            //数据库IP
            setmode.DataBaseIP = Win_DataBaseIP.Text;
            //数据库实例
            setmode.DataBaseInstance = Win_DataBaseInstance.Text;
            //数据库名称
            setmode.DataBaseName = Win_DataBaseName.Text;
            //数据库用户
            setmode.DataBaseUser = Win_DataBaseUser.Text;
            //数据库密码
            setmode.DataBasePassword = Win_DataBasePassword.Password;
            #endregion

            return setmode;
        }

        //设置窗口点击关闭按钮
        private void Seting_Win_Close_left_Down(object sender, MouseButtonEventArgs e)
        {
            Close();
        }









        //点击保存按钮
        private void Seting_Win_Save_Letf_Down(object sender, RoutedEventArgs e)
        {
            T_LoginSet setmodel = new T_LoginSet();
            setmodel = ReWinDation();
            D_LoginSet Dset = new D_LoginSet();
            string getReturn_Result = Dset.LoginSetCheck_Query(setmodel.DataBaseIP, setmodel.DataBaseName);

            if (getReturn_Result == "Null")
            {
                bool getReturn_AddResult = Dset.LoginSetCheck_Add(setmodel);
                if (getReturn_AddResult)
                {
                    MessageBox.Show("设置成功");
                    Close();
                }
                else
                {
                    MessageBox.Show("设置失败");
                    Close();
                }
            }
            else
            {
                MessageBox.Show("设置成功");
                Close();
            }




        }












        //鼠标进入关闭按钮
        private void Seting_Win_Close_Mouse_Enter(object sender, MouseEventArgs e)
        {
            Grid_Close.Background = new SolidColorBrush(Colors.White);//使 Name="wara_Close" 控件的背景颜色变成白色
            //Grid_Close.Height = Grid_Close.Width = 38;
            Message_Close.Visibility = Visibility.Visible;
        }
        //鼠标离开关闭按钮
        private void Seting_Win_Close_Mouse_Leave(object sender, MouseEventArgs e)
        {
            Grid_Close.Background = Seting_win.Background;//使 Name="wara_Close" 控件的背景颜色变成白色
            //Grid_Close.Height = Grid_Close.Width = 40;
            Message_Close.Visibility = Visibility.Hidden;
        }
    }
}
