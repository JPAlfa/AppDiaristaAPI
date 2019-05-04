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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAllHeaders")]
    public class CadastroController : ApiBaseController
    {
        #region Propriedades

        private readonly ICadastroService cadastroService;

        #endregion

        #region Construtores

        public CadastroController(
            INotificador notificador,
            ILogger<ApiBaseController> logger,
            ICadastroService cadastroService) : base(notificador, logger)
        {
            this.cadastroService = cadastroService;
        }

        #endregion

        #region Métodos Públicos

        [HttpPost("Contratante")]
        [AllowAnonymous]
        public async Task<IActionResult> Post(CadastroContratanteDTO model)
        {
            return await CreateResponse(async () => await cadastroService.InserirContratante(model));
        }

        [HttpPost("Diarista")]
        public async Task<IActionResult> Post(CadastroDiaristaDTO model)
        {
            return await CreateResponse(async () => await cadastroService.InserirDiarista(model));
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