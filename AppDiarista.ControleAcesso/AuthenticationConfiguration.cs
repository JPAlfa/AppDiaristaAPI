using AppDiarista.ControleAcesso.Interfaces.Providers;
using AppDiarista.ControleAcesso.Providers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppDiarista.ControleAcesso
{
    public static class AuthenticationConfiguration
    {
        #region Propriedades

        private static IServiceProvider serviceProvider { get; set; }

        #endregion

        #region Métodos Públicos

        public static void Config(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtConfiguration>(configuration.GetSection(nameof(JwtConfiguration)));

            ResolverDependenciasControleAcesso(services);

            ConfigurarJwtBearerAuthentication(services);
            ConfigurarAuthorization(services);
        }

        #endregion

        #region Métodos Privados

        private static void ResolverDependenciasControleAcesso(IServiceCollection services)
        {
            services.AddScoped<IProviderAuthentication, ProviderAuthentication>();
            services.AddScoped<IProviderAuthorization, ProviderAuthorization>();
            services.AddScoped<IProviderJwtCustomizado, ProviderJwtCustomizado>();

            serviceProvider = services.BuildServiceProvider();
        }

        private static void ConfigurarJwtBearerAuthentication(IServiceCollection services)
        {
            var providerAuthentication = serviceProvider.GetService<IProviderAuthentication>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => providerAuthentication.GetJwtBearerAuthenticationOptions(options));
        }

        private static void ConfigurarAuthorization(IServiceCollection services)
        {
            var providerAuthorization = serviceProvider.GetService<IProviderAuthorization>();
            services.AddAuthorization(options => providerAuthorization.GetAuthorizationOptions(options));
        }

        #endregion
    }

    
}
