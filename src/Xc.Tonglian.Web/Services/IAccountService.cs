using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tonglian.Sdk.Models.Accounts;
using Xc.Tonglian.Web.Models.Dto.Account;

namespace Xc.Tonglian.Web.Services
{
    public interface IAccountService
    {

        AccountCreateResponse CreateAccount(AccountCreateDto dto);

        AccountEditResponse EditAccount(AccountEditDto dto);
    }
}
