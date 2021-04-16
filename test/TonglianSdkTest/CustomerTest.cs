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
            _client = new TonglianClient(EnvEnum.Dev, new HttpClient());
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
                ctid = "1000024726"
            };

            var result = _client.RequestAsync(new CustomerListRequest(accountListRequestModel));

            Assert.Equal(true, result.Result.IsSuccess);
        }
    }
}
