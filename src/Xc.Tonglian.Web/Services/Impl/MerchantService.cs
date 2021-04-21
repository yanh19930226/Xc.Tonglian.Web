using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tonglian.Sdk;
using Tonglian.Sdk.Models.Merchants;
using Xc.Tonglian.Web.Models.Dto.Merchant;

namespace Xc.Tonglian.Web.Services.Impl
{
    public class MerchantService : IMerchantService
    {
        private TonglianClient _client;
        public MerchantService(TonglianClient client)
        {
            _client = client;
        }
        public MerchantCreateResponse CreateMerchant(MerchantCreateDto dto)
        {

            var MerchantCreateRequest = new MerchantCreateRequestModel()
            {
                mtid = dto.Mtid,
                cusid = dto.CusId,
                mername = dto.MerName,
                areacode = dto.AreaCode,
                organid = dto.OrganId,
            };

            return _client.RequestAsync(new MerchantCreateRequest(MerchantCreateRequest));
        }

        public MerchantEditResponse EditMerchant(MerchantEditDto dto)
        {
            var MerchantEditRequest = new MerchantEditRequestModel()
            {
                regid = dto.Mtid,
                cusid = dto.CusId,
                mername = dto.MerName,
                areacode = dto.AreaCode,
                organid = dto.OrganId,
            };

            return _client.RequestAsync(new MerchantEditRequest(MerchantEditRequest));
        }
    }
}
