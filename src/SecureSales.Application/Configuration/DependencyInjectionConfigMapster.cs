using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using SecureSales.Application.DTOs;
using SecureSales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureSales.Application.Configuration
{
    static class DependencyInjectionConfigMapster
    {
        public static IServiceCollection AddMapster(this IServiceCollection services)
        {
            services.AddScoped<IMapper, Mapper>();
            return services.AddSingleton(CreateMapster());
        }

        public static TypeAdapterConfig CreateMapster()
        {
            var config = new TypeAdapterConfig();
            config.Default.IgnoreNullValues(true);
            config.Default.Settings.PreserveReference = true;

            ConfigurarGeral(config);

            return config;
        }

        private static void ConfigurarGeral(TypeAdapterConfig cfg)
        {
            cfg.NewConfig<Cliente, ClienteDto>().TwoWays();
        }
    }
}
