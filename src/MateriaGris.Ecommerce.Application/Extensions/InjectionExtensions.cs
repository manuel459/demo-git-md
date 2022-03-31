using AutoMapper;
using MateriaGris.Ecommerce.Application.Interfaces;
using MateriaGris.Ecommerce.Application.Mappers;
using MateriaGris.Ecommerce.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateriaGris.Ecommerce.Application.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionApplication(this IServiceCollection services) 
        {
            services.AddScoped<ICustomerApplication, CustomerApplication>();

            //Auto Mapper Configuration

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
