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
    /// WindowMainAdding.xaml 的交互逻辑
    /// </summary>
    public partial class WindowMainAdding : Window
    {
        public WindowMainAdding()
        {
            InitializeComponent();
        }

        #region--事件
        /// <summary>
        /// 确定添加窗口按钮点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ok_win_add_win_btn(object sender, RoutedEventArgs e)
        {
            T_Jinpo mode = new T_Jinpo();
            mode.JinpoName = JinpoNamestr.Text;
            mode.JinpoID = JinpoIDstr.Text;
            mode.JinpoIDCar = JinpoIDCarstr.Text;
            mode.JinpoManey = Convert.ToInt32(JinpoManeyint.Text);
            mode.JinpoPayState = combox_1.Text;
            mode.JinpoAttendState = combox_2.Text;
            mode.JinpoPhone = JinpoPhonestr.Text;
            D_Jinpo Djinpo = new D_Jinpo();
            bool GetResult = Djinpo.AddedWin_Add(mode);
        }
        /// <summary>
        /// 关闭添加窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void close_win_add_win(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion
       
    }
}
