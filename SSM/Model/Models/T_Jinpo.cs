using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    /// <summary>
    /// 主程序主界面请求数据
    /// </summary>
    public class T_Jinpo
    {
        //投保人ID或者投保人编号
        public int ID { get; set; }
        //投保人姓名
        public string JinpoName { get; set; }
        //投保人档案号
        public string JinpoID { get; set; }
        //投保人身份证号
        public string JinpoIDCar { get; set; }
        //投保人缴费金额
        public int JinpoManey { get; set; }
        //投保人联系方式
        public string JinpoPhone { get; set; }
        //投保人缴费方式
        public string JinpoPayState { get; set; }
        //投保人投保方式
        public string JinpoAttendState { get; set; }
    }
}
