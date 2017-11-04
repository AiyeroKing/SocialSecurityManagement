using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class Result<T>
    {
        /// <summary>
        /// 结果标识 -1:失败  1:成功
        /// </summary>
        public int Flag { get; set; } = -1;

        /// <summary>
        /// 结果信息
        /// </summary>
        public string Info { get; set; }

        /// <summary>
        /// 返回的数据信息
        /// </summary>
        public T Data { get; set; }
    }
}
