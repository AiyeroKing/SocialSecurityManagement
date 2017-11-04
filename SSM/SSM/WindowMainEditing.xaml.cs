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
    /// WindowMainEditing.xaml 的交互逻辑
    /// </summary>
    public partial class WindowMainEditing : Window
    {
        public WindowMainEditing(int Id)
        {
            InitializeComponent();
            IDnumber = Id;
            InitializationData();
        }

        #region--公用参数定义声明
        public int IDnumber;
        public int btn1 = 0;
        public int btn2 = 0;
        #endregion

        #region--事件处理
        /// <summary>
        /// 数据初始化
        /// </summary>
        public void InitializationData()
        {
            D_Jinpo Idmode = new D_Jinpo();
            T_Jinpo tjmodel = new T_Jinpo();
            tjmodel = Idmode.scanmodelData(IDnumber);
            inputName.Text = tjmodel.JinpoName;
            IDnumber = tjmodel.ID;
            inputJinpoID.Text = tjmodel.JinpoID;
            inputJinpoIDCar.Text = tjmodel.JinpoIDCar;
            JinpoPayState_Text.Text = tjmodel.JinpoPayState;
            input_PayMoney.Text = tjmodel.JinpoManey.ToString();
            JinpoAttendState_Text.Text = tjmodel.JinpoAttendState;
            inputJinpoPhone.Text = tjmodel.JinpoPhone;
        }
        /// <summary>
        /// 执行更新更改
        /// </summary>
        public void updateWinDatal()
        {
            D_Jinpo Djinpo = new D_Jinpo();
            T_Jinpo model = new T_Jinpo();
            model.ID = IDnumber;//ID
            model.JinpoName = inputName.Text;//姓名
            model.JinpoID = inputJinpoID.Text;//档案号
            model.JinpoIDCar = inputJinpoIDCar.Text;//身份证号
            model.JinpoManey = Convert.ToInt32(input_PayMoney.Text);//缴费金额
            if (btn1 == 1)
            {
                model.JinpoPayState = JinpoPayState_Combo.Text;//缴费方式
            }
            else
            {
                model.JinpoPayState = JinpoPayState_Text.Text;//缴费方式
            }
            if (btn2 == 1)
            {
                model.JinpoAttendState = JinpoAttendState_Combo.Text;//社保方式
            }
            else
            {
                model.JinpoAttendState = JinpoAttendState_Text.Text;//社保方式
            }

            model.JinpoPhone = inputJinpoPhone.Text;//联系方式

            bool GetResult = Djinpo.EditedWin_Updata(model);

            if (GetResult)
            {
                MessageBox.Show("数据更新成功");
            }
            else
            {
                MessageBox.Show("数据操作失败");
            }

        }
        //更改
        private void Edit_win_add_win_ok(object sender, RoutedEventArgs e)
        {
            if (IDnumber != 0)
            {
                updateWinDatal();
                this.Close();
            }
            else
            {
                this.Close();
            }
        }
        /// <summary>
        /// 取消更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Edit_win_add_win(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion

        #region -- 小按钮
        private void Conbox_1_show(object sender, RoutedEventArgs e)
        {
            JinpoPayState_Text.Visibility = Visibility.Hidden;
            JinpoPayState_Combo.Visibility = Visibility.Visible;
            Combo_1.Visibility = Visibility.Hidden;
            btn1 = 1;
        }

        private void Conbox_2_show(object sender, RoutedEventArgs e)
        {
            JinpoAttendState_Text.Visibility = Visibility.Hidden;
            JinpoAttendState_Combo.Visibility = Visibility.Visible;
            Combo_2.Visibility = Visibility.Hidden;
            btn2 = 1;
        }
        #endregion


    }
}
