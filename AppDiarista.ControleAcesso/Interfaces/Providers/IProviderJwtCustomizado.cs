using Microsoft.AspNetCore.Authentication;

namespace AppDiarista.ControleAcesso.Interfaces.Providers
{
    public interface IProviderJwtCustomizado
    {
        string Protect(AuthenticationTicket data);
        AuthenticationTicket Unprotect(string protectedText);
    }
}
