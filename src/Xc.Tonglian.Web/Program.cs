using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xc.Tonglian.Web
{
    public class Program
    {


        public static void Main(string[] args)
        {
           CreateHostBuilder(args).Build().MigrateDbContext<TonglianDbContext>((context, service) => {
                new TonglianDbContextSeed().SeedAsync(context, service).Wait();
            }).Run();

           
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
