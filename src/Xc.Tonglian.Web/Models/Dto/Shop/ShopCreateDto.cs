using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xc.Tonglian.Web.Models.Enums;

namespace Xc.Tonglian.Web.Models.Dto.Shop
{
    public class ShopCreateDto
    {
        /// <summary>
        /// 跟踪号
        /// </summary>
        public string StId { get; set; }
        /// <summary>
        /// 所属平台
        /// </summary>
        public string Platform { get; set; }
        /// <summary>
        /// 收入款币种
        /// </summary>
        public string Currency { get; set; }
        /// <summary>
        /// 有无店铺
        /// </summary>
        public string Exists { get; set; }
        /// <summary>
        /// 卖家编号
        /// </summary>
        public string SellerId { get; set; }
        /// <summary>
        /// 月交易量
        /// </summary>
        public int Monthamt { get; set; }
        /// <summary>
        /// 店铺所有者名称
        /// </summary>
        public string Owner { get; set; }
        /// <summary>
        /// 店铺名称
        /// </summary>
        public string StoreName { get; set; }
        /// <summary>
        /// 店铺/站点链接
        /// </summary>
        public string Weburl { get; set; }
        /// <summary>
        /// 销售类目
        /// </summary>
        public string Categroy { get; set; }
        /// <summary>
        /// 运营时间
        /// </summary>
        public int Runtime { get; set; }
        /// <summary>
        /// 授权令牌
        /// </summary>
        public string AuthToken { get; set; }
        /// <summary>
        /// 待审核
        /// </summary>
        public int Status { get; set; } = (int)StatusEnum.Verifing;
    }
}
