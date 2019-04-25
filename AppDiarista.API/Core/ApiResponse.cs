using System.Collections.Generic;
using AppDiarista.Common.Interfaces;

namespace AppDiarista.API.Core
{
    public class ApiResponse
    {
        public ApiResponse(object dados = null, IEnumerable<INotificacao> notificacoes = null, bool sucesso = false)
        {
            this.Dados = dados;
            this.Sucesso = sucesso;
            this.Notificacoes = notificacoes;
        }

        public bool Sucesso { get; }
        public object Dados { get; }

        public IEnumerable<INotificacao> Notificacoes { get; set; }
    }
}
