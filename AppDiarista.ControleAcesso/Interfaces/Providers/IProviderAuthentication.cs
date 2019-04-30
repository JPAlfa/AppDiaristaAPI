using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace AppDiarista.ControleAcesso.Interfaces.Providers
{
    public interface IProviderAuthentication
    {
        JwtBearerOptions GetJwtBearerAuthenticationOptions(JwtBearerOptions options);
    }
}
