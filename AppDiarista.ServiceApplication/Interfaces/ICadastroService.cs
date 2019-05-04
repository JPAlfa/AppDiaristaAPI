using AppDiarista.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppDiarista.ServiceApplication.Interfaces
{
    public interface ICadastroService
    {
        Task<bool> InserirContratante(CadastroContratanteDTO item);
        Task<bool> InserirDiarista(CadastroDiaristaDTO item);
    }
}
