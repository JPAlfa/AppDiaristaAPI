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
        Task<bool> AlterarSenhaDiarista(int idDiarista, string senha);
        Task<bool> AlterarSenhaContratante(int idContratante, string senha);
        Task<bool> AlterarPrecoDiariaDiarista(int idDiarista, double precoDiaria);
    }
}
