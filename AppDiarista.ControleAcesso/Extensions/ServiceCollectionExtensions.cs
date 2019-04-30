using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppDiarista.ControleAcesso.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomJwtBearerAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            AuthenticationConfiguration.Config(services, configuration);
            return services;
        }
    }
}
