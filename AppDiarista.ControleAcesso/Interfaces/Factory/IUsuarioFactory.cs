using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AppDiarista.ControleAcesso.Interfaces.Factory
{
    public interface IUsuarioFactory
    {
        Task<List<Claim>> ExtrairClaimsUsuario(IFormCollection dadosRequest);
    }
}
