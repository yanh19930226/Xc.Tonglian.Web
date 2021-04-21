using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tonglian.Sdk;
using Tonglian.Sdk.Models.Merchants;
using Xunit;

namespace TonglianSdkTest
{
    public class MerchantTest
    {
        private readonly TonglianClient _client;
        public MerchantTest()
        {
            _client = new TonglianClient("gcpservice", "2C52B53741103B2FB-1GA08-3", "MFkwEwYHKoZIzj0CAQYIKoEcz1UBgi0DQgAEob2LdDlv18Uy/4r0VKW2qjm1rdezGcTHw6RhpL2lbQOJgHQAU2etqQc7IWCywRkMrokFX0nqfDBMrtqBeCZ98A==", "665000000001030", "668000000001074", EnvEnum.Dev);
        }

        /// <summary>
        /// 商户查询
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task getMerchantList()
        {
            var MerchantListRequestModel = new MerchantListRequestModel()
            {
                mtid = "11111122",
                merid= "668000000001074"
            };

            var result = _client.RequestAsync(new MerchantListRequest(MerchantListRequestModel));

            Assert.Equal("", result.rspinfo);
        }

        /// <summary>
        /// 商户注册
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task merchantCreate()
        {
            var merchantCreateModel = new MerchantCreateRequestModel()
            {
                mtid="11111122",
                cusid = "665000000001030",
                mername="yanh",
                areacode= "CHN",
                organid="0",
            };

            var result = _client.RequestAsync(new MerchantCreateRequest(merchantCreateModel));

            Assert.Equal("", result.rspinfo);
        }

        /// <summary>
        /// 商户修改
        /// </summary>
        /// <returns></returns>
        //[Fact]
        //public async Task merchantEdit()
        //{
        //    var merchantEdit = new MerchantEditRequestModel()
        //    {
        //        mtid = "111111",
        //        cusid = "665000000001030",
        //        mername = "yanh",
        //        areacode = "CHN",
        //        organid = "0",
        //    };

        //    var result = _client.RequestAsync(new MerchantEditRequest(merchantEdit));

        //    Assert.Equal("", result.rspinfo);
        //}
    }
}
