﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xc.Tonglian.Web.Models.Domain
{
    public class Merchant : Entity
    {
        /// <summary>
        /// 注册号
        /// </summary>
        public string Mtid { get; set; }
        /// <summary>
        /// 客户号
        /// </summary>
        public string CusId { get; set; }
        /// <summary>
        /// 商户名称
        /// </summary>
        public string MerName { get; set; }
        /// <summary>
        /// 业务地区
        /// </summary>
        public string AreaCode { get; set; }
        /// <summary>
        ///归属机构
        /// </summary>
        public string OrganId { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 用户
        /// </summary>
        public long UserId { get; set; }

        public virtual User User { get; set; }
    }
}
