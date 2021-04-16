using System;
using System.Collections.Generic;
using System.Text;

namespace Tonglian.Sdk.Models.Accounts
{
    public class AccountCreateRequest/*:BaseRequest<>*/
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

    public class AccountCreateResponse
    {

    }
}
