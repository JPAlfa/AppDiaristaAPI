using System;
using System.Collections.Generic;
using System.Text;
using AppDiarista.Common.Interfaces;

namespace AppDiarista.Common.Notification
{
    public class Notificacao : INotificacao
    {
        public Notificacao(string chave, string valor)
        {
            Chave = chave;
            Valor = valor;
        }

        public string Chave { get; }
        public string Valor { get; }
    }
}
