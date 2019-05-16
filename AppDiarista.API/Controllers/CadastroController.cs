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
        public async Task<IActionResult> Post([FromBody]ContratanteEEnderecoDTO model)
        {
            return await CreateResponse(async () => await cadastroService.InserirContratante(model));
        }

        [HttpPost("Diarista")]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody]DiaristaEEnderecoDTO model)
        {
            return await CreateResponse(async () => await cadastroService.InserirDiarista(model));
        }

        #endregion
    }
}