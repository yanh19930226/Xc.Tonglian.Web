using System;
using System.Collections.Generic;
using System.Text;

namespace Tonglian.Sdk.Models.Exrates
{
    public class ExrateRequest : BaseRequest<ExrateRequestModel>
    {
        public ExrateRequest(ExrateRequestModel data) : base(data)
        {

        }
        public override string Uri => "/info/getexrate";
    }

    public class ExrateRequestModel
    {
        public string srcccy { get; set; }

        public string dstccy{ get; set; }
    }

    public class ExrateResponse
    {

    }
}
