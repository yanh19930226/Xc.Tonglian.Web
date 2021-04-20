using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xc.Tonglian.Web.Models.Domain
{
    public class Account: Entity
    {
        /// <summary>
        /// 客户号
        /// </summary>
        public string CusId { get; set; }
        /// <summary>
        /// 账户号
        /// </summary>
        public string AccountNo { get; set; }
        /// <summary>
        /// 账户币种
        /// </summary>
        public string Currency { get; set; }
        /// <summary>
        /// 账户名
        /// </summary>
        public string AccountName { get; set; }
        /// <summary>
        /// 账户类型
        /// </summary>
        public string Nature { get; set; }
        /// <summary>
        /// 账户地区
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// 账户省份
        /// </summary>
        public string Province { get; set; }
        /// <summary>
        /// 账户城市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 卡折类型
        /// </summary>
        public string CardorBook { get; set; }
        /// <summary>
        /// 当地行号
        /// </summary>
        public string BicCode { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Addr { get; set; }
    }
}
