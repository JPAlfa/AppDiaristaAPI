using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AppDiarista.Common.ExtensionMethods;
using AppDiarista.ControleAcesso.Interfaces.Factory;
using AppDiarista.ControleAcesso.Interfaces.Providers;
using AppDiarista.ControleAcesso.Providers;
using Microsoft.AspNetCore.Http;

namespace AppDiarista.ControleAcesso.Factory
{
    public class UsuarioFactory : IUsuarioFactory
    {
        public async Task<List<Claim>> ExtrairClaimsUsuario(IFormCollection dadosRequest)
        {
            List<Claim> retorno = null;

            var providersDeUsuario = IoCExtension.Instance.GetService(typeof(IEnumerable<IUsuarioProvider>)) as IEnumerable<IUsuarioProvider>;
            foreach (var provider in providersDeUsuario)
            {
                if ((retorno == null)
                    && provider.ValidarRequest(dadosRequest))
                {
                    return await provider.ExtrairClaimsUsuario(dadosRequest);
                }
            }

            return null;
        }
    }
}
