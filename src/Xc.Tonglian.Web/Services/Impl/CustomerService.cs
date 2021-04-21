using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tonglian.Sdk;
using Tonglian.Sdk.Models.Customers;
using Xc.Tonglian.Web.Models.Dto.Customer;

namespace Xc.Tonglian.Web.Services.Impl
{
    public class CustomerService : ICustomerService
    {

        private TonglianClient _client;
        public CustomerService(TonglianClient client)
        {
            _client = client;
        }
        public CustomerCreateResponse CreateCustomer(CustomerCreateDto dto)
        {
            var CustomerCreate = new CustomerCreateRequestModel()
            {
                ctid = dto.CtId,
                cusname = dto.CusName,
                address = dto.Address,
                belongbranch = dto.Belongbranch,
                areacode = dto.Areacode,
                flag = dto.Flag,
                tel = dto.Tel,
                cuskind = dto.Cuskind,
                businesskind = dto.Businesskind,
                threcertflag = dto.Threcertflag,
                creditcode = dto.Creditcode,
                organcode = dto.Organcode,
                buslicense = dto.Buslicense,
                creditcodeexpire = dto.Creditcodeexpire,
                legalidno = dto.Legalidno,
                legal = dto.Legal,
                legalidexpire = dto.Legalidexpire,
                businessplace = dto.Businessplace,
                websitecountry = dto.Websitecountry,
                website = dto.Website,
                tradingplatform = dto.Tradingplatform,
                stafftotal = dto.Stafftotal,
                protocolexpire = dto.Protocolexpire,
                tlinstcode = dto.Tlinstcode,
                holdername = dto.Holdername,
                holderidno = dto.Holderidno,
                holderexpire = dto.Holderexpire,
                bnfname = dto.Bnfname,
                bnfidno = dto.Bnfidno,
                bnfexpire = dto.Bnfexpire,
                bnfaddress = dto.Bnfaddress,
                legalemail = dto.Legal,
            };

            return _client.RequestAsync(new CustomerCreateRequest(CustomerCreate));
        }
    }
}
