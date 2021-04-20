using System;
using System.Collections.Generic;
using System.Text;

namespace Tonglian.Sdk.Models.Shops
{

    public class ShopCreateReqeust : BaseRequest<ShopCreateReqeustModel, ShopCreateResponse>
    {
        public ShopCreateReqeust(ShopCreateReqeustModel data) : base(data)
        {

        }
        public override string Uri => "/store/create";
    }

    public class ShopCreateReqeustModel
    {
        /// <summary>
        /// 跟踪号
        /// </summary>
        public string stid { get; set; }
        /// <summary>
        /// 所属平台
        /// </summary>
        public string platform { get; set; }
        /// <summary>
        /// 收入款币种
        /// </summary>
        public string currency { get; set; }
        /// <summary>
        /// 有无店铺
        /// </summary>
        public string exists { get; set; }
        /// <summary>
        /// 卖家编号
        /// </summary>
        public string sellerid { get; set; }
        /// <summary>
        /// 月交易量
        /// </summary>
        public int monthamt { get; set; }
        /// <summary>
        /// 店铺所有者名称
        /// </summary>
        public string owner { get; set; }
        /// <summary>
        /// 店铺名称
        /// </summary>
        public string storename { get; set; }
        /// <summary>
        /// 店铺/站点链接
        /// </summary>
        public string weburl { get; set; }
        /// <summary>
        /// 销售类目
        /// </summary>
        public string categroy { get; set; }
        /// <summary>
        /// 运营时间
        /// </summary>
        public int runtime { get; set; }
        /// <summary>
        /// 授权令牌
        /// </summary>
        public string authtoken { get; set; }

    }
    public class ShopCreateResponse:BaseResponse
    {
        public string stid { get; set; }
        public string sid { get; set; }

        public string pid { get; set; }

        public string state { get; set; }

        public string stateExplain { get; set; }

    }

}
