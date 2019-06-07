using AppDiarista.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppDiarista.ServiceApplication.Interfaces
{
    public interface IPerfilService
    {
        Task<bool> AlterarContratante(ContratanteDTO item);
        Task<bool> AlterarDiarista(DiaristaDTO item);
        Task<bool> AlterarEndereco(EnderecoDTO item);
        Task<bool> AlterarSenhaDiarista(AlteraSenhaDTO model);
        Task<bool> AlterarSenhaContratante(AlteraSenhaDTO model);
        Task<bool> AlterarPrecoDiariaDiarista(int idDiarista, double precoDiaria);
    }
}
