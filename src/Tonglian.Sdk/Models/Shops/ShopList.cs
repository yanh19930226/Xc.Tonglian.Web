using System;
using System.Collections.Generic;
using System.Text;

namespace Tonglian.Sdk.Models.Shops
{
    public class ShopListRequest : BaseRequest<ShopListRequestModel>
    {
        public ShopListRequest(ShopListRequestModel data) : base(data)
        {

        }
        public override string Uri => "/store/get";
    }
    public class ShopListRequestModel
    {
        /// <summary>
        /// 跟踪号
        /// </summary>
        public string stid { get; set; }
        /// <summary>
        /// 店铺号
        /// </summary>
        public string sid { get; set; }
    }
    public class ShopListResponse:BaseResponse
    {
        /// <summary>
        /// 跟踪号
        /// </summary>
        public string stid { get; set; }
        /// <summary>
        /// 店铺号
        /// </summary>
        public string sid { get; set; }
        /// <summary>
        /// 平台ID
        /// </summary>
        public string pid { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string state { get; set; }
        /// <summary>
        /// 状态描述
        /// </summary>
        public string stateExplain { get; set; }
    }
}
