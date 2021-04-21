using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xc.Tonglian.Web.Models.Enums;

namespace Xc.Tonglian.Web.Models.Dto.Merchant
{
    public class MerchantCreateDto
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
        /// 待审核
        /// </summary>
        public int Status { get; set; } = (int)StatusEnum.Verifing;
    }
}
