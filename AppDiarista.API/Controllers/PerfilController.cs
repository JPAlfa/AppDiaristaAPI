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

        [HttpPut("AlterarContratante")]
        public async Task<IActionResult> Put([FromBody]ContratanteEEnderecoDTO model)
        {
            return await CreateResponse(async () => await perfilService.AlterarContratante(model));
        }

        [HttpPut("AlterarDiarista")]
        public async Task<IActionResult> Put([FromBody]DiaristaEEnderecoDTO model)
        {
            return await CreateResponse(async () => await perfilService.AlterarDiarista(model));
        }

        [HttpPut("AlterarSenhaContratante")]
        public async Task<IActionResult> Put([FromBody]ContratanteDTO model)
        {
            return await CreateResponse(async () => await perfilService.AlterarSenhaContratante(model));
        }

        [HttpPut("AlterarSenhaDiarista")]
        public async Task<IActionResult> Put([FromBody]DiaristaDTO model)
        {
            return await CreateResponse(async () => await perfilService.AlterarSenhaDiarista(model));
        }

        #endregion
    }
}