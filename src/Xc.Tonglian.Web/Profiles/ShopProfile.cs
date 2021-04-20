using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xc.Tonglian.Web.Models.Domain;
using Xc.Tonglian.Web.Models.Dto.Shop;

namespace Xc.Tonglian.Web.Profiles
{
    public class ShopProfile : Profile
    {
        public ShopProfile()
        {

            CreateMap<ShopCreateDto, Shop>();

            CreateMap<Shop, ShopCreateDto>();

            CreateMap<ShopEditDto, Shop>();

            CreateMap<Shop, ShopEditDto > ();

        }
    }
}
