using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    /// <summary>
    /// 登陆设置页面请求数据
    /// </summary>
    public class T_LoginSet
    {
        //ID
        public int ID { get; set; }
        //数据库IP地址
        public string DataBaseIP { get; set; }
        //数据库实例
        public string DataBaseInstance { get; set; }
        //数据库名称
        public string DataBaseName { get; set; }
        //数据库用户
        public string DataBaseUser { get; set; }
        //数据库密码
        public string DataBasePassword { get; set; }
    }
}
