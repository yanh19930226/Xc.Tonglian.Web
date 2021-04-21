using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tonglian.Sdk;
using Tonglian.Sdk.Models.Accounts;
using Xc.Tonglian.Web.Models.Dto.Account;

namespace Xc.Tonglian.Web.Services.Impl
{
    public class AccountService : IAccountService
    {
        private TonglianClient _client;
        public AccountService(TonglianClient client)
        {
            _client = client;
        }
        public AccountCreateResponse CreateAccount(AccountCreateDto dto)
        {

            var AccountCreateModel = new AccountCreateModel()
            {
                cusid = dto.CusId,
                accountNo = dto.AccountNo,
                accountName = dto.AccountName,
                currency = dto.Currency,
                nature = dto.Nature,
                country = dto.Country,
                city = dto.City,
                province = dto.Province,
                cardorbook = dto.CardorBook,
                biccode = dto.BicCode,
                addr = dto.Addr,
            };

            return _client.RequestAsync(new AccountCreateRequest(AccountCreateModel));

        }

        public AccountEditResponse EditAccount(AccountEditDto dto)
        {
            var AccountEditModel = new AccountEditRequestModel()
            {
                cusid = dto.CusId,
                accountNo = dto.AccountNo,
                accountName = dto.AccountName,
                currency = dto.Currency,
                nature = dto.Nature,
                country = dto.Country,
                city = dto.City,
                province = dto.Province,
                cardorbook = dto.CardorBook,
                biccode = dto.BicCode,
                addr = dto.Addr,
            };

            return _client.RequestAsync(new AccountEditRequest(AccountEditModel));
        }
    }
}
