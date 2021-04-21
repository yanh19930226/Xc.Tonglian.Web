using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tonglian.Sdk.Models.Customers;
using Xc.Tonglian.Web.Models.Dto.Customer;

namespace Xc.Tonglian.Web.Services
{
    public interface ICustomerService
    {
        CustomerCreateResponse CreateCustomer(CustomerCreateDto dto);
    }
}
