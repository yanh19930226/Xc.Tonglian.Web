using System;
using System.Collections.Generic;
using System.Text;

namespace Tonglian.Sdk.Models.Accounts
{
    public class AccountListRequest : BaseRequest<AccountListRequestModel>
    {
        public AccountListRequest(AccountListRequestModel data) : base(data)
        {
        }
        public override string Uri => "/cusacct/get";
    }

    public class AccountListRequestModel
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
        /// 账户ID
        /// </summary>
        //public int id { get; set; }

    }

    public class AccountListReponse
    {
        public string cusid { get; set; }
        public string accountNo { get; set; }
        public string currency { get; set; }
        public string accountName { get; set; }
        public string nature { get; set; }
        public string country { get; set; }
        public string province { get; set; }
        public string city { get; set; }
        public string cardorbook { get; set; }
        public string bicCode { get; set; }
     
    }
}
