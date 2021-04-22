using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tonglian.Sdk;
using Tonglian.Sdk.Models.Shops;
using Xunit;

namespace TonglianSdkTest
{
    public class ShopTest
    {
        private readonly TonglianClient _client;

        public ShopTest()
        {
            _client = new TonglianClient("gcpservice", "2C52B53741103B2FB-1GA08-3", "MFkwEwYHKoZIzj0CAQYIKoEcz1UBgi0DQgAEob2LdDlv18Uy/4r0VKW2qjm1rdezGcTHw6RhpL2lbQOJgHQAU2etqQc7IWCywRkMrokFX0nqfDBMrtqBeCZ98A==", "665000000001030", "668000000001074", EnvEnum.Dev);
        }
        /// <summary>
        /// 店铺查询
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task getShopList()
        {
            var accountListRequestModel = new ShopListRequestModel()
            {
                stid = "202104221435",
            };

            var result = _client.RequestAsync(new ShopListRequest(accountListRequestModel));

            Assert.Equal("", result.rspinfo);
        }

        /// <summary>
        /// 创建店铺
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task createShop()
        {
            var createShop = new ShopCreateReqeustModel()
            {
                stid= "202104221435",
                platform= "9101",
                currency = "USD",
                exists = "01",
                sellerid="66666",
                monthamt=10,
                owner="yanh",
                storename="yanh",
                weburl="www.yanfun.com",
                categroy= "0011",
            };

            var result = _client.RequestAsync(new ShopCreateReqeust(createShop));

            Assert.Equal("", result.rspinfo);
        }

        /// <summary>
        /// 修改店铺
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task editShop()
        {
            var ShopEditRequest = new ShopEditRequestModel()
            {
                stid = "202104221435",
                platform = "9101",
                currency = "USD",
                exists = "01",
                sellerid = "66666",
                monthamt = 207,
                owner = "yanh",
                storename = "yanh",
                weburl = "www.yanfun.com",
                categroy = "0011",
            };

            var result = _client.RequestAsync(new ShopEditRequest(ShopEditRequest));

            Assert.Equal("", result.rspinfo);
        }
    }
}
