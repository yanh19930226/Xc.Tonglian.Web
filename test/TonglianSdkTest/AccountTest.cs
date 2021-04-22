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
            _client = new TonglianClient("gcpservice", "2C52B53741103B2FB-1GA08-3", "MFkwEwYHKoZIzj0CAQYIKoEcz1UBgi0DQgAEob2LdDlv18Uy/4r0VKW2qjm1rdezGcTHw6RhpL2lbQOJgHQAU2etqQc7IWCywRkMrokFX0nqfDBMrtqBeCZ98A==", "665000000001030", "668000000001074", EnvEnum.Dev);
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

            Assert.Equal("", result.rspinfo);
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
                accountNo= "666666771112223",
                currency = "CNY",
            };

            var result = _client.RequestAsync(new AccountListRequest(accountListRequestModel));

            Assert.Equal("", result.rspinfo);
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
                accountNo = "666666771112223",
                accountName = "yanh",
                currency = "CNY",
                nature ="1",
                country = "CHN",
                city = "宁波",
                province= "000943",
                cardorbook="02",
                biccode= "105332041006",
                addr= "中国建设银行宁波市北仑区支行"
            };

            var result = _client.RequestAsync(new AccountCreateRequest(AccountCreateModel));

            Assert.Equal("", result.rspinfo);
        }


        /// <summary>
        /// 账号修改
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task accountEdit()
        {
            var AccountCreateModel = new AccountEditRequestModel()
            {
                cusid = "665000000001030",
                accountNo = "666666771112223",
                accountName = "yanh1111",
                currency = "CNY",
                nature = "1",
                country = "CHN",
                city = "宁波",
                province = "000943",
                cardorbook = "02",
                biccode = "105332041006",
                addr = "中国建设银行宁波市北仑区支行"
            };

            var result = _client.RequestAsync(new AccountEditRequest(AccountCreateModel));

            Assert.Equal("", result.rspinfo);
        }

    }
}
