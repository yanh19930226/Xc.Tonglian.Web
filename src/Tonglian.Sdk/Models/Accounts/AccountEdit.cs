using System;
using System.Collections.Generic;
using System.Text;

namespace Tonglian.Sdk.Models.Accounts
{

    public class AccountEditRequest : BaseRequest<AccountEditRequestModel, AccountEditResponse>
    {
        public AccountEditRequest(AccountEditRequestModel data) : base(data)
        {

        }
        public override string Uri => "/cusacct/update";
    }

    public class AccountEditRequestModel
    {
        /// <summary>
        /// 客户号
        /// </summary>
        public string cusid { get; set; }
        /// <summary>
        /// 账户号
        /// </summary>
        public string accountNo { get; set; }
        /// <summary>
        /// 账户币种
        /// </summary>
        public string currency { get; set; }
        /// <summary>
        /// 账户名
        /// </summary>
        public string accountName { get; set; }
        /// <summary>
        /// 账户类型
        /// </summary>
        public string nature { get; set; }
        /// <summary>
        /// 账户地区
        /// </summary>
        public string country { get; set; }
        /// <summary>
        /// 账户省份
        /// </summary>
        public string province { get; set; }
        /// <summary>
        /// 账户城市
        /// </summary>
        public string city { get; set; }
        /// <summary>
        /// 卡折类型
        /// </summary>
        public string cardorbook { get; set; }
        /// <summary>
        /// 当地行号
        /// </summary>
        public string biccode { get; set; }
        /// <summary>
        /// 开户行地址
        /// </summary>
        public string addr { get; set; }
    }

    public class AccountEditResponse:BaseResponse
    {

    }
}
