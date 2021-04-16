using System;
using System.Collections.Generic;
using System.Text;

namespace Tonglian.Sdk.Models.Shops
{
    public class ShopEditRequest
    {
        public string stid { get; set; }
        public string platform { get; set; }

        public string currency { get; set; }

        public string exists { get; set; }

        public string sellerid { get; set; }

        public int monthamt { get; set; }

        public string owner { get; set; }


        public string storename { get; set; }

        public string weburl { get; set; }

        public string categroy { get; set; }

        public int runtime { get; set; }

        public string authtoken { get; set; }
    }

    public class ShopEditResponse
    {
        public string stid { get; set; }
        public string sid { get; set; }

        public string pid { get; set; }

        public string state { get; set; }

        public string stateExplain { get; set; }
    }
}
