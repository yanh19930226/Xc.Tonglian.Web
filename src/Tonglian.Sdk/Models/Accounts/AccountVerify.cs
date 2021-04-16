using System;
using System.Collections.Generic;
using System.Text;

namespace Tonglian.Sdk.Models.Accounts
{
    public class AccountVerifyRequest
    {
        public string id { get; set; }
        public string cusid { get; set; }
        public string accountNo { get; set; }
        public string currency { get; set; }
    }
    public class AccountVerifyResponse
    {

    }

}
