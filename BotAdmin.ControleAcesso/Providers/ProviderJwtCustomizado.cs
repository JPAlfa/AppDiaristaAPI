using AppDiarista.ControleAcesso.Interfaces.Providers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace AppDiarista.ControleAcesso.Providers
{
    public class ProviderJwtCustomizado : IProviderJwtCustomizado
    {
        #region Propriedades

        private readonly JwtConfiguration jwtConfiguration;

        #endregion

        #region Construtores

        public ProviderJwtCustomizado(IOptions<JwtConfiguration> jwtConfigurationOptions)
        {
            this.jwtConfiguration = jwtConfigurationOptions.Value;
        }

        #endregion

        #region Métodos Públicos

        public string Protect(AuthenticationTicket data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            var handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(new JwtSecurityToken(
                jwtConfiguration.Issuer,
                jwtConfiguration.Audience,
                data.Principal.Claims,
                null,
                DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtConfiguration.MinutosValidadeToken)),
                jwtConfiguration.SigningCredentials
            ));
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            if (string.IsNullOrEmpty(protectedText))
            {
                throw new ArgumentNullException("refresh_token");
            }

            var handler = new JwtSecurityTokenHandler();

            var token = handler.ReadToken(protectedText);
            var tokenRecebido = ((JwtSecurityToken)token).RawData;
            var validationParameters = new TokenValidationParameters
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

            SecurityToken tokenValidado;
            var principal = handler.ValidateToken(tokenRecebido, validationParameters, out tokenValidado);

            var ticket = new AuthenticationTicket(principal, new AuthenticationProperties(), JwtBearerDefaults.AuthenticationScheme);
            if (ticket == null)
            {
                throw new Exception();
            }

            return new AuthenticationTicket(principal, new AuthenticationProperties(), JwtBearerDefaults.AuthenticationScheme);
        }

        #endregion
    }
}
