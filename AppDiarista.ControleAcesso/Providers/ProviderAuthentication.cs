using AppDiarista.ControleAcesso.Interfaces.Providers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;

namespace AppDiarista.ControleAcesso.Providers
{
    public class ProviderAuthentication : IProviderAuthentication
    {
        #region Propriedades

        private readonly JwtConfiguration jwtConfiguration;

        #endregion

        #region Construtores

        public ProviderAuthentication(IOptions<JwtConfiguration> jwtConfigurationOptions)
        {
            this.jwtConfiguration = jwtConfigurationOptions.Value;
        }

        #endregion

        #region Métodos Públicos

        public JwtBearerOptions GetJwtBearerAuthenticationOptions(JwtBearerOptions options)
        {
            options.ClaimsIssuer = jwtConfiguration.Issuer;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtConfiguration.Issuer,
                ValidateAudience = true,
                ValidAudience = jwtConfiguration.Audience,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = jwtConfiguration.SigningKey,    
                RequireExpirationTime = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
            options.SaveToken = true;
            return options;
        }

        #endregion

    }
}
