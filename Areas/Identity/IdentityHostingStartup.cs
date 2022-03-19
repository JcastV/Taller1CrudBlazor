using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Taller1CrudBlazor.Areas.Identity.Data;

[assembly: HostingStartup(typeof(Taller1CrudBlazor.Areas.Identity.IdentityHostingStartup))]
namespace Taller1CrudBlazor.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<SqlDBContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("SqlDBContext")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<SqlDBContext>();
            });
        }
    }
}