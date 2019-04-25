using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AppDiarista.API.Core;
using AppDiarista.Common.Interfaces;

namespace AppDiarista.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiBaseController : ControllerBase
    {
        private readonly ILogger<ApiBaseController> logger;
        private readonly INotificador notificador;

        public ApiBaseController(INotificador notificador, ILogger<ApiBaseController> logger)
        {
            this.logger = logger;
            this.notificador = notificador;
        }

        protected IEnumerable<INotificacao> notificacoes => notificador.ObterNotificacoes();

        private bool VerificaSeOperacaoValida()
        {
            return !notificador.PossuiNotificacoes();
        }

        protected async Task<IActionResult> CreateResponse<T>(Func<Task<T>> function)
        {
            var data = await function();

            return Response(data);

        }

        private new IActionResult Response(object dados = null)
        {
            if (VerificaSeOperacaoValida())
            {
                return Ok(new ApiResponse(dados: dados, sucesso: true));
            }

            return BadRequest(new ApiResponse(notificacoes: notificacoes));
        }

        protected async Task<IActionResult> CreateResponse(Func<Task> action)
        {
            await action();

            return Response();
        }


        #region Métodos públicos

        internal IEnumerable<Claim> RetornarClaimsUsuarioLogado()
        {
            return ((ClaimsIdentity)User.Identity).Claims;
        }


        internal Claim RetornarClaimsUsuarioLogado(string claim)
        {
            return ((ClaimsIdentity)User.Identity).FindFirst(claim);
        }
        #endregion
    }
}