using AppDiarista.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppDiarista.ServiceApplication.Interfaces
{
    public interface IAgendamentoService
    {
        Task<int> AgendarServico(AgendamentoServicoDTO servico);
        Task ConfirmarServico(int idServico);
        Task AvaliarServico(int idServico, short nota);
        Task<List<DateTime>> BuscarDiasOcupados(int idDiarista);
    }
}
