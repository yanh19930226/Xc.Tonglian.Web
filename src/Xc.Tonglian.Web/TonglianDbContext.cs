using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Xc.Tonglian.Web.Models.Domain;
using Xc.Tonglian.Web.Models.EntityConfiguration;

namespace Xc.Tonglian.Web
{
    public class TonglianDbContext: DbContext
    {
        public TonglianDbContext(DbContextOptions<TonglianDbContext> options) : base(options)
        {

        }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Merchant> Merchants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ShopConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new MerchantConfiguration());

            //foreach (Type item in (Assembly.GetEntryAssembly()!.GetTypes()).Where(type => type.HasImplementedRawGeneric(typeof(IEntityTypeConfiguration<>))))
            //{
            //    dynamic val = Activator.CreateInstance(item);
            //    modelBuilder.ApplyConfiguration(val);
            //}
            //base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            await base.SaveChangesAsync();
            return true;
        }
    }
}
