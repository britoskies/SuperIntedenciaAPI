using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PruebaTecnicaAPI.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using PruebaTecnicaAPI.Infrastructure.Identity.Contexts;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaAPI.Core.Application.Services;
using PruebaTecnicaAPI.Infrastructure.Identity.Services;

namespace PruebaTecnicaAPI.Infrastructure.Identity
{
    public static class ServiceRegistration
    {
        public static void AddIdentityInfrastructure(this IServiceCollection service, IConfiguration config)
        {
            service.AddDbContext<IdentityContext>(options =>
            {
                options.EnableSensitiveDataLogging();
                options.UseSqlServer(config.GetConnectionString("IdentityConnection"),
                    m => m.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName));
            });

            service.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();

            service.AddAuthentication();

            service.AddTransient<IAccountService, AccountService>();
        }
    }
}
