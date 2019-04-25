using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AppDiarista.Common.Interfaces;

namespace AppDiarista.Common.Notification
{
    public class Notificador : INotificador
    {
        private static List<Notificacao> notificacoes;

        public Notificador()
        {
            notificacoes = new List<Notificacao>();
        }

        public void AdicionarListaNotificacoes(Dictionary<string, string> dicionario)
        {
            foreach (var item in dicionario)
            {
                notificacoes.Add(new Notificacao(item.Key, item.Value));
            }
        }

        public void AdicionarNotificacao(Notificacao notificacao)
        {
            notificacoes.Add(notificacao);
        }

        public IEnumerable<INotificacao> ObterNotificacoes()
        {
            return notificacoes;
        }

        public bool PossuiNotificacoes()
        {
            return notificacoes.Any();
        }
    }
}
