using System;
using System.Collections.Generic;
using System.Text;

namespace Tonglian.Sdk.Models.Customers
{
    public class CustomerVerifyRequest
    {
        public string cusid { get; set; }
        public string regid { get; set; }
        public string cusname { get; set; }
        public string tel { get; set; }
        public string creditcode { get; set; }
        public string organcode { get; set; }

        public string buslicense { get; set; }
        public string state { get; set; }
        public string stateExplain { get; set; }
    }

    public class CustomerVerifyResponse
    {
    }
}
