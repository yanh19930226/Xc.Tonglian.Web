using System;
using System.Collections.Generic;
using System.Text;

namespace Tonglian.Sdk.Models.Merchants
{
    public class MerchantCreateRequest
    {
        public string mtid { get; set; }
        public string cusid { get; set; }

        public string mername { get; set; }

        public string areacode { get; set; }

        public string organid { get; set; }

        public string productId { get; set; }
    }

    public class MerchantCreateResponse
    {

    }
}
