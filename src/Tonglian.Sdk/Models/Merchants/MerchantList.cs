using System;
using System.Collections.Generic;
using System.Text;

namespace Tonglian.Sdk.Models.Merchants
{
    public class MerchantListRequest : BaseRequest<MerchantListRequestModel, MerchantListResponse>
    {
        public MerchantListRequest(MerchantListRequestModel data) : base(data)
        {

        }
        public override string Uri => "/mer/get";
    }
    public class MerchantListRequestModel
    {
        /// <summary>
        /// 跟踪号
        /// </summary>
        public string mtid { get; set; }
        /// <summary>
        /// 商户号
        /// </summary>
        public string merid { get; set; }
    }
    public class MerchantListResponse : BaseResponse
    {
        /// <summary>
        /// 注册号
        /// </summary>
        public string mtid { get; set; }
        /// <summary>
        /// 客户号
        /// </summary>
        public string cusid { get; set; }
        /// <summary>
        /// 商户名称
        /// </summary>
        public string mername { get; set; }
        /// <summary>
        /// 业务地区
        /// </summary>
        public string areacode { get; set; }
        /// <summary>
        /// 归属机构
        /// </summary>
        public string organid { get; set; }
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
