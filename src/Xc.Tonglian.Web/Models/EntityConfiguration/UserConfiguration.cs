using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xc.Tonglian.Web.Models.Domain;

namespace Xc.Tonglian.Web.Models.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //用户配置
            builder.HasMany(p => p.UserConfigs)
                 .WithOne(p => p.User)
                 .HasForeignKey(p => p.UserId);
            //账号
            builder.HasMany(p => p.Accounts)
                 .WithOne(p => p.User)
                 .HasForeignKey(p => p.UserId);
            //商户
            builder.HasMany(p => p.Merchants)
                 .WithOne(p => p.User)
                 .HasForeignKey(p => p.UserId);
            //店铺
            builder.HasMany(p => p.Shops)
                 .WithOne(p => p.User)
                 .HasForeignKey(p => p.UserId);
            //客户
            builder.HasMany(p => p.Customers)
                 .WithOne(p => p.User)
                 .HasForeignKey(p => p.UserId);
        }
    }
}
