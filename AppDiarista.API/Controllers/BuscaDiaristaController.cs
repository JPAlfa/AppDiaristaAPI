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
    [Authorize]
    [ApiController]
    public class BuscaDiaristaController : ApiBaseController
    {
        #region Propriedades

        private readonly IBuscaDiaristaService buscaService;

        #endregion

        #region Construtores

        public BuscaDiaristaController(
            INotificador notificador,
            ILogger<ApiBaseController> logger,
            IBuscaDiaristaService buscaService) : base(notificador, logger)
        {
            this.buscaService = buscaService;
        }

        #endregion

        #region Métodos Públicos

        [HttpGet("PorCidade")]
        public async Task<IActionResult> Get([FromQuery]string cidade)
        {
            return await CreateResponse(async () => await buscaService.ListarDiaristasPorCidade(cidade));
        }

        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    return await CreateResponse(async () => await intencaoService.Listar());
        //}

        //[HttpGet("filtrar/{botId}")]
        //public async Task<IActionResult> GetFilteredIntents(string botId)
        //{
        //    return await CreateResponse(async () => await intencaoService.ListarPorBot(botId));
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(int id)
        //{
        //    return await CreateResponse(async () => await intencaoService.RetornarPorId(id));
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Put(int id, IntencaoDTO model)
        //{
        //    return await CreateResponse(async () => await intencaoService.Alterar(id, model));
        //}
        #endregion
    }
}