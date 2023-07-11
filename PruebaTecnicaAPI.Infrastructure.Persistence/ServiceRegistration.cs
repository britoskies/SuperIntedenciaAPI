using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PruebaTecnicaAPI.Core.Application.Interfaces.Repositories;
using PruebaTecnicaAPI.Infrastructure.Persistence.Repositories;
using PruebaTecnicaAPI.Infrastructure.Persistence.Contexts;
using PruebaTecnicaAPI_SuperIntendenciaDeBancos.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaAPI.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceInfrastructure(this IServiceCollection service, IConfiguration config)
        {
            service.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"),
                m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));

            service.AddTransient(typeof(IGenericRepo<>), typeof(GenericRepo<>));
            service.AddTransient<ICategoryRepo, CategoryRepo>();
            service.AddTransient<IProductRepo, ProductRepo>();
        }
    }
}
