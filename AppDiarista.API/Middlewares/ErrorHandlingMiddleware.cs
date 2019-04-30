using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using AppDiarista.API.Core;

namespace AppDiarista.API.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate Next;
        private readonly ILogger<ErrorHandlingMiddleware> Log;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> log)
        {
            Next = next;
            Log = log;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await Next(context);
            }
            catch (Exception ex)
            {
                await TratarErros(context, ex);
            }
        }

        private Task TratarErros(HttpContext context, Exception ex)
        {
            GerarLogErros(context, ex);
            var result = GerarJsonContentParaErro(context, ex);

            return context.Response.WriteAsync(result);

        }

        private void GerarLogErros(HttpContext context, Exception ex)
        {
            var requestContext = context.Request;
            if (requestContext != null)
            {
                var usuario = context.User;
                if (usuario != null && usuario.Identity != null && usuario.Identity.IsAuthenticated)
                {
                    GerarLogErros(context, ex, usuario);
                }
                else
                {
                    InserirLog(context, ex, "");
                }
            }
            else
            {
                InserirLog(context, ex, "");
            }
        }

        private void GerarLogErros(HttpContext context, Exception ex, System.Security.Principal.IPrincipal usuario)
        {
            var claims = ((ClaimsIdentity)usuario.Identity).Claims;

            var valoresClaims = new List<string>();
            foreach (var item in claims)
            {
                valoresClaims.Add(item.Type + " - " + item.Value);
            }
            InserirLog(context, ex, JsonConvert.SerializeObject(valoresClaims));
        }

        private void InserirLog(HttpContext context, Exception exception, string claimsUsuario)
        {
            // TODO Salvar mais dados da requisição atual
            var _url = new Uri(context.Request.GetDisplayUrl());
            var _metodo = context.Request.Method;

            Log.LogError(exception, "API - Erro - @{Detalhes}",
                new
                {
                    url = _url,
                    metodo = _metodo,
                    claimsUsuario
                });
        }

        private string GerarJsonContentParaErro(HttpContext context, Exception exception)
        {
            var mensagem = CriarObjetoMensagemErro(context, exception);

            var code = HttpStatusCode.BadRequest;

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return JsonConvert.SerializeObject(mensagem);
        }

        private ApiResponse CriarObjetoMensagemErro(HttpContext context, Exception exception)
        {
            var response = new ApiResponse(sucesso: false);

            return response;
        }
    }

    public static class ErrorLoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
