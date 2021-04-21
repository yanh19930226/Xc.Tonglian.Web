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
            _client = new TonglianClient("gcpservice", "2C52B53741103B2FB-1GA08-3", "MFkwEwYHKoZIzj0CAQYIKoEcz1UBgi0DQgAEob2LdDlv18Uy/4r0VKW2qjm1rdezGcTHw6RhpL2lbQOJgHQAU2etqQc7IWCywRkMrokFX0nqfDBMrtqBeCZ98A==", "665000000001030", "668000000001074", EnvEnum.Dev);
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

        [Fact]
        public async Task createCustomer()
        {
            var createCustomer = new CustomerCreateRequestModel()
            {
                ctid = "232332",
                cusname="sdf555",
                address = "福州",
                belongbranch = "9999393910",
                areacode = "CHN",
                flag="2",
                tel = "111111",
                cuskind = "3",
                businesskind = "3",
                threcertflag = "1",
                creditcode = "111111",
                organcode = "1111",
                buslicense = "11111",
                creditcodeexpire = "2022-4-04-12",
                legalidno = "111111",
                legal = "22ss",
                legalidexpire = "2022-4-04-12",
                businessplace = "1",
                websitecountry = "CHN",
                website = "www.ssdf.com",
                tradingplatform = "www.ssdf.com",
                stafftotal = 20,
                protocolexpire = "2022-4-04-12",
                tlinstcode = "D01306",
                holdername = "222",
                holderidno = "122",
                holderexpire = "2022-4-04-12",
                bnfname = "eer",
                bnfidno = "1111",
                bnfexpire = "2022-4-04-12",
                bnfaddress ="dsfdsf",
                legalemail = "891367701@qq.com",
            };

            var result = _client.RequestAsync(new CustomerCreateRequest(createCustomer));

            Assert.Equal("", result.rspinfo);
        }
    }
}
