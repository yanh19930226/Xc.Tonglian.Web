using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xc.Tonglian.Web.Models.Domain;

namespace Xc.Tonglian.Web
{
    public class TonglianDbContextSeed
    {
        private UserManager<User> _userManager;
        public async Task SeedAsync(TonglianDbContext context, IServiceProvider services)
        {
            if (!context.Users.Any())
            {
                _userManager = services.GetRequiredService<UserManager<User>>();

                var defaultUser = new User
                {
                    UserName = "yanh",
                    Email = "123456@163.com",
                    NormalizedUserName = "admin"
                };

                var resul = await _userManager.CreateAsync(defaultUser, "123456");
                if (!resul.Succeeded)
                {
                    throw new Exception("初始化默认用户失败");
                }
            }
        }
    }
}
