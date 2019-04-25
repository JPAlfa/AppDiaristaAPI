using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppDiarista.Common.Interfaces;
using AppDiarista.DTO;
using AppDiarista.ServiceApplication.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AppDiarista.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAllHeaders")]
    [Authorize(Policy = "UsuarioN2")]
    public class IntencaoController : ApiBaseController
    {
        #region Propriedades

        private readonly IIntencaoService intencaoService;

        #endregion

        #region Construtores

        public IntencaoController(
            INotificador notificador,
            ILogger<ApiBaseController> logger,
            IIntencaoService intencaoService) : base(notificador, logger)
        {
            this.intencaoService = intencaoService;
        }

        #endregion

        #region Métodos Públicos

        [HttpPost]
        public async Task<IActionResult> Post(IntencaoDTO model)
        {
            return await CreateResponse(async () => await intencaoService.Inserir(model));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await CreateResponse(async () => await intencaoService.Listar());
        }

        [HttpGet("filtrar/{botId}")]
        public async Task<IActionResult> GetFilteredIntents(string botId)
        {
            return await CreateResponse(async () => await intencaoService.ListarPorBot(botId));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return await CreateResponse(async () => await intencaoService.RetornarPorId(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, IntencaoDTO model)
        {
            return await CreateResponse(async () => await intencaoService.Alterar(id, model));
        }
        #endregion
    }
}