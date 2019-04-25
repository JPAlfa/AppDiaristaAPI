using AppDiarista.Common.Enumerators;
using AppDiarista.ControleAcesso.Interfaces.Providers;
using Microsoft.AspNetCore.Authorization;

namespace AppDiarista.ControleAcesso.Providers
{
    public class ProviderAuthorization : IProviderAuthorization
    {
        #region Métodos Públicos

        public AuthorizationOptions GetAuthorizationOptions(AuthorizationOptions options)
        {
            options.AddPolicy("UsuarioN1", policy => policy.RequireClaim(EnumClaimsSistema.PerfilUsuario.ToString(), PerfilUsuarioEnum.n1.ToString()));
            options.AddPolicy("UsuarioN2", policy => policy.RequireAssertion(context => ValidarAcessoUsuarioPerfilN2(context)));
            return options;
        }

        private bool ValidarAcessoUsuarioPerfilN2(AuthorizationHandlerContext context)
        {
            if (!context.User.HasClaim(c => c.Type == EnumClaimsSistema.PerfilUsuario.ToString()))
            {
                return false;
            }

            var claim = context.User.FindFirst(EnumClaimsSistema.PerfilUsuario.ToString());
            if (claim.Value == PerfilUsuarioEnum.n1.ToString() || claim.Value == PerfilUsuarioEnum.n2.ToString())
            {
                return true;
            }

            return false;
        }

        #endregion
    }
}
