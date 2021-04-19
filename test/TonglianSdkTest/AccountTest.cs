using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tonglian.Sdk;
using Tonglian.Sdk.Models.Accounts;
using Tonglian.Sdk.Models.Exrates;
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
        /// 汇率查询
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task getExrateList()
        {
            var ExrateRequestModel = new ExrateRequestModel()
            {
                srcccy = "USD",
                dstccy = "CNY",
            };

            var result = _client.RequestAsync(new ExrateRequest(ExrateRequestModel));

            Assert.Equal(true, result.IsSuccess);
        }

        /// <summary>
        /// 账号查询
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task getAccountsList()
        {
            var accountListRequestModel = new AccountListRequestModel()
            {
                cusid = "665000000001030",
                accountNo= "666666",
                currency = "CNY",
            };

            var result = _client.RequestAsync(new AccountListRequest(accountListRequestModel));

            Assert.Equal(true, result.IsSuccess);
        }

        /// <summary>
        /// 账号注册
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task accountCreate()
        {
            var AccountCreateModel = new AccountCreateModel()
            {
                cusid = "665000000001030",
                accountNo = "666666",
                accountName = "yanh",
                currency = "CNY",
                nature = "1",
                country = "CHN",
                city = "宁波",
                province= "000943",
                cardorbook="02",
                biccode= "105332041006",
                addr= "中国建设银行宁波市北仑区支行"
            };

            var result = _client.RequestAsync(new AccountCreateRequest(AccountCreateModel));

            Assert.Equal(true, result.IsSuccess);
        }

    }
}
