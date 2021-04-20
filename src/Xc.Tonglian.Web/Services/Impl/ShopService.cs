using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tonglian.Sdk;
using Tonglian.Sdk.Models.Shops;

namespace Xc.Tonglian.Web.Services.Impl
{
    public class ShopService : IShopService
    {
        private TonglianClient _client;
        public ShopService(TonglianClient client) 
        {
            _client = client;
        }
        public void CreateShop()
        {
            throw new NotImplementedException();
        }

        public ShopListResponse GetShopList()
        {
            var req = new ShopListRequestModel()
            {
                stid = "202104191800",
            };

            return _client.RequestAsync(new ShopListRequest(req));
        }
    }
}
