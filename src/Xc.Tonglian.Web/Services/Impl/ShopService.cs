using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tonglian.Sdk;
using Tonglian.Sdk.Models.Shops;
using Xc.Tonglian.Web.Models.Dto.Shop;

namespace Xc.Tonglian.Web.Services.Impl
{
    public class ShopService : IShopService
    {
        private TonglianClient _client;
        public ShopService(TonglianClient client) 
        {
            _client = client;
        }
        public ShopCreateResponse CreateShop(ShopCreateDto dto)
        {
            var createShop = new ShopCreateReqeustModel()
            {
                stid = dto.StId,
                platform = dto.Platform,
                currency = dto.Currency,
                exists = dto.Exists,
                sellerid = dto.SellerId,
                monthamt = dto.Monthamt,
                owner = dto.Owner,
                storename = dto.StoreName,
                weburl = dto.Weburl,
                categroy = dto.Categroy,
            };
            return _client.RequestAsync(new ShopCreateReqeust(createShop));
        }

        public ShopEditResponse EditShop(ShopEditDto dto)
        {
            var ShopEditRequest = new ShopEditRequestModel()
            {
                stid = dto.StId,
                platform = dto.Platform,
                currency = dto.Currency,
                exists = dto.Exists,
                sellerid = dto.SellerId,
                monthamt = dto.Monthamt,
                owner = dto.Owner,
                storename = dto.StoreName,
                weburl = dto.Weburl,
                categroy = dto.Categroy,
            };

            return _client.RequestAsync(new ShopEditRequest(ShopEditRequest));
        }
    }
}
