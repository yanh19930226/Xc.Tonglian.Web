﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tonglian.Sdk.Models.Merchants
{
    public class MerchantVerifyRequest
    {
        public string regid { get; set; }
        public string cusid { get; set; }

        public string mername { get; set; }

        public string areacode { get; set; }

        public string organid { get; set; }

        public string products { get; set; }

        public string merid { get; set; }
    }

    public class MerchantVerifyResponse
    {

    }
}
