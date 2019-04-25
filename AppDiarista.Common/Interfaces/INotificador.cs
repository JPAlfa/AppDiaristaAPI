using System.Collections.Generic;
using AppDiarista.Common.Notification;

namespace AppDiarista.Common.Interfaces
{
    public interface INotificador
    {
        IEnumerable<INotificacao> ObterNotificacoes();
        bool PossuiNotificacoes();
        void AdicionarNotificacao(Notificacao notificacao);
        void AdicionarListaNotificacoes(Dictionary<string, string> dicionario);
    }
}
