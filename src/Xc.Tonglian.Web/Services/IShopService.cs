using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tonglian.Sdk.Models.Shops;
using Xc.Tonglian.Web.Models.Dto.Shop;

namespace Xc.Tonglian.Web.Services
{
    public interface IShopService
    {
        ShopCreateResponse CreateShop(ShopCreateDto dto);

        ShopEditResponse EditShop(ShopEditDto dto);
    }
}
