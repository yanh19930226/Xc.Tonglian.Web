using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xc.Tonglian.Web.Models.Domain
{
    public class User :  IdentityUser<long>
    {
        public virtual List<UserConfig> UserConfigs { get; set; } = new List<UserConfig>();

        public virtual List<Shop> Shops { get; set; }= new List<Shop>();

        public virtual List<Merchant> Merchants { get; set; }= new List<Merchant>();

        public virtual List<Account> Accounts { get; set; }= new List<Account>();

        public virtual List<Customer> Customers { get; set; } = new List<Customer>();
    }
}
