using AppDiarista.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppDiarista.ServiceApplication.Interfaces
{
    public interface ICadastroService
    {
        Task<int> InserirContratante(CadastroContratanteDTO item);
        Task<int> InserirDiarista(CadastroDiaristaDTO item);
    }
}
