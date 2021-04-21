using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tonglian.Sdk.Models.Merchants;
using Xc.Tonglian.Web.Models.Dto.Merchant;

namespace Xc.Tonglian.Web.Services
{
    public interface IMerchantService
    {
        MerchantCreateResponse CreateMerchant(MerchantCreateDto dto);

        MerchantEditResponse EditMerchant(MerchantEditDto dto);
    }
}
