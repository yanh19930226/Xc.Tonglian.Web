using System;
using System.Collections.Generic;
using System.Text;

namespace Tonglian.Sdk.Models.Merchants
{
    public class MerchantEditRequest : BaseRequest<MerchantEditRequestModel, MerchantEditResponse>
    {
        public MerchantEditRequest(MerchantEditRequestModel data) : base(data)
        {

        }
        public override string Uri => "/mer/update";
    }

    public class MerchantEditRequestModel
    {
        /// <summary>
        /// 注册号
        /// </summary>
        public string regid { get; set; }
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
        ///归属机构
        /// </summary>
        public string organid { get; set; }
        /// <summary>
        /// 开通产品
        /// </summary>
        public string products { get; set; }
    }

    public class MerchantEditResponse
    {
    }
}
