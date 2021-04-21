using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xc.Tonglian.Web.Models.Domain;
using Xc.Tonglian.Web.Models.Dto.Account;
using Xc.Tonglian.Web.Models.Dto.Customer;
using Xc.Tonglian.Web.Models.Dto.Merchant;
using Xc.Tonglian.Web.Models.Dto.Shop;

namespace Xc.Tonglian.Web.Profiles
{
    public class AutoMapProfile:Profile
    {
        public AutoMapProfile()
        {

            #region Shop

            CreateMap<ShopCreateDto, Shop>();

            CreateMap<Shop, ShopCreateDto>();

            CreateMap<ShopEditDto, Shop>();

            CreateMap<Shop, ShopEditDto>();

            #endregion


            #region Customer

            CreateMap<CustomerCreateDto, Customer>();

            CreateMap<Customer, CustomerCreateDto>();

            CreateMap<CustomerEditDto, Customer>();

            CreateMap<Customer, CustomerEditDto>();

            #endregion

            #region Account

            CreateMap<AccountCreateDto, Account>();

            CreateMap<Account, AccountCreateDto>();

            CreateMap<AccountEditDto, Account>();

            CreateMap<Account, AccountEditDto>();

            #endregion

            #region Merchant

            CreateMap<MerchantCreateDto, Merchant>();

            CreateMap<Merchant, MerchantCreateDto>();

            CreateMap<MerchantEditDto, Merchant>();

            CreateMap<Merchant, MerchantEditDto>();

            #endregion

        }
    }
}
