using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tonglian.Sdk.Models.Shops;

namespace Xc.Tonglian.Web.Services
{
    public interface IShopService
    {
        void CreateShop();


        ShopListResponse GetShopList();
    }
}
