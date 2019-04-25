using AppDiarista.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppDiarista.ServiceApplication.Interfaces
{
    public interface IIntencaoService
    {
        Task<IntencaoDTO> Inserir(IntencaoDTO item);
        Task<IntencaoDTO> Alterar(int id, IntencaoDTO item);
        Task<List<IntencaoDTO>> Listar();
        Task<List<IntencaoDTO>> ListarPorBot(string botId);
        Task<IntencaoDTO> RetornarPorId(int id);
    }
}
