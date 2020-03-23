using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopCore.Areas.Identity.Data;
using ShopCore.Data;

[assembly: HostingStartup(typeof(ShopCore.Areas.Identity.IdentityHostingStartup))]
namespace ShopCore.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ShopCoreContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("ShopCoreDB")));

                services.AddDefaultIdentity<ShopCoreUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<ShopCoreContext>();
            });
        }
    }
}