using Microsoft.AspNetCore.Authorization;

namespace AppDiarista.ControleAcesso.Interfaces.Providers
{
    public interface IProviderAuthorization
    {
        AuthorizationOptions GetAuthorizationOptions(AuthorizationOptions options);
    }
}
