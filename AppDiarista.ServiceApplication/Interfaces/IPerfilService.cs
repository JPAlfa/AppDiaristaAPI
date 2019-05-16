using AppDiarista.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppDiarista.ServiceApplication.Interfaces
{
    public interface IPerfilService
    {
        Task AlterarContratante(ContratanteEEnderecoDTO item);
        Task AlterarDiarista(DiaristaEEnderecoDTO item);
        Task AlterarSenhaDiarista(DiaristaDTO item);
        Task AlterarSenhaContratante(ContratanteDTO item);
    }
}
