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
            _client = new TonglianClient(EnvEnum.Dev, new HttpClient());
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
                stid = "202104191800",
            };

            var result = _client.RequestAsync(new ShopListRequest(accountListRequestModel));

            Assert.Equal(true, result.IsSuccess);
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
                stid= "202104191800",
                platform= "9101",
                currency="USD",
                exists= "01",
                sellerid="66666",
                monthamt=10,
                owner="yanh",
                storename="yanh",
                weburl="www.yanfun.com",
                categroy= "0011",


            };

            var result = _client.RequestAsync(new ShopCreateReqeust(createShop));

            Assert.Equal(true, result.IsSuccess);
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
                stid = "202104191800",
                platform = "9101",
                currency = "USD",
                exists = "01",
                sellerid = "66666",
                monthamt = 10,
                owner = "yanh",
                storename = "yanh",
                weburl = "www.yanfun.com",
                categroy = "0011",
            };

            var result = _client.RequestAsync(new ShopEditRequest(ShopEditRequest));

            Assert.Equal(true, result.IsSuccess);
        }
    }
}
