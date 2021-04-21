using System;
using System.Collections.Generic;
using System.Text;

namespace Tonglian.Sdk.Models.Merchants
{
    public class MerchantCreateRequest : BaseRequest<MerchantCreateRequestModel, MerchantCreateResponse>
    {
        public MerchantCreateRequest(MerchantCreateRequestModel data) : base(data)
        {

        }
        public override string Uri => "/mer/create";
    }

    public class MerchantCreateRequestModel
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
    }

    public class MerchantCreateResponse:BaseResponse
    {

    }
}
