using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Mapster;
using MapsterMapper;

namespace BuberDinner.Api.Common.Mapping
{
    public static class DependecyInjection 
    {
        public static IServiceCollection AddMappings(this IServiceCollection services)
        {
            var config =TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());

            services.AddSingleton(config);
            services.AddScoped<IMapper,ServiceMapper>();
            return services;
        }
        
    }
}