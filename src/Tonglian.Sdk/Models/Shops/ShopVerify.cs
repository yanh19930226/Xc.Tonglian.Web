using System;
using System.Collections.Generic;
using System.Text;

namespace Tonglian.Sdk.Models.Shops
{
    public class ShopVerifyRequest
    {
        public string cusid { get; set; }
        public string stid { get; set; }
        public string sid { get; set; }
        public string pid { get; set; }
        public string state { get; set; }
        public string stateExplain { get; set; }
    }

    public class ShopVerifyResponse
    {

    }
}
