using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tonglian.Sdk.Models;

namespace Xc.Tonglian.Web
{
    public class TonglianConfig
    {
        public bool IsDev { get; set; }
        public string ServiceName { get; set; }

        public string SecretId { get; set; }
        public string SecretKey { get; set; }
        public string Authcus { get; set; }

        public string MerId { get; set; }

    }
}
