using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    /// <summary>
    /// 登陆页面请求数据Model
    /// </summary>
   public  class T_Admin
    {
        //ID
        public int ID { get; set; }
        //用户名
        public string UserName { get; set; }
        //密码
        public string PassWord { get; set; }

    }
}
