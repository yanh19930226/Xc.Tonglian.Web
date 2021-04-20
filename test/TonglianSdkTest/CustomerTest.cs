using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tonglian.Sdk;
using Tonglian.Sdk.Models.Customers;
using Xunit;

namespace TonglianSdkTest
{
    public class CustomerTest
    {

        private readonly TonglianClient _client;
        public CustomerTest()
        {
            //_client = new TonglianClient("", "", "", new Tonglian.Sdk.Models.Config(), EnvEnum.Dev);
        }
        /// <summary>
        /// 客户查询
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task getCustomerList()
        {
            var accountListRequestModel = new CustomerListRequestModel()
            {
                cusid = "665000000001030"
            };

            var result = _client.RequestAsync(new CustomerListRequest(accountListRequestModel));

            Assert.Equal("", result.rspinfo);
        }
    }
}
