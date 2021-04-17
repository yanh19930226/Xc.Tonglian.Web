using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tonglian.Sdk;
using Tonglian.Sdk.Models.Accounts;
using Xunit;

namespace TonglianSdkTest
{
    public class AccountTest
    {
        private readonly TonglianClient _client;
        public AccountTest()
        {
            _client = new TonglianClient(EnvEnum.Dev,new HttpClient());
        }
        /// <summary>
        /// 账号查询
        /// </summary>
        /// <returns></returns>
        //[Fact]
        //public async Task getAccountsList()
        //{
        //    var accountListRequestModel = new AccountListRequestModel() {
        //         cusid= "1000024726"
        //    };

        //    var result = _client.RequestAsync(new AccountListRequest(accountListRequestModel));

        //    Assert.Equal(true, result.Result.IsSuccess);
        //}
    }
}
