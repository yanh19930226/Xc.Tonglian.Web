using System;
using System.Collections.Generic;
using System.Text;

namespace Tonglian.Sdk.Models.Customers
{
    public class CustomerListRequest : BaseRequest<CustomerListRequestModel, CustomerListResponse>
    {
        public CustomerListRequest(CustomerListRequestModel data) : base(data)
        {

        }
        public override string Uri => "/entity/get";
    }

    public class CustomerListRequestModel 
    {
        /// <summary>
        /// 客户号
        /// </summary>
        public string ctid { get; set; }
    }

    public class CustomerListResponse
    {
        public string ctid { get; set; }
        public string entityid { get; set; }
        public string entityname { get; set; }
        public string state { get; set; }

        public string stateExplain { get; set; }
    }
}
