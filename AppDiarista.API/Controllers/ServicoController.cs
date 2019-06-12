using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppDiarista.Common.Interfaces;
using AppDiarista.DTO;
using AppDiarista.ServiceApplication.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AppDiarista.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicoController : ApiBaseController
    {
        #region Propriedades
        private readonly IAgendamentoService agendamentoService;

        #endregion

        #region Construtores
        public ServicoController(
           INotificador notificador,
           ILogger<ApiBaseController> logger,
           IAgendamentoService agendamentoService) : base(notificador, logger)
        {
            this.agendamentoService = agendamentoService;
        }

        #endregion


        #region Métodos Públicos
        [HttpPost("Agendar")]
        public async Task<IActionResult> Post([FromBody]AgendamentoServicoDTO servico)
        {
            return await CreateResponse(async () => await agendamentoService.AgendarServico(servico));
        }

        [HttpGet("Confirmar")]
        public async Task<IActionResult> Get([FromQuery]int idServico)
        {
            return await CreateResponse(async () => await agendamentoService.ConfirmarServico(idServico));
        }

        [HttpGet("Avaliar")]
        public async Task<IActionResult> Get([FromQuery]int idServico, short nota)
        {
            return await CreateResponse(async () => await agendamentoService.AvaliarServico(idServico, nota));
        }

        [HttpGet("DiasOcupados")]
        public async Task<IActionResult> GetDiasOcupados([FromQuery]int idDiarista)
        {
            return await CreateResponse(async () => await agendamentoService.BuscarDiasOcupados(idDiarista));
        }

        [HttpGet("ServicosDiarista")]
        public async Task<IActionResult> GetServicosDiarista([FromQuery]int idDiarista)
        {
            return await CreateResponse(async () => await agendamentoService.BuscarRequisicoesServicosDiarista(idDiarista));
        }

        [HttpGet("ServicosAgendados")]
        public async Task<IActionResult> GetServicosAgendados([FromQuery]int idContratante)
        {
            return await CreateResponse(async () => await agendamentoService.BuscarServicosConfirmadosContratante(idContratante));
        }

        #endregion
    }
}