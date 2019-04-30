using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AppDiarista.ControleAcesso.Interfaces.Providers
{
    public interface IUsuarioProvider
    {
        bool ValidarRequest(IFormCollection dadosRequest);
        Task<List<Claim>> ExtrairClaimsUsuario(IFormCollection dadosRequest);
    }
}
