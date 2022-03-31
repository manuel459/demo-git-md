using MateriaGris.Ecommerce.Infrastructure.Persistences.Context;
using MateriaGris.Ecommerce.Infrastructure.Persistences.Interfaces;
using MateriaGris.Ecommerce.Infrastructure.Persistences.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateriaGris.Ecommerce.Infrastructure.Extensions
{
    public static class InyectionExtensions
    {
        public static IServiceCollection AddInjectionInfrastructure(this IServiceCollection services, IConfiguration configuration) 
        {
            var assembly = typeof(ApplicationDbContext).Assembly.FullName;
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(
                    configuration.GetConnectionString("MateriaGrisConnection"), b => b.MigrationsAssembly(assembly)), ServiceLifetime.Transient);
            services.AddScoped<ICustomerRepository, CustomerRepository>();
                return services;          
        }
    }
}
