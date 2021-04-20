using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xc.Tonglian.Web.Models.Dto.Merchant
{
    public class MerchantCreateDto
    {
        /// <summary>
        /// 注册号
        /// </summary>
        public string RegId { get; set; }
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
        /// 开通产品
        /// </summary>
        public string Products { get; set; }
    }
}
