using System.Collections.Generic;
using AppDiarista.Business.Interfaces;
using AppDiarista.Common.Interfaces;
using AppDiarista.Common.Notification;

namespace AppDiarista.Business
{
    public abstract class BaseBusiness
    {
        public readonly INotificador notificador;
        public BaseBusiness(INotificador notificador)
        {
            this.notificador = notificador;
        }
    }
}
