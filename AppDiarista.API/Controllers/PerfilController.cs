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
    public class PerfilController : ApiBaseController
    {
        #region Propriedades

        private readonly IPerfilService perfilService;

        #endregion

        #region Construtores

        public PerfilController(
            INotificador notificador,
            ILogger<ApiBaseController> logger,
            IPerfilService perfilService) : base(notificador, logger)
        {
            this.perfilService = perfilService;
        }

        #endregion

        #region Métodos Públicos

        [AllowAnonymous]
        [HttpPut("AlterarContratante")]
        public async Task<IActionResult> Put([FromBody]ContratanteDTO model)
        {
            return await CreateResponse(async () => await perfilService.AlterarContratante(model));
        }

        [AllowAnonymous]
        [HttpPut("AlterarDiarista")]
        public async Task<IActionResult> Put([FromBody]DiaristaDTO model)
        {
            return await CreateResponse(async () => await perfilService.AlterarDiarista(model));
        }

        [AllowAnonymous]
        [HttpPut("AlterarEndereco")]
        public async Task<IActionResult> Put([FromBody]EnderecoDTO model)
        {
            return await CreateResponse(async () => await perfilService.AlterarEndereco(model));
        }

        [AllowAnonymous]
        [HttpPost("AlterarSenhaContratante")]
        public async Task<IActionResult> PutContratante([FromQuery]int idContratante, [FromBody]string senha)
        {
            return await CreateResponse(async () => await perfilService.AlterarSenhaContratante(idContratante, senha));
        }

        [AllowAnonymous]
        [HttpPost("AlterarSenhaDiarista")]
        public async Task<IActionResult> PutDiarista([FromQuery]int idDiarista, [FromBody]string senha)
        {
            return await CreateResponse(async () => await perfilService.AlterarSenhaDiarista(idDiarista, senha));
        }

        [AllowAnonymous]
        [HttpPost("AlterarPrecoDiarista")]
        public async Task<IActionResult> Put([FromQuery]int idDiarista, [FromBody]double precoDiaria)
        {
            return await CreateResponse(async () => await perfilService.AlterarPrecoDiariaDiarista(idDiarista, precoDiaria));
        }

        #endregion
    }
}