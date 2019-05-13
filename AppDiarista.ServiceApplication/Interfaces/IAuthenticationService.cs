using AppDiarista.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppDiarista.ServiceApplication.Interfaces
{
    public interface IAuthenticationService
    {
        Task<UsuarioLogadoDTO> Autenticar(LoginDTO model);
    }
}
