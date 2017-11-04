using Dal;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SSM
{
    /// <summary>
    /// WindowMain.xaml 的交互逻辑
    /// </summary>
    public partial class WindowMain : Window
    {
        public WindowMain()
        {
            InitializeComponent();
        }

        #region--公用参数定义声明
        public int IDnumber = 0;
        int doublenum = 0;//双击计时器
        bool opinion_one, opinion_two, opinion_three = false;
        #endregion

        #region--公用方法调用
        /// <summary>
        /// 重置主界面背景数据
        /// </summary>
        public void ExitedProgramedActivited()
        {
            D_Jinpo jinpoDal = new D_Jinpo();
            List<T_Jinpo> backJinpomodel = new List<T_Jinpo>();
            backJinpomodel = jinpoDal.BlackGroundData_Query();
            this.DataGrid1.ItemsSource = null;
            if (backJinpomodel.Count > 0)
            {
                this.DataGrid1.ItemsSource = backJinpomodel;
            }
            else
            {

            }
        }
        #endregion

        #region --窗体打开事件
        //窗体一打开初始化
        private void WindowMain_Loaded(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region--窗体事件
        //点击按钮“X”关闭程序
        private void WindowMain_Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //鼠标双击窗口事件
        private void Win_mouser_double_click(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
            doublenum += 1;

            DispatcherTimer timer = new DispatcherTimer();

            timer.Interval = new TimeSpan(0, 0, 0, 0, 300);

            timer.Tick += (s, e1) => { timer.IsEnabled = false; doublenum = 0; };

            timer.IsEnabled = true;

            if (doublenum % 2 == 0)

            {

                timer.IsEnabled = false;

                doublenum = 0;

                if (this.WindowState == WindowState.Maximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                }
            }

        }
        #endregion

        #region --鼠标进入事件
        //第一个按钮进入
        private void one_mune_btn_Enter(object sender, MouseEventArgs e)
        {
            Staff_maintenance_Btn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFCFCFCF"));

        }
        //第二个鼠标进入
        private void two_mune_btn_Enter(object sender, MouseEventArgs e)
        {
            Payment_btn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFCFCFCF"));
        }

        //第三个鼠标进入
        #endregion

        #region --鼠标左键点击事件
        //第一个鼠标左键点击
        private void one_mune_btn_left_down(object sender, MouseButtonEventArgs e)
        {
            #region --背景样式初始化
            #region --颜色背景更改
            opinion_one = true;
            opinion_two = false;
            opinion_three = false;
            Payment_btn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            Payment_record.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            #endregion
            #region --背景显示隐藏
            GridView_0.Visibility = Visibility.Hidden;
            GridView_1.Visibility = Visibility.Visible;
            GridView_2.Visibility = Visibility.Hidden;
            GridView_3.Visibility = Visibility.Hidden;
            #endregion
            #endregion

            #region -- 背景数据初始化
            D_Jinpo jinpoDal = new D_Jinpo();
            List<T_Jinpo> backJinpomodel = new List<T_Jinpo>();
            backJinpomodel = jinpoDal.BlackGroundData_Query();

            if (backJinpomodel.Count > 0)
            {
                this.DataGrid1.ItemsSource = backJinpomodel;
            }
            else
            {

            }
            #endregion
        }
        //测试按钮鼠标点击
        private void onling_ztext(object sender, RoutedEventArgs e)
        {
            Ztext z = new Ztext();
            z.ShowDialog();
        }
        //鼠标点击添加按钮
        private void Add_Data_Win(object sender, RoutedEventArgs e)
        {
            WindowMainAdding addwin = new WindowMainAdding();
            addwin.ShowDialog();
            ExitedProgramedActivited();
        }
        //鼠标点击编辑按钮
        private void Edit_Data_Win(object sender, RoutedEventArgs e)
        {
            WindowMainEditing edit = new WindowMainEditing(IDnumber);
            edit.ShowDialog();
            ExitedProgramedActivited();
        }
        //鼠标点击查看DataGrid列表一列
        private void OrderinfodataGrid_Click(object sender, MouseButtonEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            var cell = dg.CurrentCell;
            try
            {
                int ID = ((Model.Models.T_Jinpo)cell.Item).ID;
                IDnumber = ID;
                D_Jinpo Idmode = new D_Jinpo();
                T_Jinpo tjmodel = new T_Jinpo();
                tjmodel = Idmode.scanmodelData(ID);
                NAME_one.Text = tjmodel.JinpoName;
                input_ID.Text = Convert.ToString(tjmodel.ID);
                one_num.Text = tjmodel.JinpoID;
                two_num.Text = tjmodel.JinpoIDCar;
                one_state.Text = tjmodel.JinpoPayState;
                two_state.Text = tjmodel.JinpoAttendState;
                phonenumber.Text = tjmodel.JinpoPhone;
            }
            catch (Exception ex)
            {
                MessageBox.Show("指定对象失败！");
            }



            //if (item != null)
            //{
            //    string Text = item[cell.Column.DisplayIndex].ToString();
            //}
        }
        //点击查询按钮按钮
        private void CleckScanData(object sender, RoutedEventArgs e)
        {
            string selectext = GridView_1_dropdowntype.Text;
            string inputstr = GridView_1_input_Scan.Text;
            D_Jinpo jinpoDal = new D_Jinpo();
            List<T_Jinpo> backJinpomodel = new List<T_Jinpo>();
            backJinpomodel = jinpoDal.BlackGroundData_Btn_Query(selectext, inputstr);
            this.DataGrid1.ItemsSource = null;
            if (backJinpomodel.Count > 0)
            {
                this.DataGrid1.ItemsSource = backJinpomodel;
            }
            else
            {

            }
        }
        //按钮点击删除按钮
        private void Deleted_btn(object sender, RoutedEventArgs e)
        {
            D_Jinpo Idmode = new D_Jinpo();
            bool tjmodel = Idmode.DeletmodelData(IDnumber);
            if (IDnumber == 0)
            {
                MessageBox.Show("请选择对象！再进行操作");
            }
            else
            {
                if (tjmodel)
                {
                    MessageBox.Show("删除成功！");
                }
                else
                {
                    MessageBox.Show("删除失败！");
                }
            }


            #region --删除后
            D_Jinpo jinpoDal = new D_Jinpo();
            List<T_Jinpo> backJinpomodel = new List<T_Jinpo>();
            backJinpomodel = jinpoDal.BlackGroundData_Query();
            this.DataGrid1.ItemsSource = null;
            if (backJinpomodel.Count > 0)
            {
                this.DataGrid1.ItemsSource = backJinpomodel;
            }
            else
            {

            }
            #endregion
        }
        //第二个鼠标左键点击
        private void two_mune_btn_left_down(object sender, MouseButtonEventArgs e)
        {
            #region --颜色背景更改
            opinion_one = false;
            opinion_two = true;
            opinion_three = false;
            Staff_maintenance_Btn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            Payment_record.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            #endregion
            #region --背景显示隐藏
            GridView_0.Visibility = Visibility.Hidden;
            GridView_1.Visibility = Visibility.Hidden;
            GridView_2.Visibility = Visibility.Visible;
            GridView_3.Visibility = Visibility.Hidden;
            #endregion
        }
        //第三个鼠标左键点击
        private void three_mune_btn_left_down(object sender, MouseButtonEventArgs e)
        {
            #region--颜色背景更改
            opinion_one = false;
            opinion_two = false;
            opinion_three = true;
            Staff_maintenance_Btn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            Payment_btn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            #endregion
            #region --背景显示隐藏
            GridView_0.Visibility = Visibility.Hidden;
            GridView_1.Visibility = Visibility.Hidden;
            GridView_2.Visibility = Visibility.Hidden;
            GridView_3.Visibility = Visibility.Visible;
            #endregion
        }
        #endregion

        #region --鼠标离开事件
        private void three_mune_btn_Enter(object sender, MouseEventArgs e)
        {
            Payment_record.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFCFCFCF"));
        }
        //第一个鼠标离开
        private void one_mune_btn_Leave(object sender, MouseEventArgs e)
        {
            if (opinion_one == true)
            {
                Staff_maintenance_Btn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFCFCFCF"));
            }
            else
            {
                Staff_maintenance_Btn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            }
        }
        //第二个鼠标离开
        private void two_mune_btn_Leave(object sender, MouseEventArgs e)
        {
            if (opinion_two == true)
            {
                Payment_btn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFCFCFCF"));
            }
            else
            {
                Payment_btn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            }
        }
        //第三个鼠标离开
        private void three_mune_btn_Leave(object sender, MouseEventArgs e)
        {
            if (opinion_three == true)
            {
                Payment_record.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFCFCFCF"));
            }
            else
            {
                Payment_record.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            }
        }
        #endregion

       
    }



}
