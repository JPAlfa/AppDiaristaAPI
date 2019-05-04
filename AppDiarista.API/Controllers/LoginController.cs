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
    public class LoginController : ApiBaseController
    {
        #region Propriedades

        private readonly IAuthenticationService authenticationService;

        #endregion

        #region Construtores

        public LoginController(
            INotificador notificador,
            ILogger<ApiBaseController> logger,
            IAuthenticationService authenticationService) : base(notificador, logger)
        {
            this.authenticationService = authenticationService;
        }

        #endregion

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Token(LoginDTO model)
        {
            return await CreateResponse(async () => await authenticationService.Autenticar(model));
        }
    }
}