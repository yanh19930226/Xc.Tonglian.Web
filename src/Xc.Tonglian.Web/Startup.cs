using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Tonglian.Sdk;

namespace Xc.Tonglian.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region MySql
            services.AddDbContext<TonglianDbContext>(options =>
            {
                options.UseMySql(Configuration.GetConnectionString("MySqlConnection"));
            });
            #endregion

            #region MediatR
            //services.AddMediatR();
            #endregion

            #region 通联客户端注入
            services.Configure<TonglianConfig>(Configuration.GetSection("TonglianConfig"));
            var settings = services.BuildServiceProvider().GetService<IOptions<TonglianConfig>>().Value;
            services.AddSingleton(new TonglianClient(settings.ServiceName, settings.SecretId, settings.SecretKey, settings.Authcus, settings.MerId, settings.IsDev ? EnvEnum.Dev : EnvEnum.Prod));
            #endregion

            #region Service批量注入
            services.Scan(scan => scan
                 .FromAssemblyOf<Startup>()
                 .AddClasses()
                 .AsMatchingInterface()
                 .WithTransientLifetime());
            #endregion

            #region MyRegion
            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            #endregion

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
